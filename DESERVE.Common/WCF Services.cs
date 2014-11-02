using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace DESERVE.Common
{
	[ServiceContract(SessionMode = SessionMode.Required,
	CallbackContract = typeof(IWCFClient))]
	public interface IWCFService
	{
		/// <summary>
		/// Starts the process of stopping the server.
		/// </summary>
		[OperationContract(IsOneWay = true)]
		void Stop();

		/// <summary>
		/// Used to make the server save the game.
		/// </summary>
		[OperationContract(IsOneWay = true)]
		void Save();

		[OperationContract(IsOneWay = true)]
		void RegisterForUpdates();

		[OperationContract(IsOneWay = true)]
		void SendChatMessage(ChatMessage message);

	}

	public interface IWCFClient
	{
		[OperationContract(IsOneWay = true)]
		void ServerStateUpdate(ServerInfo serverInfo);

		[OperationContract(IsOneWay = true)]
		void ServerStateUpdatePartial(ServerInfoPartial serverInfo);

		[OperationContract(IsOneWay = true)]
		void ChatMessageUpdate(ChatMessage message);

		[OperationContract(IsOneWay = true)]
		void PlayerUpdate(Player player, PlayerAction action);
	}
}
