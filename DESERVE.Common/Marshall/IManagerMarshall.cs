using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using System.ServiceModel;
using System.Reflection;

namespace DESERVE.Common.Marshall
{
	[ServiceContract]
	public interface IManagerMarshall
	{
		[OperationContract]
		void ReportInstanceName(string instanceName);
	}
}
