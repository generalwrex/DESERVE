using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;

using DESERVE;

using DESERVE.Managers;

using DESERVE.Manager.Dialogs;

namespace DESERVE.Manager.ErrorHandlers
{
	public class WCFErrorHandler : IErrorHandler
	{
		public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
		{
			new ManagerException(error);
		}

		public bool HandleError(Exception error)
		{
			
			return true;
		}
	}
}
