using System;
using System.Runtime.Serialization;
using System.ServiceModel;

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
		public virtual Int32 CurrentPlayers { get; set; }
		[DataMember]
		public virtual TimeSpan Uptime { get; set; }
		[DataMember]
		public virtual DateTime LastSave { get; set; }
		#endregion

		public ServerInfo(String name, Boolean isRunning, Int32 currentPlayers, TimeSpan uptime, DateTime lastSave)
		{
			Name = name;
			IsRunning = isRunning;
			CurrentPlayers = currentPlayers;
			Uptime = uptime;
			LastSave = lastSave;
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


	}

	public interface IWCFClient
	{
		/// <summary>
		///
		/// </summary>
		/// <param name="serverInfo"></param>
		[OperationContract(IsOneWay = true)]
		void ServerUpdate(ServerInfo serverInfo);

		[OperationContract(IsOneWay = true)]
		void ClosePipe();
	}
}
