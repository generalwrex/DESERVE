using System;
using System.IO;

using Sandbox.Common.ObjectBuilders;
using Sandbox.Common.ObjectBuilders.Serializer;

using DESERVE.Common;

namespace DESERVE.Managers
{
	class SessionManager
	{
		#region Fields
		private static MyObjectBuilder_Checkpoint m_checkPoint;
		#endregion

		public SessionManager(string instancePath, string instanceName)
		{
			ulong fileSize = 0UL;

			LogManager.MainLog.WriteLineAndConsole("Loading Session Settings");		
			try
			{
				var config = DedicatedConfig.LoadDedicatedConfig(instancePath, instanceName);
				var worldPath = config.LoadWorld;

				LogManager.MainLog.WriteLineAndConsole("Loading Sandbox.sbc: " + worldPath);

				m_checkPoint = LoadSandbox(worldPath, out fileSize);
				if (m_checkPoint == null)
				{
					LogManager.ErrorLog.WriteLineAndConsole("Failed to deserialize Sandbox.sbc: check save name");
					return;
				}

				LogManager.MainLog.WriteLineAndConsole("Loaded Sandbox.sbc - filesize: " + fileSize);

				LogManager.MainLog.WriteLineAndConsole("Applying SessionSettings From DedicatedConfig");
				

				#region SessionSettings
				m_checkPoint.Password = config.Password;

				m_checkPoint.Mods.Clear();
				foreach (ulong modid in config.Mods)
					m_checkPoint.Mods.Add(new MyObjectBuilder_Checkpoint.ModItem(modid));

				m_checkPoint.Scenario.TypeId = MyObjectBuilderType.Parse(config.Scenario.TypeId);
				m_checkPoint.Scenario.SubtypeId = config.Scenario.SubtypeId.ToString();

				var configSession = config.SessionSettings;

				m_checkPoint.Settings.GameMode = (Sandbox.Common.ObjectBuilders.MyGameModeEnum)configSession.GameMode;
				m_checkPoint.Settings.EnvironmentHostility = (Sandbox.Common.ObjectBuilders.MyEnvironmentHostilityEnum)configSession.EnvironmentHostility;
				m_checkPoint.Settings.OnlineMode = (Sandbox.Common.ObjectBuilders.MyOnlineModeEnum)configSession.OnlineMode;

				m_checkPoint.Settings.AssemblerEfficiencyMultiplier = configSession.AssemblerEfficiencyMultiplier;
				m_checkPoint.Settings.AssemblerSpeedMultiplier = configSession.AssemblerSpeedMultiplier;
				m_checkPoint.Settings.AutoHealing = configSession.AutoHealing;
				m_checkPoint.Settings.AutoSave = configSession.AutoSave;
				m_checkPoint.Settings.AutoSaveInMinutes = configSession.AutoSaveInMinutes;
				m_checkPoint.Settings.CargoShipsEnabled = configSession.CargoShipsEnabled;
				m_checkPoint.Settings.ClientCanSave = configSession.ClientCanSave;
				m_checkPoint.Settings.EnableCopyPaste = configSession.EnableCopyPaste;
				m_checkPoint.Settings.EnableSpectator = configSession.EnableSpectator;			
				m_checkPoint.Settings.GrinderSpeedMultiplier = configSession.GrinderSpeedMultiplier;
				m_checkPoint.Settings.HackSpeedMultiplier = configSession.HackSpeedMultiplier;
				m_checkPoint.Settings.InventorySizeMultiplier = configSession.InventorySizeMultiplier;
				m_checkPoint.Settings.MaxFloatingObjects = configSession.MaxFloatingObjects;
				m_checkPoint.Settings.MaxPlayers = configSession.MaxPlayers;
				m_checkPoint.Settings.PermanentDeath = configSession.PermanentDeath;
				m_checkPoint.Settings.RealisticSound = configSession.RealisticSound;
				m_checkPoint.Settings.RefinerySpeedMultiplier = configSession.RefinerySpeedMultiplier;
				m_checkPoint.Settings.RemoveTrash = configSession.RemoveTrash;
				m_checkPoint.Settings.ResetOwnership = configSession.ResetOwnership;
				m_checkPoint.Settings.RespawnShipDelete = configSession.RespawnShipDelete;
				m_checkPoint.Settings.ShowPlayerNamesOnHud = configSession.ShowPlayerNamesOnHud;
				m_checkPoint.Settings.SpawnShipTimeMultiplier = configSession.SpawnShipTimeMultiplier;
				m_checkPoint.Settings.ThrusterDamage = configSession.ThrusterDamage;
				m_checkPoint.Settings.WeaponsEnabled = configSession.WeaponsEnabled;
				m_checkPoint.Settings.WelderSpeedMultiplier = configSession.WelderSpeedMultiplier;
				m_checkPoint.Settings.WorldSizeKm = configSession.WorldSizeKm;
				#endregion

				SaveSandbox(m_checkPoint, worldPath, out fileSize);
				LogManager.MainLog.WriteLineAndConsole("Saved Sandbox.sbc - new filesize: " + fileSize + Environment.NewLine);

				LogManager.MainLog.WriteLineAndConsole("Max Players: " + m_checkPoint.Settings.MaxPlayers);
				LogManager.MainLog.WriteLineAndConsole("OnlineMode: " + m_checkPoint.Settings.OnlineMode);
				LogManager.MainLog.WriteLineAndConsole("GameMode: " + m_checkPoint.Settings.GameMode);
				LogManager.MainLog.WriteLineAndConsole("Scenario: " + m_checkPoint.Scenario.SubtypeId);
				LogManager.MainLog.WriteLineAndConsole("World Size: " + m_checkPoint.Settings.WorldSizeKm + Environment.NewLine);
				LogManager.MainLog.WriteLineAndConsole("Loading Session Settings - END");
			}
			catch (Exception ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole("Session Manager Exception: " + ex.ToString());
				return;
			}
		}

		#region Methods
		public static MyObjectBuilder_Checkpoint LoadSandbox(string savePath, out ulong fileSize)
		{
			fileSize = 0UL;
			string path = Path.Combine(savePath,"Sandbox.sbc");

			if (!File.Exists(path))
				return (MyObjectBuilder_Checkpoint)null;

			MyObjectBuilder_Checkpoint objectBuilder = (MyObjectBuilder_Checkpoint)null;

			MyObjectBuilderSerializer.DeserializeXML<MyObjectBuilder_Checkpoint>(path, out objectBuilder, out fileSize);

			if (objectBuilder != null && string.IsNullOrEmpty(objectBuilder.SessionName))
				objectBuilder.SessionName = Path.GetFileNameWithoutExtension(path);

			return objectBuilder;
		}

		public static bool SaveSandbox(MyObjectBuilder_Checkpoint objectBuilder, string savePath, out ulong fileSize)
		{
			string path = Path.Combine(savePath, "Sandbox.sbc");
		
			return MyObjectBuilderSerializer.SerializeXML(path, false, (MyObjectBuilder_Base)objectBuilder, out fileSize, (Type)null);
		}

		#endregion




	}
}
