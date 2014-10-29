using DESERVE.Managers;
using System;
using System.Reflection;

namespace DESERVE.ReflectionWrappers.SandboxGameWrappers
{
	public class WorldResourceManager : ReflectionClassWrapper
	{
		private const String Class = "15B6B94DB5BE105E7B58A34D4DC11412";

		private ReflectionMethod m_saveSnapshot;

		public override String ClassName { get { return "WorldResourceManager"; } }
		public override String AssemblyName { get { return "Sandbox.Game"; } }

		public WorldResourceManager(Assembly Assembly, String Namespace)
			: base(Assembly, Namespace, Class)
		{
			SetupReflection();
		}

		private void SetupReflection()
		{
			try
			{
				m_saveSnapshot = new ReflectionMethod("C0CFAF4B58402DABBB39F4A4694795D0", ClassName, m_classType);
			}
			catch (ArgumentException ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole(ex.ToString());
			}
		}

		public Boolean SaveSnapshot(Object obj)
		{
			return (Boolean)m_saveSnapshot.Call(obj, null);
		}
	}
}
