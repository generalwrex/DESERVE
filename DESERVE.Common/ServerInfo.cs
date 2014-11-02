using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace DESERVE.Common
{
	[DataContract]
	public class ServerInfo : ServerInfoPartial
	{
		#region Properties
		[DataMember]
		public virtual String Name { get; set; }
		[DataMember]
		public virtual List<Player> CurrentPlayers { get; set; }
		[DataMember]
		public virtual List<ChatMessage> ChatMessages { get; set; }
		#endregion

		public ServerInfo(String name, Boolean isRunning, List<Player> currentPlayers, TimeSpan uptime, DateTime lastSave, List<ChatMessage> chatMessages)
			: base(isRunning, uptime, lastSave)
		{
			Name = name;
			CurrentPlayers = currentPlayers;
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

		public ServerInfoPartial(Boolean isRunning, TimeSpan uptime, DateTime lastSave)
		{
			IsRunning = isRunning;
			Uptime = uptime;
			LastSave = lastSave;
		}

		public ServerInfoPartial() { }
		#endregion
	}
}
