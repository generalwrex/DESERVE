using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using DESERVE.ReflectionWrappers;

namespace DESERVE.ReflectionWrappers
{
	class ReflectionAssemblyWrapper
	{
		#region Fields
		protected static Assembly m_assembly;
		#endregion

		#region Properties
		public static Assembly Assembly { get { return m_assembly; } }
		#endregion

		#region Methods

		public ReflectionAssemblyWrapper(Assembly assembly)
		{
			m_assembly = assembly;
		}
		#endregion
	}
}
