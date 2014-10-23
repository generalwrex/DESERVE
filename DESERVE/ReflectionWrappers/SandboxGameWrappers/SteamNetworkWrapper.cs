using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DESERVE.ReflectionWrappers.SandboxGameWrappers
{
	class SteamNetworkWrapper : ReflectionClassWrapper
	{
				#region Fields
		private const string Class = "8920513CC2D9F0BEBCDC74DBD637049F";

		private const string NetworkManagerInstanceField = "8E8199A1194065205F01051DC8B72DE7";
		#endregion

		#region Events
		#endregion

		#region Properties
		public override String ClassName { get { return "SteamNetworkWrapper"; } }
		public override String AssemblyName { get { return "Sandbox.Game"; } }

		public Object NetworkManagerInstance { get { return GetStaticFieldValue(NetworkManagerInstanceField); } }
		#endregion

		#region Methods
		public SteamNetworkWrapper(Assembly Assembly, String Namespace)
			: base(Assembly, Namespace, Class)
		{
		}
		#endregion
	}
}
