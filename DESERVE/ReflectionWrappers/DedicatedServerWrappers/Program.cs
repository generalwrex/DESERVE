using DESERVE.Managers;
using DESERVE.ReflectionWrappers.SandboxGameWrappers;
using System;
using System.Globalization;
using System.Reflection;
using System.Threading;
using SysUtils.Utils;
using VRage.Common.Utils;

namespace DESERVE.ReflectionWrappers.DedicatedServerWrappers
{
	public class Program : ReflectionClassWrapper
	{
		#region Fields
		private const String Class = "49BCFF86BA276A9C7C0D269C2924DE2D";

		private ReflectionMethod m_startupMethod;

		#endregion

		#region Properties
		public override String ClassName { get { return "Program"; } }
		public override String AssemblyName { get { return "SpaceEngineersDedicated"; } }
		#endregion

		#region Methods
		public Program(Assembly Assembly, String Namespace)
			: base(Assembly, Namespace, Class)
		{
			SetupReflection(Assembly);
		}

		private void SetupReflection(Assembly Assembly)
		{
			try
			{
				m_startupMethod = new ReflectionMethod(Assembly.EntryPoint.Name, ClassName, m_classType);
			}
			catch (ArgumentException ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole(ex.ToString());
			}
		}

		/// <summary>
		/// Creates and sets up the main thread to be used by DedicatedServer.exe
		/// </summary>
		/// <returns></returns>
		public Thread PrepareServerThread()
		{
			// Set ThreadStart(Object args) as the starting function of this thread.
			Thread serverThread = new Thread(new ParameterizedThreadStart(ThreadStart));

			serverThread.IsBackground = true;
			serverThread.CurrentCulture = CultureInfo.InvariantCulture;
			serverThread.CurrentUICulture = CultureInfo.InvariantCulture;

			return serverThread;
		}

		/// <summary>
		/// Starts the DedicatedServer.exe by calling DedicatedServer.exe's entry point.
		/// </summary>
		/// <param name="args"></param>
		private void ThreadStart(Object args)
		{
			try
			{
				if (MyLog.Default != null)
					MyLog.Default.Close();
				MyFileSystem.Reset();
				// Call DedicatedServer.exe's entry point.
				// This call does not return until DedicatedServer.exe closes.
				Start(args as Object[]);
			}
			catch (Exception ex)
			{
				LogManager.MainLog.WriteLineAndConsole("Unhandled Exception! Server Stopped.");
				LogManager.ErrorLog.WriteLine(String.Format("Unhandled Exception caused server to crash. Exception: {0}", ex.ToString()));
			}
			// DedicatedServer.exe has been closed. Report it to ServerInstance.
			ServerInstance.Instance.ServerThreadStopped();
		}

		/// <summary>
		/// Calls the entry point of DedicatedServer.exe
		/// </summary>
		/// <param name="args"></param>
		private void Start(Object[] args)
		{
			m_startupMethod.Call(null, args);
		}
		#endregion
	}
}
