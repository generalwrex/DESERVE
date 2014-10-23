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
	public class DeserveTerminalActionsHelper : ReflectionClassWrapper, IMyTerminalActionsHelper
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
		public DeserveTerminalActionsHelper(String Namespace)
			: base(SandboxGameWrapper.Assembly, Namespace, Class)
		{
		}
		#endregion
		#endregion

		#region Interface Implimentation
		public void GetActions(Type blockType, List<ITerminalAction> resultList, Func<ITerminalAction, bool> collect = null) { throw new NotImplementedException(); }
		#endregion
	}
}
