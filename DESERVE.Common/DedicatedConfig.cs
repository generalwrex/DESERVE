using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using System.IO;

using System.Xml;

using System.Windows.Forms;

namespace DESERVE.Common
{
	[DataContract]
	[XmlRoot("MyConfigDedicated")]
	public class DedicatedConfig
	{
		#region Fields
		private static Log ErrorLog;
		#endregion

		public DedicatedConfig()
		{
			ErrorLog = new Log(Environment.CurrentDirectory, "DESERVECommon_Errors.log");

			this.Scenario = new SerializableDefinitionId();
			this.Scenario.TypeId = "MyObjectBuilder_ScenarioDefinition";
			this.Scenario.SubtypeId = ScenarioTypeEnum.EasyStart1;
			this.SessionSettings = new SessionSettings();
			this.IP = "0.0.0.0";
			this.SteamPort = 8766;
			this.ServerPort = 27016;
			this.AsteroidAmount = 4;
			this.Administrators = new List<string>();
			this.Banned = new List<ulong>();
			this.Mods = new List<ulong>();
			this.ServerName = "";
			this.WorldName = "";


		}
		#region Properties

		[DataMember, Browsable(false)]
		public SessionSettings SessionSettings { get; set; }

		[DataMember, Browsable(false)]
		public SerializableDefinitionId Scenario { get; set; }

		#region Server Settings
		[DataMember]
		[XmlIgnore]
		public ScenarioTypeEnum ScenarioType { get { return Scenario.SubtypeId; } set { Scenario.SubtypeId = value; } }

		[DataMember]
		[XmlArrayItem("unsignedLong")]
		public List<String> Administrators { get; set; }

		[DataMember]
		[XmlArrayItem("unsignedLong")]
		public List<UInt64> Banned { get; set; }

		[DataMember]
		[XmlArrayItem("unsignedLong")]
		public List<UInt64> Mods { get; set; }

		[DataMember]
		public Int32 AsteroidAmount { get; set; }

		[DataMember]
		public UInt64 GroupID { get; set; }

		[DataMember]
		public Boolean IgnoreLastSession { get; set; }

		[DataMember]
		public String IP { get; set; }

		[DataMember]
		public String LoadWorld { get; set; }

		[DataMember]
		public Boolean PauseGameWhenEmpty { get; set; }

		[DataMember]
		public String ServerName { get; set; }

		[DataMember]
		public Int32 ServerPort { get; set; }

		[DataMember]
		public Int32 SteamPort { get; set; }

		[DataMember]
		public String WorldName { get; set; }
		#endregion

		#region Session Settings

		[DataMember]
		public float AssemblerEfficiencyMultiplier { get { return SessionSettings.AssemblerEfficiencyMultiplier; } set { SessionSettings.AssemblerEfficiencyMultiplier = value; } }

		[DataMember]
		public float AssemblerSpeedMultiplier { get { return SessionSettings.AssemblerSpeedMultiplier; } set { SessionSettings.AssemblerSpeedMultiplier = value; } }

		[DataMember]
		public bool AutoHealing { get { return SessionSettings.AutoHealing; } set { SessionSettings.AutoHealing = value; } }

		[DataMember]
		public uint AutoSaveInMinutes { get { return SessionSettings.AutoSaveInMinutes; } set { SessionSettings.AutoSaveInMinutes = value; } }

		[DataMember]
		public bool CargoShipsEnabled { get { return SessionSettings.CargoShipsEnabled; } set { SessionSettings.CargoShipsEnabled = value; } }

		[DataMember]
		public bool ClientCanSave { get { return SessionSettings.ClientCanSave; } set { SessionSettings.ClientCanSave = value; } }

		[DataMember]
		public bool EnableCopyPaste { get { return SessionSettings.EnableCopyPaste; } set { SessionSettings.EnableCopyPaste = value; } }

		[DataMember]
		public bool EnableSpectator { get { return SessionSettings.EnableSpectator; } set { SessionSettings.EnableSpectator = value; } }

		[DataMember]
		public MyEnvironmentHostilityEnum EnvironmentHostility { get { return SessionSettings.EnvironmentHostility; } set { SessionSettings.EnvironmentHostility = value; } }

		[DataMember]
		public MyGameModeEnum GameMode { get { return SessionSettings.GameMode; } set { SessionSettings.GameMode = value; } }

		[DataMember]
		public float GrinderSpeedMultiplier { get { return SessionSettings.GrinderSpeedMultiplier; } set { SessionSettings.GrinderSpeedMultiplier = value; } }

		[DataMember]
		public float HackSpeedMultiplier { get { return SessionSettings.HackSpeedMultiplier; } set { SessionSettings.HackSpeedMultiplier = value; } }

		[DataMember]
		public float InventorySizeMultiplier { get { return SessionSettings.InventorySizeMultiplier; } set { SessionSettings.InventorySizeMultiplier = value; } }

		[DataMember]
		public short MaxFloatingObjects { get { return SessionSettings.MaxFloatingObjects; } set { SessionSettings.MaxFloatingObjects = value; } }

		[DataMember]
		public short MaxPlayers { get { return SessionSettings.MaxPlayers; } set { SessionSettings.MaxPlayers = value; } }

		[DataMember]
		public MyOnlineModeEnum OnlineMode { get { return SessionSettings.OnlineMode; } set { SessionSettings.OnlineMode = value; } }

		[DataMember]
		[XmlElement(IsNullable = true)]
		public bool? PermanentDeath { get { return SessionSettings.PermanentDeath; } set { SessionSettings.PermanentDeath = value; } }

		[DataMember]
		public bool RealisticSound { get { return SessionSettings.RealisticSound; } set { SessionSettings.RealisticSound = value; } }

		[DataMember]
		public float RefinerySpeedMultiplier { get { return SessionSettings.RefinerySpeedMultiplier; } set { SessionSettings.RefinerySpeedMultiplier = value; } }

		[DataMember]
		public bool RemoveTrash { get { return SessionSettings.RemoveTrash; } set { SessionSettings.RemoveTrash = value; } }

		[DataMember]
		public bool ResetOwnership { get { return SessionSettings.ResetOwnership; } set { SessionSettings.ResetOwnership = value; } }

		[DataMember]
		public bool RespawnShipDelete { get { return SessionSettings.RespawnShipDelete; } set { SessionSettings.RespawnShipDelete = value; } }

		[DataMember]
		public bool ShowPlayerNamesOnHud { get { return SessionSettings.ShowPlayerNamesOnHud; } set { SessionSettings.ShowPlayerNamesOnHud = value; } }

		[DataMember]
		public float SpawnShipTimeMultiplier { get { return SessionSettings.SpawnShipTimeMultiplier; } set { SessionSettings.SpawnShipTimeMultiplier = value; } }

		[DataMember]
		public bool ThrusterDamage { get { return SessionSettings.ThrusterDamage; } set { SessionSettings.ThrusterDamage = value; } }

		[DataMember]
		public bool WeaponsEnabled { get { return SessionSettings.WeaponsEnabled; } set { SessionSettings.WeaponsEnabled = value; } }

		[DataMember]
		public float WelderSpeedMultiplier { get { return SessionSettings.WelderSpeedMultiplier; } set { SessionSettings.WelderSpeedMultiplier = value; } }

		[DataMember]
		public int WorldSizeKm { get { return SessionSettings.WorldSizeKm; } set { SessionSettings.WorldSizeKm = value; } }

		#endregion
		#endregion

		#region Methods

		public static DedicatedConfig SaveDedicatedConfig(string instancePath, DedicatedConfig config)
		{
			try
			{
				if (config == null)
					return null;

				string filePath = Path.Combine(instancePath, "SpaceEngineers-Dedicated.cfg");

				XmlSerializer serializer = new XmlSerializer(typeof(DedicatedConfig));
				using (TextWriter writer = new StreamWriter(filePath))
				{
					serializer.Serialize(writer, config);
				}
				return config;
			}
			catch (Exception ex)
			{
				ErrorLog.WriteLineAndConsole(ex.ToString());
				return null;
			}
		}

		public static DedicatedConfig LoadDedicatedConfig(string fullInstancePath, string instanceName)
		{
			DedicatedConfig config = new DedicatedConfig();
			try
			{
				string filePath = Path.Combine(fullInstancePath, "SpaceEngineers-Dedicated.cfg");

				if (File.Exists(filePath))
				{
					XmlSerializer deserializer = new XmlSerializer(typeof(DedicatedConfig));
					TextReader reader = new StreamReader(filePath);
					config = (DedicatedConfig)deserializer.Deserialize(reader);
					reader.Close();
					return config;
				}
				else
					return SaveDedicatedConfig(fullInstancePath, config);
			}
			catch (Exception ex)
			{
				ErrorLog.WriteLineAndConsole(ex.ToString());
				return null;
			}
		}
		#endregion
	}

	#region Dedicated Config Classes and Enums

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

		public SessionSettings()
		{
			this.GameMode = MyGameModeEnum.Survival;
			this.InventorySizeMultiplier = 1f;
			this.AssemblerSpeedMultiplier = 1f;
			this.AssemblerEfficiencyMultiplier = 1f;
			this.RefinerySpeedMultiplier = 1f;
			this.MaxPlayers = (short)4;
			this.MaxFloatingObjects = (short)256;
			this.AutoHealing = true;
			this.EnableCopyPaste = true;
			this.WeaponsEnabled = true;
			this.ShowPlayerNamesOnHud = true;
			this.ThrusterDamage = true;
			this.WorldSizeKm = 20;
			this.RespawnShipDelete = true;
			this.WelderSpeedMultiplier = 1f;
			this.GrinderSpeedMultiplier = 1f;
			this.HackSpeedMultiplier = 0.33f;
			this.PermanentDeath = new bool?(true);
			this.AutoSaveInMinutes = 5U;
			this.SpawnShipTimeMultiplier = 1f;
		}
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

	public enum ScenarioTypeEnum
	{
		EasyStart1 = 0,
		EasyStart2 = 1,
		Survival = 2,
		CrashedRedShip = 3,
		TwoPlatforms = 4,
		Asteroids = 5,
		EmptyWorld = 6,
	}

	public class SerializableDefinitionId
	{
		public ScenarioTypeEnum SubtypeId { get; set; }
		public string TypeId { get; set; }
	}

	#endregion

}
