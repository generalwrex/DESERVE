using DESERVE.Managers;
using System;

namespace DESERVE.ReflectionWrappers.SandboxGameWrappers
{
	public class ChatMessageStruct : ReflectionClassWrapper
	{
		#region Fields
		private static String Class = "12AEE9CB08C9FC64151B8A094D6BB668";

		private ReflectionField m_message;
		#endregion

		#region Properties
		public override String ClassName { get { return "ChatMessageStruct"; } }
		public override String AssemblyName { get { return "Sandbox.Game"; } }
		#endregion

		public ChatMessageStruct(System.Reflection.Assembly Assembly, String Namespace)
			: base(Assembly, Namespace, Class)
		{
			SetupReflection();
		}

		private void SetupReflection()
		{
			try
			{
				m_message = new ReflectionField("EDCBEBB604B287DFA90A5A46DC7AD28D", ClassName, m_classType);
			}
			catch (Exception ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole(ex.ToString());
			}
		}

		public Object CreateStruct(String message)
		{
			Object chatStruct = Activator.CreateInstance(m_classType);
			m_message.SetValue(chatStruct, message);

			return chatStruct;
		}
	}
}
