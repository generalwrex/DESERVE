using DESERVE.ReflectionWrappers;
using DESERVE.ReflectionWrappers.SandboxGameWrappers;
using Sandbox.ModAPI;
using Sandbox.ModAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DESERVE.API
{
	public class DeservePlayerCollection : ReflectionClassWrapper, IMyPlayerCollection
	{
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
		public DeservePlayerCollection(String Namespace)
			: base(SandboxGameWrapper.Assembly, Namespace, Class)
		{
		}
		#endregion

		#region Interface Implimentation
		public long Count { get { throw new NotImplementedException(); } }

		public void ExtendControl(IMyControllableEntity entityWithControl, IMyEntity entityGettingControl) { throw new NotImplementedException(); }

		public void GetPlayers(List<IMyPlayer> players, Func<IMyPlayer, bool> collect = null) { throw new NotImplementedException(); }

		public bool HasExtendedControl(IMyControllableEntity firstEntity, IMyEntity secondEntity) { throw new NotImplementedException(); }

		public void ReduceControl(IMyControllableEntity entityWhichKeepsControl, IMyEntity entityWhichLoosesControl) { throw new NotImplementedException(); }

		public void RemoveControlledEntity(IMyEntity entity) { throw new NotImplementedException(); }

		public void TryExtendControl(IMyControllableEntity entityWithControl, IMyEntity entityGettingControl) { throw new NotImplementedException(); }

		public bool TryReduceControl(IMyControllableEntity entityWhichKeepsControl, IMyEntity entityWhichLoosesControl) { throw new NotImplementedException(); }

		public void SetControlledEntity(ulong steamUserId, IMyEntity entity) { throw new NotImplementedException(); }

		public IMyPlayer GetPlayerControllingEntity(IMyEntity entity) { throw new NotImplementedException(); }

		public void GetAllIdentites(List<IMyIdentity> identities) { throw new NotImplementedException(); }
		#endregion
	}
}
