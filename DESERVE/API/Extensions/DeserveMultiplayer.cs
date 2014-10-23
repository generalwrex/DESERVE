using DESERVE.ReflectionWrappers;
using DESERVE.ReflectionWrappers.SandboxGameWrappers;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DESERVE.API
{
	public class DeserveMultiplayer : ReflectionClassWrapper, IMyMultiplayer
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
		public DeserveMultiplayer(String Namespace)
			: base(SandboxGameWrapper.Assembly, Namespace, Class)
		{
		}
		#endregion

		#region Interface Implimentation
		public bool MultiplayerActive { get { throw new NotImplementedException(); } }

		public bool IsServer { get { throw new NotImplementedException(); } }

		public ulong ServerId { get { throw new NotImplementedException(); } }

		public ulong MyId { get { throw new NotImplementedException(); } }

		public string MyName { get { throw new NotImplementedException(); } }

		public IMyPlayerCollection Players { get { throw new NotImplementedException(); } }

		public bool IsServerPlayer(IMyNetworkClient player) { throw new NotImplementedException(); }
		#endregion
	}
}
