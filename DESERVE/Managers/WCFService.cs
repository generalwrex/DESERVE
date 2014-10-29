using DESERVE.Common;
using System;
using System.ServiceModel;
using System.Threading;

namespace DESERVE.Managers
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	class WCFService : IWCFService
	{
		public String Uri { get { return "net.pipe://localhost/DESERVE/" + m_instanceName; } }
		private string m_instanceName;

		public WCFService(String instanceName)
		{
			m_instanceName = instanceName;
		}

		public void Stop()
		{
			ThreadPool.QueueUserWorkItem((object state) => ServerInstance.Instance.Stop());
		}

		public void Save()
		{
			ThreadPool.QueueUserWorkItem((object state) => ServerInstance.Instance.Save());
		}

		public void RequestUpdate()
		{
			var callback = OperationContext.Current.GetCallbackChannel<IWCFClient>();
			if (callback != null)
			{
				callback.ServerUpdate(ServerInstance.Instance as IServerInstance);
			}
		}
	}
}
