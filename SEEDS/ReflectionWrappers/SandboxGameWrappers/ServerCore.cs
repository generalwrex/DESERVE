using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEEDS.ReflectionWrappers.SandboxGameWrappers
{
	class ServerCore : ReflectionClassWrapper
	{
		#region Fields
		private const String Class = "7BAD4AFD06B91BCD63EA57F7C0D4F408";
		private const String NullRenderField = "53A34747D8E8EDA65E601C194BECE141";
		#endregion

		#region Properties
		public Boolean NullRender 
		{
			get { return (Boolean)GetStaticFieldValue(NullRenderField); }
			set { SetStaticFieldValue(NullRenderField, value); }
		}
		#endregion

		#region Methods
		public ServerCore(String Namespace)
			: base(Namespace)
		{
			m_class = Class;
		}
		#endregion
	}
}
