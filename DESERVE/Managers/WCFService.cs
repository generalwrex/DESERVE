using DESERVE.Common;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Timers;

namespace DESERVE.Managers
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	[CallbackBehavior(UseSynchronizationContext = false)]
	class WCFService : IWCFService, IDisposable
	{
		internal String Uri { get { return "net.pipe://localhost/DESERVE/" + m_instanceName; } }

		private static Int32 _MS_PER_UPDATE_ = 500;
		private string m_instanceName;
		private List<IWCFClient> m_updateCallbacks;
		private System.Timers.Timer m_updateTimer;
		private ServiceHost m_serviceHost;
		private static WCFService m_instance;

		internal WCFService(String instanceName)
		{
			m_instanceName = instanceName;
			m_instance = this;
			m_updateCallbacks = new List<IWCFClient>();
			m_updateTimer = new System.Timers.Timer(_MS_PER_UPDATE_);
			m_updateTimer.Elapsed += OnUpdateTimer;
			m_updateTimer.AutoReset = false;
			m_updateTimer.Start();

			// Register to stream updates to remote managers.
			ServerInstance.Instance.OnChatMessage += OnChatMessage;
			ServerInstance.Instance.PlayerUpdated += OnPlayerUpdated;
			ServerInstance.Instance.OnServerStopped += () => { OnUpdateTimer(null, null); };
			ServerInstance.Instance.OnServerStarted += () => { OnUpdateTimer(null, null); };
		}

		/// <summary>
		/// Starts the WCF Pipe Service.
		/// </summary>
		internal void StartService()
		{
			try
			{
				m_serviceHost = new ServiceHost(m_instance, new Uri(m_instance.Uri));

				// Usage BasicHttpBinding can be used if this is
				// not going to be on the local machine.
				m_serviceHost.AddServiceEndpoint(typeof(IWCFService),
					 new NetNamedPipeBinding(),
					 m_instance.Uri);
				m_serviceHost.Open();

				LogManager.MainLog.WriteLineAndConsole(String.Format("DESERVE: Opened WCF Pipe at {0}", m_instance.Uri));
			}
			catch (Exception ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole(String.Format("DESERVE: Failed to open WCF Pipe. Exception: {0}", ex.ToString()));
			}
		}

		/// <summary>
		/// Stops the WCF Pipe Service.
		/// </summary>
		internal void StopService()
		{
			if (m_serviceHost != null)
			{
				if (m_serviceHost.State != CommunicationState.Closed)
				{
					m_serviceHost.Close();
					LogManager.MainLog.WriteLineAndConsole("DESERVE: WCF Pipe closed.");
				}
			}
		}

		public void Dispose()
		{
			StopService();
			m_instance = null;
		}

		#region Event Handlers
		// Event Handlers take events from DESERVE and dispatch them across WCF to remotes.
		/// <summary>
		/// Streams PlayerUpdates to DESERVE Managers.
		/// </summary>
		/// <param name="player"></param>
		private void OnPlayerUpdated(Player player, PlayerAction action)
		{
			foreach (IWCFClient callback in m_updateCallbacks)
			{
				callback.PlayerUpdate(player, action);
			}
		}

		/// <summary>
		/// Streams ChatMessages to the DESERVE Managers.
		/// </summary>
		/// <param name="message"></param>
		private void OnChatMessage(ChatMessage message)
		{
			foreach (IWCFClient callback in m_updateCallbacks)
			{
				callback.ChatMessageUpdate(message);
			}
		}

		/// <summary>
		/// Streams status updates to DESERVE Managers
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnUpdateTimer(object sender, ElapsedEventArgs e)
		{
			foreach (IWCFClient callback in m_updateCallbacks)
			{
				callback.ServerStateUpdatePartial(ServerInstance.Instance.GetInfoPartial());
			}

			// Restart the timer for next time.
			m_updateTimer.Start();
		}

		/// <summary>
		/// Removes the channel from the update list when faulted.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnChannelFaulted(object sender, EventArgs e)
		{
			// TODO: Test to make sure sender is callback.
			IWCFClient callback = sender as IWCFClient;
			((IClientChannel)callback).Faulted -= OnChannelFaulted;
			m_updateCallbacks.Remove(callback);
		}
		#endregion

		#region Remote Functions
		/// <summary>
		/// Stops the server from the remote.
		/// </summary>
		public void Stop()
		{
			ServerInstance.Instance.Stop();
		}

		/// <summary>
		/// Saves the server from the remote.
		/// </summary>
		public void Save()
		{
			ServerInstance.Instance.Save();
		}

		/// <summary>
		/// Registers a remote for streaming updates.
		/// </summary>
		public void RegisterForUpdates()
		{
			IWCFClient callback = OperationContext.Current.
			   GetCallbackChannel<IWCFClient>();
			((IClientChannel)callback).Faulted += OnChannelFaulted;

			if (callback != null)
			{
				m_updateCallbacks.Add(callback);

				// Send initial update.
				callback.ServerStateUpdate(ServerInstance.Instance.GetInfo());
			}
		}

		/// <summary>
		/// Sends a Chat Message to the server from the remote.
		/// </summary>
		/// <param name="message"></param>
		public void SendChatMessage(ChatMessage message)
		{
			ServerInstance.Instance.SendChatMessage(message);
		}
		#endregion

	}
}
