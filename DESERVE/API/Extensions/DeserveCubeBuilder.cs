using DESERVE.ReflectionWrappers;
using DESERVE.ReflectionWrappers.SandboxGameWrappers;
using Sandbox.Common.ObjectBuilders;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using VRageMath;

namespace DESERVE.API
{
	public class DeserveCubeBuilder : ReflectionClassWrapper, IMyCubeBuilder
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
		public DeserveCubeBuilder(String Namespace)
			: base(SandboxGameWrapper.Assembly, Namespace, Class)
		{
		}
		#endregion
		#endregion

		#region InterfaceImplimentation
		public bool BlockCreationIsActivated { get { throw new NotImplementedException(); } }

		public bool CopyPasteIsActivated { get { throw new NotImplementedException(); } }

		public bool FreezeGizmo { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

		public bool ShipCreationIsActivated { get { throw new NotImplementedException(); } }

		public bool ShowRemoveGizmo { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

		public bool UseSymmetry { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

		public bool UseTransparency { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

		public bool IsActivated { get { throw new NotImplementedException(); } }

		public void Activate() { throw new NotImplementedException(); }

		public void ActivateShipCreationClipboard(MyObjectBuilder_CubeGrid grid, Vector3 centerDeltaDirection, float dragVectorLength) { throw new NotImplementedException(); }

		public void ActivateShipCreationClipboard(MyObjectBuilder_CubeGrid[] grids, Vector3 centerDeltaDirection, float dragVectorLength) { throw new NotImplementedException(); }

		public bool AddConstruction(IMyEntity buildingEntity) { throw new NotImplementedException(); }

		public void Deactivate() { throw new NotImplementedException(); }

		public void DeactivateBlockCreation() { throw new NotImplementedException(); }

		public void DeactivateCopyPaste() { throw new NotImplementedException(); }

		public void DeactivateShipCreationClipboard() { throw new NotImplementedException(); }

		public void StartNewGridPlacement(MyCubeSize cubeSize, bool isStatic) { throw new NotImplementedException(); }

		public IMyCubeGrid FindClosestGrid() { throw new NotImplementedException(); }
		#endregion
	}
}
