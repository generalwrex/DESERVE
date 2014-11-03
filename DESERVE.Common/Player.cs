using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DESERVE.Common
{
	public enum PlayerAction
	{
		Joined,
		Entered,
		Left,
		Kicked,
		Banned,
	}

	[DataContract]
	public struct Player
	{
		[DataMember]
		public String Name { get; set; }
		[DataMember]
		public ulong SteamId { get; set; }

		public override string ToString()
		{
			return (String.IsNullOrEmpty(Name) ? SteamId.ToString() : Name);
		}

		public static bool operator ==(Player p1, Player p2)
		{
			if (Object.ReferenceEquals(p1, p2))
			{
				return true;
			}

			if (((object)p1 == null) || ((object)p2 == null))
			{
				return false;
			}
			return p1.SteamId == p2.SteamId;
		}

		public static bool operator !=(Player p1, Player p2)
		{
			return !(p1 == p2);
		}

		public override bool Equals(object obj)
		{
			if (obj is Player)
			{
				return this == (Player)obj;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (int)SteamId;
		}
	}
}
