using SEEDS.ReflectionWrappers.SandboxGameWrappers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using SysUtils.Utils;
using VRage.Common.Utils;

namespace SEEDS.ReflectionWrappers.DedicatedServerWrappers
{
	class Program : ReflectionClassWrapper
	{
		#region Fields
		private const String Class = "49BCFF86BA276A9C7C0D269C2924DE2D";

		private const String StartupMethod = "26A7ABEA729FAE1F24679E21470F8E98";
		private const String StopMethod = "DA95E633B86E22CF269880CE57124695";
		#endregion

		#region Properties
		#endregion

		#region Methods
		public Program(Assembly Assembly, String Namespace)
			: base(Assembly, Namespace, Class)
		{
		}

		public Thread StartServer(Object args)
		{
			Thread serverThread = new Thread(new ParameterizedThreadStart(this.ThreadStart));

			serverThread.IsBackground = true;
			serverThread.CurrentCulture = CultureInfo.InvariantCulture;
			serverThread.CurrentUICulture = CultureInfo.InvariantCulture;
			serverThread.Start(args);

			return serverThread;
		}

		private void ThreadStart(Object args)
		{
			try
			{
				if (MyLog.Default != null)
					MyLog.Default.Close();
				MyFileSystem.Reset();
				SandboxGameWrapper.ServerCore.NullRender = true;
				DedicatedServerWrapper.Program.Start(args as Object[]);
			}
			catch (Exception ex)
			{
				int i = 0;
				i++;
			}
		}

		private void Start(Object[] args)
		{
			CallStaticMethod(StartupMethod, args);
		}
		#endregion
	}
}
