using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Runtime.Serialization;
using SysUtils.Utils;
using VRage.Common.Utils;

namespace SEEDS
{
	[DataContract]
	class ServerInstance
	{
		#region Fields
		private string saveFile;
		private Thread m_serverThread;
		private DedicatedServerWrapper m_server;

		#endregion

		#region Properties
		#endregion
		
		#region Methods

		public ServerInstance(string saveFile)
		{
			this.saveFile = saveFile;
			m_server = new DedicatedServerWrapper();
		}

		public void Start()
		{

			object[] args = new object[]
				{
					"Project Vengeance",
					"",
					true,
					true
				};

			MethodInfo startupMethod = DedicatedServerWrapper.DedicatedServerStartupMethod;
			m_serverThread = new Thread(new ParameterizedThreadStart(this.ThreadStart));

			m_serverThread.IsBackground = true;
			m_serverThread.CurrentCulture = CultureInfo.InvariantCulture;
			m_serverThread.CurrentUICulture = CultureInfo.InvariantCulture;
			m_serverThread.Start((object)args);
		}

		public void Stop()
		{
			DedicatedServerWrapper.DedicatedServerShutdownMethod.Invoke(DedicatedServerWrapper.MainGameInstanceField.GetValue(null), null);
			m_serverThread.Join(60000);
			m_serverThread.Abort();
		}

		private void ThreadStart(object args)
		{
			try
			{
				if (MyLog.Default != null)
					MyLog.Default.Close();
				MyFileSystem.Reset(); 
				DedicatedServerWrapper.DedicatedServerNullRenderField.SetValue(null, true);
				DedicatedServerWrapper.DedicatedServerStartupMethod.Invoke(null, args as object[]);
			}
			catch (Exception ex)
			{
				int i = 0;
				i++;
			}
		}
		#endregion
	}
}
