using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SEEDS.ReflectionWrappers.SandboxGameWrappers
{
	class MainGame : ReflectionClassWrapper
	{
		#region Fields
		private const String Class = "B3531963E948FB4FA1D057C4340C61B4";
		private const String Instance = "392503BDB6F8C1E34A232489E2A0C6D4";
		private const String SignalShutdownMethod = "DA95E633B86E22CF269880CE57124695";
		#endregion

		#region Properties
		#endregion

		#region Methods
		public MainGame(Assembly Assembly, String Namespace)
			: base(Assembly, Namespace, Class)
		{
		}
		#endregion

		public void SignalShutdown()
		{
			CallObjectMethod(GetStaticFieldValue(Instance), SignalShutdownMethod, new Object[] { });
		}
	}
}
