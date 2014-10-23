using DESERVE.ReflectionWrappers;
using DESERVE.ReflectionWrappers.SandboxGameWrappers;
using Sandbox.Common;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DESERVE.API
{
	public class DeserveUtilities : ReflectionClassWrapper, IMyUtilities
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
		public DeserveUtilities(String Namespace)
			: base(SandboxGameWrapper.Assembly, Namespace, Class)
		{
		}
		#endregion

		#region Interface Implimentation
		public IMyConfigDedicated ConfigDedicated { get { throw new NotImplementedException(); } }

		public IMyGamePaths GamePaths { get { throw new NotImplementedException(); } }

		public event MessageEnteredDel MessageEntered;

		public string GetTypeName(Type type) { throw new NotImplementedException(); }

		public void ShowNotification(string message, int disappearTimeMs = 2000, MyFontEnum font = MyFontEnum.White) { throw new NotImplementedException(); }

		public void ShowMessage(string sender, string messageText) { throw new NotImplementedException(); }

		public void SendMessage(string messageText) { throw new NotImplementedException(); }

		public TextReader ReadFileInGlobalStorage(string file) { throw new NotImplementedException(); }

		public TextReader ReadFileInLocalStorage(string file, Type callingType) { throw new NotImplementedException(); }

		public TextWriter WriteFileInGlobalStorage(string file) { throw new NotImplementedException(); }

		public TextWriter WriteFileInLocalStorage(string file, Type callingType) { throw new NotImplementedException(); }
		#endregion
	}
}
