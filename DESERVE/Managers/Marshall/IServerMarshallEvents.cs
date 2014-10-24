using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SteamSDK;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace DESERVE.Managers
{
	public interface IServerMarshallEvents
	{

		[OperationContract(IsOneWay = true)]
		void OnChatRecieved(ulong remoteUserId, string message, ChatEntryTypeEnum entryType);


	}
}
