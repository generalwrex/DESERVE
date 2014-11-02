using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace DESERVE.Common
{
	/// <summary>
	/// IWCFService is implimented by DESERVE.
	/// </summary>
	[ServiceContract(SessionMode = SessionMode.Required,
	CallbackContract = typeof(IWCFClient))]
	public interface IWCFService
	{
		[OperationContract]
		ServerInfo Connect();

		[OperationContract(IsOneWay = true)]
		void Disconnect();

		[OperationContract(IsOneWay = true)]
		void Stop();

		[OperationContract(IsOneWay = true)]
		void Save();

		[OperationContract(IsOneWay = true)]
		void SendChatMessage(ChatMessage message);
	}

	/// <summary>
	/// IWCFClient is implimented by managers to talk to DESERVE servers.
	/// </summary>
	public interface IWCFClient
	{
		[OperationContract(IsOneWay = true)]
		void UpdateServerInfo(ServerInfoPartial serverInfo);

		[OperationContract(IsOneWay = true)]
		void ChatMessageUpdate(ChatMessage message);

		[OperationContract(IsOneWay = true)]
		void PlayerUpdate(Player player, PlayerAction action);
	}
}
