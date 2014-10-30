using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Collections.ObjectModel;

namespace DESERVE.Common
{
	[DataContract]
	public class ServerInfo
	{
		#region Properties
		[DataMember]
		public virtual String Name { get; set; }
		[DataMember]
		public virtual Boolean IsRunning { get; set; }
		[DataMember]
		public virtual ObservableCollection<Player> CurrentPlayers { get; set; }
		[DataMember]
		public virtual TimeSpan Uptime { get; set; }
		[DataMember]
		public virtual DateTime LastSave { get; set; }
		[DataMember]
		public virtual ObservableCollection<ChatMessage> ChatMessages { get; set; }

		#endregion

		public ServerInfo(String name, Boolean isRunning, ObservableCollection<Player> currentPlayers, TimeSpan uptime, DateTime lastSave, ObservableCollection<ChatMessage> chatMessages)
		{
			Name = name;
			IsRunning = isRunning;
			CurrentPlayers = currentPlayers;
			Uptime = uptime;
			LastSave = lastSave;
			ChatMessages = chatMessages;
		}

		public ServerInfo() { }
	}

	public delegate void ServerStateEvent();

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

		/// <summary>
		/// Used to request server information from the server.
		/// </summary>
		[OperationContract(IsOneWay = true)]
		void RequestUpdate();

		[OperationContract(IsOneWay = true)]
		void SendChatMessage(ChatMessage message);

	}

	public interface IWCFClient
	{
		/// <summary>
		///
		/// </summary>
		/// <param name="serverInfo"></param>
		[OperationContract(IsOneWay = true)]
		void ServerUpdate(ServerInfo serverInfo);
	}
}
