using DESERVE.Managers;
using DESERVE.ReflectionWrappers.SandboxGameWrappers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using SysUtils.Utils;
using VRage.Common.Utils;

namespace DESERVE.ReflectionWrappers.DedicatedServerWrappers
{
	class Program : ReflectionClassWrapper
	{
		#region Fields
		private const String Class = "49BCFF86BA276A9C7C0D269C2924DE2D";

		private String StartupMethod;
		private const String StopMethod = "DA95E633B86E22CF269880CE57124695";

		private Boolean m_isRunning;
		private ManualResetEvent m_waitEvent;
		#endregion

		#region Events
		public delegate void ServerRunningEvent(Boolean isRunning);
		public event ServerRunningEvent IsRunningChanged;
		#endregion

		#region Properties
		public override String ClassName { get { return "Program"; } }
		public override String AssemblyName { get { return "SpaceEngineersDedicated"; } }
		public Boolean IsRunning 
		{ 
			get { return m_isRunning; }
			set
			{
				if (m_isRunning == value)
				{
					return;
				}
				m_isRunning = value;
				if (IsRunningChanged != null)
				{
					IsRunningChanged(m_isRunning);
				}
			}
		}
		#endregion

		#region Methods
		public Program(Assembly Assembly, String Namespace)
			: base(Assembly, Namespace, Class)
		{
			StartupMethod = Assembly.EntryPoint.Name;
			m_waitEvent = new ManualResetEvent(false);
		}

		public Thread StartServer(Object args)
		{
			LogManager.MainLog.WriteLineAndConsole("DESERVE: Loading server.");

			SandboxGameWrapper.MainGame.RegisterOnLoadedAction((Action)(() => this.m_waitEvent.Set()));

			Thread serverThread = new Thread(new ParameterizedThreadStart(this.ThreadStart));

			serverThread.IsBackground = true;
			serverThread.CurrentCulture = CultureInfo.InvariantCulture;
			serverThread.CurrentUICulture = CultureInfo.InvariantCulture;
			serverThread.Start(args);

			// Wait for map to load.
			m_waitEvent.WaitOne();

			LogManager.MainLog.WriteLineAndConsole("DESERVE: Server loaded.");

			IsRunning = true;
			return serverThread;
		}

		private void ThreadStart(Object args)
		{
			try
			{
				if (MyLog.Default != null)
					MyLog.Default.Close();
				MyFileSystem.Reset();
				m_isRunning = true;
				DedicatedServerWrapper.Program.Start(args as Object[]);
			}
			catch (Exception ex)
			{
				LogManager.MainLog.WriteLineAndConsole("Unhandled Exception! Server Stopped.");
				LogManager.ErrorLog.WriteLine("Unhandled Exception caused server to crash. Exception: " + ex.ToString());
			}
			m_isRunning = false;
		}

		private void Start(Object[] args)
		{
			CallStaticMethod(StartupMethod, args);
		}
		#endregion
	}
}
