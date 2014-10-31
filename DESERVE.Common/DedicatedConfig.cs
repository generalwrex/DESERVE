using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace DESERVE.Common
{
	[DataContract]
	public class DedicatedConfig
	{
		[DataMember]
		List<String> Administrators { get; set; }
		[DataMember]
		Int32 AsteroidAmount { get; set; }
		[DataMember]
		List<UInt64> Banned { get; set; }
		[DataMember]
		UInt64 GroupID { get; set; }
		[DataMember]
		Boolean IgnoreLastSession { get; set; }
		[DataMember]
		String IP { get; set; }
		[DataMember]
		String LoadWorld { get; set; }
		[DataMember]
		List<UInt64> Mods { get; set; }
		[DataMember]
		Boolean PauseGameWhenEmpty { get; set; }
		[DataMember]
		SerializableDefinitionId Scenario { get; set; }
		[DataMember]
		String ServerName { get; set; }
		[DataMember]
		Int32 ServerPort { get; set; }
		[DataMember]
		SessionSettings SessionSettings { get; set; }
		[DataMember]
		Int32 SteamPort { get; set; }
		[DataMember]
		String WorldName { get; set; }
	}

	public class SessionSettings
	{
		public float AssemblerEfficiencyMultiplier;
		public float AssemblerSpeedMultiplier;
		public bool AutoHealing;
		public uint AutoSaveInMinutes;
		public bool CargoShipsEnabled;
		public bool ClientCanSave;
		public bool EnableCopyPaste;
		public bool EnableSpectator;
		public MyEnvironmentHostilityEnum EnvironmentHostility;
		public MyGameModeEnum GameMode;
		public float GrinderSpeedMultiplier;
		public float HackSpeedMultiplier;
		public float InventorySizeMultiplier;
		public short MaxFloatingObjects;
		public short MaxPlayers;
		public MyOnlineModeEnum OnlineMode;
		public bool? PermanentDeath;
		public bool RealisticSound;
		public float RefinerySpeedMultiplier;
		public bool RemoveTrash;
		public bool ResetOwnership;
		public bool RespawnShipDelete;
		public bool ShowPlayerNamesOnHud;
		public float SpawnShipTimeMultiplier;
		public bool ThrusterDamage;
		public bool WeaponsEnabled;
		public float WelderSpeedMultiplier;
		public int WorldSizeKm;

		public bool AutoSave { get; set; }
	}

	public enum MyEnvironmentHostilityEnum
	{
		SAFE = 0,
		NORMAL = 1,
		CATACLYSM = 2,
		CATACLYSM_UNREAL = 3,
	}

	public enum MyGameModeEnum
	{
		Creative = 0,
		Survival = 1,
	}

	public enum MyOnlineModeEnum
	{
		OFFLINE = 0,
		PUBLIC = 1,
		FRIENDS = 2,
		PRIVATE = 3,
	}

	public struct SerializableDefinitionId
	{
		public string SubtypeId { get; set; }
		[XmlElement("TypeId")]
		public string TypeIdString { get; set; }
	}
}
