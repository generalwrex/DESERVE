using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DESERVE.Common
{
	[DataContract]
	public class ChatMessage
	{
		[DataMember]
		public String Message { get; set; }
		[DataMember]
		public ulong SteamId { get; set; }
		[DataMember]
		public String Name { get; set; }
		[DataMember]
		public DateTime Timestamp { get; set; }

		public override String ToString()
		{
			return String.Format("[{0}] {1}: {2}", Timestamp.ToString("HH:mm:ss"), Name, Message);
		}

		public ChatMessage()
		{
			Message = "";
			SteamId = 0;
			Name = "";
			Timestamp = DateTime.MinValue;
		}
	}
}
