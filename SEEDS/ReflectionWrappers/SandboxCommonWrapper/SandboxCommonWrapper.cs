using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SEEDS.ReflectionWrappers.SandboxCommonWrapper
{
	class SandboxCommonWrapper : ReflectionAssemblyWrapper
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods
		public SandboxCommonWrapper()
			: base(Assembly.UnsafeLoadFrom("Sandbox.Common.dll"))
		{

		}
		#endregion
	}
}
