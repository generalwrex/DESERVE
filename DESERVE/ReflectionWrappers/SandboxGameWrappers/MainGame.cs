using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DESERVE.ReflectionWrappers.SandboxGameWrappers
{
	class MainGame : ReflectionClassWrapper
	{
		#region Fields
		private const String Class = "B3531963E948FB4FA1D057C4340C61B4";
		private const String InstanceField = "392503BDB6F8C1E34A232489E2A0C6D4";
		private const String SignalShutdownMethod = "DA95E633B86E22CF269880CE57124695";
		private const String EnqueueActionMethod = "0172226C0BA7DAE0B1FCE0AF8BC7F735";
		private const String RegisterOnLoadedMethod = "5D7D384DD47365A043F15CD321FBEC53";
		#endregion

		#region Properties
		public override String ClassName { get { return "MainGame"; } }
		public override String AssemblyName { get { return "Sandbox.Game"; } }

		public Object Instance { get { return GetStaticFieldValue(InstanceField); } }
		#endregion

		#region Methods
		public MainGame(Assembly Assembly, String Namespace)
			: base(Assembly, Namespace, Class)
		{
		}

		public void SignalShutdown()
		{
			CallObjectMethod(Instance, SignalShutdownMethod, new Object[] { });
		}

		public void EnqueueAction(Action action)
		{
			CallObjectMethod(Instance, EnqueueActionMethod, new Object[] { action });
		}

		public void RegisterOnLoadedAction(Action action)
		{
			CallStaticMethod(RegisterOnLoadedMethod, new Object[] { action });
		}
		#endregion

	}
}
