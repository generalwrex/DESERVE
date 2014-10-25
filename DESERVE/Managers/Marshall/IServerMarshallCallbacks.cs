using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SteamSDK;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace DESERVE.Managers
{
	public interface IServerMarshallCallbacks
	{

		[OperationContract(IsOneWay = true)]
		void ChatMessageReceived(ulong remoteUserId, string message);

	}
}
