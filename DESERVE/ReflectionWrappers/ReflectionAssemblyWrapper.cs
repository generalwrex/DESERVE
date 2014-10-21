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
		protected Assembly m_assembly;
		#endregion

		#region Properties
		#endregion

		#region Methods

		public ReflectionAssemblyWrapper(Assembly assembly)
		{
			this.m_assembly = assembly;
		}
		#endregion
	}
}
