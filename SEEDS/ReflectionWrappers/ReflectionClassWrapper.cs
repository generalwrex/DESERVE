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
		protected ReflectionClassWrapper(String Namespace)
		{
			m_namespace = Namespace;
		}

		protected MethodInfo GetStaticMethod(String methodName, Object[] args)
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

		protected MethodInfo GetObjectMethod(String methodName, Object[] args)
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

		protected static FieldInfo GetStaticField(Type objectType, String fieldName)
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

		protected static FieldInfo GetObjectField(Object gameEntity, String fieldName)
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

		protected Object GetObjectFieldValue(Object obj, String fieldName)
		{
			try
			{
				FieldInfo field = GetObjectField(obj, fieldName);
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

		protected void SetStaticFieldValue(String field, Object value)
		{

		}

		protected void SetObjectFieldValue(Object obj, String field, Object value)
		{

		}
		#endregion
	}
}
