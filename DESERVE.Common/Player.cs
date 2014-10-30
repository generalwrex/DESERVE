using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DESERVE.Common
{
	[DataContract]
	public class Player
	{
		[DataMember]
		public String Name { get; set; }
		[DataMember]
		public ulong SteamId { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}
