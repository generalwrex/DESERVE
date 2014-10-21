using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SEEDS.ReflectionWrappers
{
	class ReflectionClassWrapper
	{
		#region Fields
		protected String m_namespace;
		protected String m_class;
		protected Type m_classType;
		#endregion

		#region Properties
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

		protected void CallStaticMethod(String methodName, Object[] args)
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

		protected void CallObjectMethod(Object obj, String methodName, Object[] args)
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

		private static FieldInfo GetStaticField(Type objectType, String fieldName)
		{
			try
			{
				FieldInfo field = objectType.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy);
				if (field == null)
					field = objectType.BaseType.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy);
				return field;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		private static FieldInfo GetObjectField(Object gameEntity, String fieldName)
		{
			try
			{
				FieldInfo field = gameEntity.GetType().GetField(fieldName);
				if (field == null)
				{
					//Recurse up through the class heirarchy to try to find the field
					Type type = gameEntity.GetType();
					while (type != typeof(Object))
					{
						field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.FlattenHierarchy);
						if (field != null)
							break;

						type = type.BaseType;
					}
				}
				return field;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		protected Object GetStaticFieldValue(String fieldName)
		{
			try
			{
				FieldInfo field = GetStaticField(m_classType, fieldName);
				if (field != null)
				{
					return field.GetValue(null);
				}
			}
			catch (Exception ex)
			{

			}
			return null;
		}

		protected Object GetObjectFieldValue(Object gameEntity, String fieldName)
		{
			try
			{
				FieldInfo field = GetObjectField(gameEntity, fieldName);
				if (field != null)
				{
					return field.GetValue(null);
				}
			}
			catch (Exception ex)
			{

			}
			return null;
		}

		protected void SetStaticFieldValue(String fieldName, Object value)
		{
			try
			{
				FieldInfo field = GetStaticField(m_classType, fieldName);
				if (field == null)
					return;
				field.SetValue(null, value);
			}
			catch (Exception ex)
			{
			}
		}

		protected void SetObjectFieldValue(Object gameEntity, String fieldName, Object value)
		{
			try
			{
				FieldInfo field = GetObjectField(gameEntity, fieldName);
				if (field == null)
					return;
				field.SetValue(gameEntity, value);
			}
			catch (Exception ex)
			{
			}
		}
		#endregion
	}
}
