using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DESERVE.Common
{
	[DataContract]
	class ChatMessage
	{
		[DataMember]
		public String Message { get; set; }
		[DataMember]
		public ulong SteamId { get; set; }
		[DataMember]
		public String Name { get; set; }
	}
}
