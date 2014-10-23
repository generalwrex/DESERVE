using DESERVE.ReflectionWrappers.DedicatedServerWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DESERVE.ReflectionWrappers.DedicatedServerWrappers
{
	class DedicatedServerWrapper : ReflectionAssemblyWrapper
	{
		#region Fields
		private const string DedicatedServerNamespace = "83BCBFA49B3A2A6EC1BC99583DA2D399";

		private static Program m_program;
		#endregion

		#region Properties
		public static Program Program { get { return m_program; } }
		#endregion

		#region Methods
		public DedicatedServerWrapper(Assembly dedicatedServerAssembly)
			: base(dedicatedServerAssembly)
		{
			String EntryPoint = dedicatedServerAssembly.EntryPoint.Name;
			m_program = new Program(dedicatedServerAssembly, DedicatedServerNamespace);
		}


		internal void Init()
		{
			m_program.Init();
		}
		#endregion
	}
}
