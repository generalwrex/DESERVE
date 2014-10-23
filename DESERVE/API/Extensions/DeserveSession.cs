using DESERVE.ReflectionWrappers;
using DESERVE.ReflectionWrappers.SandboxGameWrappers;
using Sandbox.Common;
using Sandbox.Common.Localization;
using Sandbox.Common.ObjectBuilders;
using Sandbox.ModAPI;
using Sandbox.ModAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using VRage;

namespace DESERVE.API
{
	public class DeserveSession : ReflectionClassWrapper, IMySession
	{
		#region Wrapper
		#region Fields
		private const String Class = "";
		#endregion

		#region Events
		#endregion

		#region Properties
		public override String ClassName { get { return ""; } }
		public override String AssemblyName { get { return "Sandbox.Game"; } }
		#endregion

		#region Methods
		public DeserveSession(String Namespace)
			: base(SandboxGameWrapper.Assembly, Namespace, Class)
		{
		}
		#endregion
		#endregion

		#region Interface Implimentation
		public float AssemblerEfficiencyMultiplier { get { throw new NotImplementedException(); } }

		public float AssemblerSpeedMultiplier { get { throw new NotImplementedException(); } }

		public bool AutoHealing { get { throw new NotImplementedException(); } }

		public uint AutoSaveInMinutes { get { throw new NotImplementedException(); } }

		public IMyCameraController CameraController { get { throw new NotImplementedException(); } }

		public bool CargoShipsEnabled { get { throw new NotImplementedException(); } }

		public bool ClientCanSave { get { throw new NotImplementedException(); } }

		public bool CreativeMode { get { throw new NotImplementedException(); } }

		public string CurrentPath { get { throw new NotImplementedException(); } }

		public string Description { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

		public TimeSpan ElapsedPlayTime { get { throw new NotImplementedException(); } }

		public bool EnableCopyPaste { get { throw new NotImplementedException(); } }

		public MyEnvironmentHostilityEnum EnvironmentHostility { get { throw new NotImplementedException(); } }

		public DateTime GameDateTime { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

		public float GrinderSpeedMultiplier { get { throw new NotImplementedException(); } }

		public float HackSpeedMultiplier { get { throw new NotImplementedException(); } }

		public float InventoryMultiplier { get { throw new NotImplementedException(); } }

		public bool IsCameraAwaitingEntity { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

		public short MaxFloatingObjects { get { throw new NotImplementedException(); } }

		public short MaxPlayers { get { throw new NotImplementedException(); } }

		public bool MultiplayerAlive { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

		public bool MultiplayerDirect { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

		public double MultiplayerLastMsg { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

		public string Name { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

		public float NegativeIntegrityTotal { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

		public MyOnlineModeEnum OnlineMode { get { throw new NotImplementedException(); } }

		public string Password { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

		public float PositiveIntegrityTotal { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

		public float RefinerySpeedMultiplier { get { throw new NotImplementedException(); } }

		public bool ShowPlayerNamesOnHud { get { throw new NotImplementedException(); } }

		public bool SurvivalMode { get { throw new NotImplementedException(); } }

		public bool ThrusterDamage { get { throw new NotImplementedException(); } }

		public string ThumbPath { get { throw new NotImplementedException(); } }

		public TimeSpan TimeOnBigShip { get { throw new NotImplementedException(); } }

		public TimeSpan TimeOnFoot { get { throw new NotImplementedException(); } }

		public TimeSpan TimeOnJetpack { get { throw new NotImplementedException(); } }

		public TimeSpan TimeOnSmallShip { get { throw new NotImplementedException(); } }

		public bool WeaponsEnabled { get { throw new NotImplementedException(); } }

		public float WelderSpeedMultiplier { get { throw new NotImplementedException(); } }

		public ulong? WorkshopId { get { throw new NotImplementedException(); } }

		public string WorldID { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

		public IMyVoxelMaps VoxelMaps { get { throw new NotImplementedException(); } }

		public IMyPlayer Player { get { throw new NotImplementedException(); } }

		public IMyControllableEntity ControlledObject { get { throw new NotImplementedException(); } }

		public void BeforeStartComponents() { throw new NotImplementedException(); }

		public void Draw() { throw new NotImplementedException(); }

		public void GameOver() { throw new NotImplementedException(); }

		public void GameOver(MyTextsWrapperEnum? customMessage) { throw new NotImplementedException(); }

		public MyObjectBuilder_Checkpoint GetCheckpoint(string saveName) { throw new NotImplementedException(); }

		public MyObjectBuilder_Sector GetSector() { throw new NotImplementedException(); }

		public Dictionary<string, byte[]> GetVoxelMapsArray() { throw new NotImplementedException(); }

		public MyObjectBuilder_World GetWorld() { throw new NotImplementedException(); }

		public bool IsPausable() { throw new NotImplementedException(); }

		public void RegisterComponent(MySessionComponentBase component, MyUpdateOrder updateOrder, int priority) { throw new NotImplementedException(); }

		public bool Save(string customSaveName = null) { throw new NotImplementedException(); }

		public void SetAsNotReady() { throw new NotImplementedException(); }

		public void Unload() { throw new NotImplementedException(); }

		public void UnloadDataComponents() { throw new NotImplementedException(); }

		public void UnloadMultiplayer() { throw new NotImplementedException(); }

		public void UnregisterComponent(MySessionComponentBase component) { throw new NotImplementedException(); }

		public void Update(MyTimeSpan time) { throw new NotImplementedException(); }

		public void UpdateComponents() { throw new NotImplementedException(); }
		#endregion
	}
}
