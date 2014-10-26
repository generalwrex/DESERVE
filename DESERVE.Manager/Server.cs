using DESERVE.Managers;

using DESERVE.Manager.Marshall;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace DESERVE.Manager
{
	public class Server : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		#region Fields
		private IServerMarshall m_clientMarshall;
		private DESERVEEventHandler m_eventHandler;
		private static ServerInstance m_serverInstance;
		#endregion


		#region Properties
		public string Name { get; set; }
		public bool IsRunning { get; set; }
		public IServerMarshall Instance { get; set; }
		public DESERVEEventHandler Events { get; set; }
		public CommandLineArgs Arguments { get; set; }
		public string ArgumentsString { get; set; }
		#endregion

		protected void OnPropertyChanged(string name)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(name));
			}
		}

		#region Methods
		public bool ConnectToServer(string instanceName)
		{
			m_serverInstance = Services.Instance.ConnectToPipe(instanceName);

			if (m_serverInstance == null)
				return false;

			if (m_serverInstance.ServerMarshall == null)
				return false;

			m_clientMarshall = m_serverInstance.ServerMarshall;
			m_eventHandler = m_serverInstance.ServerEvents;
			

			this.Instance = m_clientMarshall;
			this.Name = m_clientMarshall.get_Name();
			this.IsRunning = m_clientMarshall.get_IsRunning();
			this.Arguments = m_clientMarshall.get_Arguments();
			this.ArgumentsString = Arguments.FullString;

			m_eventHandler.ServerStarted += m_eventHandler_ServerStarted;
			m_eventHandler.ServerStopped += m_eventHandler_ServerStopped;

			return true;
		}

		void m_eventHandler_ServerStopped()
		{
			this.IsRunning = false;
			OnPropertyChanged("IsRunning");
		}

		void m_eventHandler_ServerStarted()
		{
			this.IsRunning = true;
			OnPropertyChanged("IsRunning");
		}

		public void StopServer()
		{
			m_clientMarshall.Stop();
		}

		public void Save()
		{
			m_clientMarshall.Save();
			OnPropertyChanged("WorldSaved");
		}

		public void WriteToConsole(string message)
		{
			m_clientMarshall.WriteToConsole(message);
		}


		#endregion
	}
}

