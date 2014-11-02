using DESERVE.Managers;
using System;
using System.Reflection;

namespace DESERVE.ReflectionWrappers.SandboxGameWrappers
{
	public class WorldManager : ReflectionClassWrapper
	{
		#region Fields
		private const String Class = "D580AE7552E79DAB03A3D64B1F7B67F9";
		private ReflectionMethod m_save;
		private ReflectionField m_instance;

		private Boolean m_isSaving;
		#endregion

		#region Events
		public delegate void SavingEventHandler(Boolean isSaving);
		public event SavingEventHandler IsSavingChanged;
		#endregion

		#region Properties
		public override String ClassName { get { return "WorldManager"; } }
		public override String AssemblyName { get { return "Sandbox.Game"; } }
		public Object Instance { get { return m_instance.GetValue(null); } }
		public Boolean IsSaving
		{
			get { return m_isSaving; }
			set
			{
				if (m_isSaving == value)
				{
					return;
				}
				m_isSaving = value;
				if (IsSavingChanged != null)
				{
					IsSavingChanged(m_isSaving);
				}
			}
		}
		#endregion

		#region Methods
		public WorldManager(Assembly Assembly, String Namespace)
			: base(Assembly, Namespace, Class)
		{
			SetupReflection();
		}

		private void SetupReflection()
		{
			try
			{
				m_save = new ReflectionMethod("50092B623574C842837BD09CE21A96D6", Class, m_classType);
			}
			catch (ArgumentException ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole(ex.ToString());
			}
			try
			{
				m_instance = new ReflectionField("AE8262481750DAB9C8D416E4DBB9BA04", Class, m_classType);
			}
			catch (ArgumentException ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole(ex.ToString());
			}
		}

		public void Save()
		{
			SandboxGameWrapper.MainGame.EnqueueActionAsync(SaveWorld);
		}

		/// <summary>
		/// Must be called from the main server thread. NOT the DESERVE program thread.
		/// </summary>
		private void SaveWorld()
		{
			IsSaving = true;

			LogManager.MainLog.WriteLineAndConsole("DESERVE: Saving world.");

			DateTime saveStartTime = DateTime.Now;

			String arg0 = "";
			Object[] args = 
			{
				arg0
			};

			bool result = (bool)m_save.Call(Instance, args);

			if (result)
			{
				TimeSpan timeToSave = DateTime.Now - saveStartTime;
				LogManager.MainLog.WriteLineAndConsole(String.Format("DESERVE: Save complete and took {0} seconds", timeToSave.TotalSeconds));
			}
			else
			{
				LogManager.ErrorLog.WriteLineAndConsole("DESERVE: Save Failed!");
			}

			IsSaving = false;
		}

		/// <summary>
		/// May be called from any thread. Seperates the snapshot and file write processes.
		/// File write takes the most time and is run on a different thread form the game.
		/// </summary>
		public void EnhancedSave()
		{
			IsSaving = true;
			LogManager.MainLog.WriteLineAndConsole("DESERVE: Performing Enhanced Save");

			DateTime saveStartTime = DateTime.Now;

			String arg0 = DESERVE.Arguments.Instance;
			Object[] parameters = 
			{
				null,
				arg0,
			};

			Type[] paramTypes =
			{
				m_assembly.GetType(m_namespace + "." + "15B6B94DB5BE105E7B58A34D4DC11412").MakeByRefType(),
				arg0.GetType(),
			};

			bool result = false;

			SandboxGameWrapper.MainGame.EnqueueActionSync(() =>
				{
					result = (bool)m_save.Call(Instance, parameters, paramTypes);
				}
				);

			LogManager.MainLog.WriteLineAndConsole(String.Format("DESERVE: Snapshot Complete. Unblocking Main Thread. Main Thread Blocked for: {0} seconds.", (DateTime.Now - saveStartTime).TotalSeconds));
			saveStartTime = DateTime.Now;

			if (result)
			{
				result = SandboxGameWrapper.WorldResourceManager.SaveSnapshot(parameters[0]);
			}
			else
			{
				LogManager.ErrorLog.WriteLineAndConsole("DESERVE: Enhanced Save Failed!");
			}

			if (result)
			{
				TimeSpan timeToSave = DateTime.Now - saveStartTime;
				LogManager.MainLog.WriteLineAndConsole(String.Format("DESERVE: File write complete. File write took seconds", timeToSave.TotalSeconds));
			}
			else
			{
				LogManager.ErrorLog.WriteLineAndConsole("DESERVE: Enhanced Save Failed!");
			}

			IsSaving = false;

		}
		#endregion
	}
}
