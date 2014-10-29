using DESERVE.Managers;
using System;
using System.Reflection;

namespace DESERVE.ReflectionWrappers.SandboxGameWrappers
{
	public class MainGame : ReflectionClassWrapper
	{
		#region Fields
		private const String Class = "B3531963E948FB4FA1D057C4340C61B4";

		private ReflectionField m_instanceField;
		private ReflectionMethod m_signalShutdown;
		private ReflectionMethod m_enqueueAction;
		private ReflectionMethod m_registerOnLoaded;
		#endregion

		#region Properties
		public override String ClassName { get { return "MainGame"; } }
		public override String AssemblyName { get { return "Sandbox.Game"; } }

		public Object Instance { get { return m_instanceField.GetValue(null); } }
		#endregion

		#region Methods
		public MainGame(Assembly Assembly, String Namespace)
			: base(Assembly, Namespace, Class)
		{
			SetupReflection();

		}

		private void SetupReflection()
		{
			try
			{
				m_instanceField = new ReflectionField("392503BDB6F8C1E34A232489E2A0C6D4", ClassName, m_classType);
			}
			catch (ArgumentException ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole(ex.ToString());
			}
			try
			{
				m_signalShutdown = new ReflectionMethod("DA95E633B86E22CF269880CE57124695", ClassName, m_classType);
			}
			catch (ArgumentException ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole(ex.ToString());
			}
			try
			{
				m_enqueueAction = new ReflectionMethod("0172226C0BA7DAE0B1FCE0AF8BC7F735", ClassName, m_classType);
			}
			catch (ArgumentException ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole(ex.ToString());
			}
			try
			{
				m_registerOnLoaded = new ReflectionMethod("5D7D384DD47365A043F15CD321FBEC53", ClassName, m_classType);
			}
			catch (ArgumentException ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole(ex.ToString());
			}
		}

		public void SignalShutdown()
		{
			m_signalShutdown.Call(Instance, new Object[] { });
		}

		/// <summary>
		/// Runs the action on the gameserver's main thread. May return
		/// before action is run.
		/// </summary>
		/// <param name="action"></param>
		public void EnqueueActionAsync(Action action)
		{
			m_enqueueAction.Call(Instance, new Object[] { action });
		}

		/// <summary>
		/// Runs the action on the gameserver's main thread. Does not
		/// return until action has been run.
		/// <param name="action"></param>
		public void EnqueueActionSync(Action action)
		{
			/*
			if (Thread.CurrentThread == ServerInstance.ServerThread)
			{
				action.Invoke();
			}
			else
			{
				ManualResetEvent waitEvent = new ManualResetEvent(false);

				EnqueueActionAsync(action);
				EnqueueActionAsync(() => waitEvent.Set());

				waitEvent.WaitOne();
			}
			 */
		}

		public void RegisterOnLoadedAction(Action action)
		{
			m_registerOnLoaded.Call(Instance, new Object[] { action });
		}
		#endregion
	}
}
