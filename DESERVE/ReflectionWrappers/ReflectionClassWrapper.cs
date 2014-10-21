using DESERVE.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DESERVE.ReflectionWrappers
{
	abstract class ReflectionClassWrapper
	{
		#region Fields
		protected String m_namespace;
		protected String m_class;
		protected Type m_classType;
		#endregion

		#region Properties
		public abstract String ClassName { get; }
		public abstract String AssemblyName { get;}
		#endregion

		#region Methods
		protected ReflectionClassWrapper(Assembly Assembly, String Namespace, String Class)
		{
			m_namespace = Namespace;
			m_class = Class;
			m_classType = Assembly.GetType(Namespace + "." + Class);
		}

		private MethodInfo GetStaticMethod(String methodName, Object[] args)
		{
			Type[] argTypes = new Type[args.Length];
			
			int i = 0;
			foreach (Object arg in args)
			{
				argTypes[i] = arg.GetType();
				i++;
			}

			MethodInfo methodInfo = m_classType.GetMethod(methodName,
				BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static,
				null,
				CallingConventions.Standard,
				argTypes,
				null);
			return methodInfo;
		}

		private MethodInfo GetObjectMethod(String methodName, Object[] args)
		{
			Type[] argTypes = new Type[args.Length];

			int i = 0;
			foreach (Object arg in args)
			{
				argTypes[i] = arg.GetType();
				i++;
			}

			return m_classType.GetMethod(methodName,
				BindingFlags.Public | BindingFlags.Instance,
				null,
				CallingConventions.Standard,
				argTypes,
				null);
		}

		protected Object CallStaticMethod(String methodName, Object[] args)
		{
			MethodInfo methodInfo = GetStaticMethod(methodName, args);

			if (methodInfo != null)
			{
				return CallStaticMethod(methodInfo, args);
			}
			else
			{
				LogManager.ErrorLog.WriteLineAndConsole("Reflection Method not found: " + AssemblyName + "." + ClassName + "." + methodName);
			}
			return null;
		}

		private Object CallStaticMethod(MethodInfo methodInfo, Object[] args)
		{
			return methodInfo.Invoke(null, args);
		}

		protected Object CallObjectMethod(Object obj, String methodName, Object[] args)
		{
			MethodInfo methodInfo = GetObjectMethod(methodName, args);

			if (methodInfo != null)
			{
				return CallObjectMethod(obj, GetObjectMethod(methodName, args), args);
			}
			else
			{
				LogManager.ErrorLog.WriteLineAndConsole("Reflection Method not found: " + AssemblyName + "." + ClassName + "." + methodName);
			}
			return null;
		}

		private Object CallObjectMethod(Object obj, MethodInfo methodInfo, Object[] args)
		{
			if (obj == null)
			{
				LogManager.ErrorLog.WriteLineAndConsole("Error: CallObjectMethod recieved a null referance object while trying to call " + AssemblyName + "." + ClassName + "." + methodInfo.Name);
			}
			return methodInfo.Invoke(obj, args);
		}

		private FieldInfo GetStaticField(String fieldName)
		{
			FieldInfo field = m_classType.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy);
			if (field == null)
				field = m_classType.BaseType.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy);
			if (field == null)
			{
				LogManager.ErrorLog.WriteLineAndConsole("Reflection Field not found: " + AssemblyName + "." + ClassName + "." + fieldName);
			}
			
			return field;
		}

		private FieldInfo GetObjectField(Object gameEntity, String fieldName)
		{
			if (gameEntity == null)
			{
				LogManager.ErrorLog.WriteLineAndConsole("Error: GetObjectField recieved a null referance object while trying to find " + AssemblyName + "." + ClassName + "." + fieldName);
				return null;
			}

			FieldInfo field = m_classType.GetField(fieldName);
			if (field == null)
			{
				//Recurse up through the class heirarchy to try to find the field
				Type type = m_classType;
				while (type != typeof(Object))
				{
					field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.FlattenHierarchy);
					if (field != null)
						break;

					type = type.BaseType;
				}
			}
			if (field == null)
			{
				LogManager.ErrorLog.WriteLineAndConsole("Reflection Field not found: " + AssemblyName + "." + ClassName + "." + fieldName);
			}
			return field;
		}

		protected Object GetStaticFieldValue(String fieldName)
		{
			FieldInfo field = GetStaticField(fieldName);
			if (field != null)
			{
				return field.GetValue(null);
			}
			return null;
		}

		protected Object GetObjectFieldValue(Object gameEntity, String fieldName)
		{
			FieldInfo field = GetObjectField(gameEntity, fieldName);

			if (field != null)
			{
				return field.GetValue(null);
			}
			return null;
		}

		protected void SetStaticFieldValue(String fieldName, Object value)
		{
			FieldInfo field = GetStaticField(fieldName);
			if (field != null)
			{
				field.SetValue(null, value);
			}
		}

		protected void SetObjectFieldValue(Object gameEntity, String fieldName, Object value)
		{
			FieldInfo field = GetObjectField(gameEntity, fieldName);
			if (field != null)
			{
				field.SetValue(gameEntity, value);
			}
		}
		#endregion
	}
}
