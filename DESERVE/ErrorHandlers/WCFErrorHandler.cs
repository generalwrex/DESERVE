using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;

using DESERVE.Managers;


namespace DESERVE.ErrorHandlers
{
	public class WCFErrorHandler : IErrorHandler
	{
		public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
		{
			
			string formattedFault =	string.Format("Exception caught at WCFErrorHandler{0}Method: {1}{2}Message:{3}",
							 Environment.NewLine, error.TargetSite.Name, Environment.NewLine, error.Message);

			Console.WriteLine(formattedFault);
		}

		public bool HandleError(Exception error)
		{

			string formattedMessage = String.Format("Exception:{0}{1}Method: {2}{3}Message:{4}",
						error.GetType().Name, Environment.NewLine, error.TargetSite.Name,
						Environment.NewLine, error.Message + Environment.NewLine);

			LogManager.ErrorLog.WriteLine(formattedMessage);

			return true;
		}
	}
}
