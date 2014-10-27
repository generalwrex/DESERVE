using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace DESERVE.Common.Marshall
{
	public interface IServerMarshallCallbacks
	{
		#region Event Callbacks
		[OperationContract(IsOneWay = true)]
		void OnChatMessage(ulong remoteUserId, string message);

		[OperationContract(IsOneWay = true)]
		void IsSavingChanged(bool isSaving);

		[OperationContract(IsOneWay = true)]
		void OnServerStopped();

		[OperationContract(IsOneWay = true)]
		void OnServerStarted();
		#endregion
	}
}
