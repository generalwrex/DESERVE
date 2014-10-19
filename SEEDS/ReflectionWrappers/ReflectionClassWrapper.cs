using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SEEDS
{
	class ReflectionClassWrapper
	{

		#region Fields
		protected Assembly m_assembly;
		protected String m_namespace;
		protected String m_class;
		private Type m_classType;
		#endregion

		#region Properties
		#endregion

		#region Methods

		public ReflectionClassWrapper(Assembly assembly)
		{
			this.m_assembly = assembly;
			this.m_classType = m_assembly.GetType(m_namespace + "." + m_class);
		}

		public MethodInfo GetStaticMethod(String methodName, Object[] args)
		{
			Type[] argTypes = new Type[args.Length];
			
			int i = 0;
			foreach (Object arg in args)
			{
				argTypes[i] = arg.GetType();
				i++;
			}

			return m_classType.GetMethod(methodName,
				BindingFlags.Public | BindingFlags.Static,
				null,
				CallingConventions.Standard,
				argTypes,
				null);
		}

		public MethodInfo GetObjectMethod(String methodName, Object[] args)
		{
			Type[] argTypes = new Type[args.Length];

			int i = 0;
			foreach (Object arg in args)
			{
				argTypes[i] = arg.GetType();
				i++;
			}

			return m_classType.GetMethod(methodName,
				BindingFlags.Public | BindingFlags.Static,
				null,
				CallingConventions.Standard,
				argTypes,
				null);
		}

		public void CallStaticMethod(String methodName, Object[] args)
		{
			try
			{
				CallStaticMethod(GetStaticMethod(methodName, args), args);
			}
			catch (Exception ex)
			{

			}
		}

		private void CallStaticMethod(MethodInfo methodInfo, Object[] args)
		{
			methodInfo.Invoke(null, args);
		}

		public void CallObjectMethod(Object obj, String methodName, Object[] args)
		{
			try
			{
				CallObjectMethod(obj, GetObjectMethod(methodName, args), args);
			}
			catch (Exception ex)
			{
				LogManager.ErrorLog.WriteLine("EXCEPTION: " + ex.Message + "/n " + ex.StackTrace);
			}
		}

		private void CallObjectMethod(Object obj, MethodInfo methodInfo, Object[] args)
		{
			methodInfo.Invoke(obj, args);
		}

		public void SetStaticFieldValue(String field, Object value)
		{

		}

		public void SetObjectFieldValue(Object obj, String field, Object value)
		{

		}

		#endregion
	}
}
