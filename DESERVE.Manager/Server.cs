using DESERVE.Managers;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

using DESERVE.Common;
using DESERVE.Common.Marshall;
using System;

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
		//specific to the list view
		public string Name { get { return Arguments.Instance; } }
		//specific to the list view
		public bool IsRunning { get; set; }
		//specific to the list view
		public string ArgumentsString { get { return Arguments.ToString(); } }


		public IServerMarshall Instance { get; set; }
		public DESERVEEventHandler Events { get; set; }
		public CommandLineArgs Arguments { get; set; }
		#endregion

		// set defaults
		public Server()
		{
			this.Arguments = new CommandLineArgs();
			this.IsRunning = false;
		}


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
			this.IsRunning = m_clientMarshall.IsRunning;
			this.Arguments = m_clientMarshall.Arguments;

			m_eventHandler.ServerStarted += m_eventHandler_ServerStarted;
			m_eventHandler.ServerStopped += m_eventHandler_ServerStopped;

			return true;
		}

		void m_eventHandler_ServerStopped()
		{
			
			OnPropertyChanged("IsRunning");
		}

		void m_eventHandler_ServerStarted()
		{
			this.IsRunning = true;
			OnPropertyChanged("IsRunning");
		}

		public void StopServer()
		{
			throw new Exception("This function hangs the server");
			m_clientMarshall.Stop();
			this.IsRunning = false;
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

