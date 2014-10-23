using DESERVE.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DESERVE.ReflectionWrappers.SandboxGameWrappers
{
	class MPSession : ReflectionClassWrapper
	{
		#region Fields
		private const String Class = "4C1ED56341F07A7D73298D03926F04DE";
		private ReflectionMethod m_apiGatewayInit;
		#endregion

		#region Properties
		public override String ClassName { get { return "MPSession"; } }
		public override String AssemblyName { get { return "Sandbox.Game"; } }
		#endregion

		#region Methods
		public MPSession(Assembly Assembly, String Namespace)
			: base(Assembly, Namespace, Class)
		{
			SetupReflection();
		}

		private void SetupReflection()
		{
			try
			{
				m_apiGatewayInit = new ReflectionMethod("0DE98737B4717615E252D27A4F3A2B44", ClassName, m_classType);
			}
			catch (ArgumentException ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole(ex.ToString());
			}
		}

		public override void Init()
		{
			if (DESERVE.Arguments.ModAPI)
			{
				m_apiGatewayInit.Call(null, null);
				LogManager.MainLog.WriteLineAndConsole("DESERVE: MyAPIGateway initialized.");
			}
		}
		#endregion
	}
}
