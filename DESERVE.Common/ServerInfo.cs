using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Collections.ObjectModel;

namespace DESERVE.Common
{
	[DataContract]
	public class ServerInfo : ServerInfoPartial
	{
		#region Properties
		[DataMember]
		public virtual String Name { get; set; }
		[DataMember]
		public virtual ObservableCollection<Player> CurrentPlayers { get; set; }
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

	[DataContract]
	public class ServerInfoPartial
	{
		#region Properties
		[DataMember]
		public virtual Boolean IsRunning { get; set; }
		[DataMember]
		public virtual TimeSpan Uptime { get; set; }
		[DataMember]
		public virtual DateTime LastSave { get; set; }
		#endregion
	}
}
