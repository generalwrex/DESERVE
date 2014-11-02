using DESERVE.Common;
using DESERVE.ReflectionWrappers.SandboxGameWrappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Timers;
using System.Xml;
using System.Xml.Serialization;

namespace DESERVE.Managers
{
	internal class PluginManager
	{
		#region Fields
		private List<PluginInfo> m_discoveredPlugins;
		private List<PluginInfo> m_loadedPlugins;
		private readonly Object _lockObj = new Object();

		private static Int32 _PLUGIN_UPDATE_FREQUENCY = 200; //Measured in ms;
		System.Timers.Timer m_pluginUpdateTimer;

		#endregion

		#region Properties
		#endregion

		#region Methods
		public PluginManager()
		{
			m_discoveredPlugins = new List<PluginInfo>();
			m_loadedPlugins = new List<PluginInfo>();
			// Register plugin initialization/shutdown events when the server loads.
			ServerInstance.Instance.OnServerStarted += InitializeAllPlugins;
			ServerInstance.Instance.OnServerStopped += ShutdownAllPlugins;
		}

		public void InitializeAllPlugins()
		{
			m_discoveredPlugins = FindAllPlugins();
			foreach (PluginInfo plugin in m_discoveredPlugins)
			{
				InitializePlugin(plugin);
			}

			m_pluginUpdateTimer = new System.Timers.Timer(_PLUGIN_UPDATE_FREQUENCY);
			// AutoReset = false to prevent multiple updates per frame on a laggy server.
			m_pluginUpdateTimer.AutoReset = false;
			m_pluginUpdateTimer.Elapsed += Update;
			m_pluginUpdateTimer.Start();
		}

		public void InitializePlugin(PluginInfo plugin)
		{
			LogManager.MainLog.WriteLineAndConsole(String.Format("DESERVE: Initializing {0}", plugin.Assembly.GetName().Name));
			bool pluginInitialized = false;

			plugin.MainClass = (IPlugin)Activator.CreateInstance(plugin.MainClassType);
			if (plugin.MainClass != null)
			{
				// Sync to make sure we initialized properly.
				SandboxGameWrapper.MainGame.EnqueueActionSync(() =>
				{
					try
					{
						plugin.MainClass.Init(plugin.Directory);
						pluginInitialized = true;
					}
					catch (MissingMethodException)
					{
						LogManager.ErrorLog.WriteLineAndConsole(String.Format("DESERVE: Initialization of {0} failed. Could not find a public, parameterless constructor for {0}", plugin.Assembly.GetName().Name, plugin.MainClassType.ToString()));
					}
					catch (Exception ex)
					{
						LogManager.ErrorLog.WriteLineAndConsole(String.Format("DESERVE: Failed initialzation of {0}. Uncaught Exception: {1}", plugin.Assembly.GetName().Name, ex.ToString()));
					}
				});
			}

			if (pluginInitialized)
			{
				lock (_lockObj)
				{
					m_loadedPlugins.Add(plugin);
				}
			}
		}

		public void ShutdownAllPlugins()
		{
			List<PluginInfo> loadedPlugins;
			lock (_lockObj)
			{
				loadedPlugins = new List<PluginInfo>(m_loadedPlugins);
			}
			foreach (PluginInfo plugin in loadedPlugins)
			{
				ShutdownPlugin(plugin);
			}
		}

		public void ShutdownPlugin(PluginInfo plugin)
		{
			LogManager.MainLog.WriteLineAndConsole(String.Format("DESERVE: Shutting down {0}", plugin.Assembly.GetName().Name));
			lock (_lockObj)
			{
				try
				{
					if (plugin.MainClass != null)
					{
						// Use Sync since we're nullifying MainClass shortly.
						SandboxGameWrapper.MainGame.EnqueueActionSync(() =>
						{
							plugin.MainClass.Shutdown();
						});
					}
					plugin.MainClass = null;
				}
				catch (Exception ex)
				{
					LogManager.ErrorLog.WriteLineAndConsole(String.Format("DESERVE: Uncaught Exception in {0}. Exception: {1}", plugin.Assembly.GetName().Name, ex.ToString()));
				}
				m_loadedPlugins.Remove(plugin);
			}
		}

		public List<PluginInfo> FindAllPlugins()
		{
			List<PluginInfo> foundPlugins = new List<PluginInfo>();

			String modPath = Path.Combine(DESERVE.InstanceDirectory, "Mods");
			String[] subDirectories = Directory.GetDirectories(modPath);

			foreach (String subDirectory in subDirectories)
			{
				PluginInfo plugin = FindPlugin(subDirectory);

				if (plugin != null)
				{
					foundPlugins.Add(plugin);
				}
			}

			return foundPlugins;
		}

		public PluginInfo FindPlugin(String directory)
		{
			String[] libraries = Directory.GetFiles(directory, "*.dll");

			foreach (String library in libraries)
			{
				PluginInfo plugin = ValidatePlugin(library);
				if (plugin != null)
				{
					plugin.Directory = directory;
					return plugin;
				}
			}
			return null;
		}

		public void Update(object sender, ElapsedEventArgs e)
		{
			List<PluginInfo> loadedPlugins;
			lock (_lockObj)
			{
				loadedPlugins = new List<PluginInfo>(m_loadedPlugins);
			}
			foreach (PluginInfo plugin in loadedPlugins)
			{
				if (plugin.MainClass != null)
				{
					// Use Sync so we don't blow through enqueueing the actions
					// and end up resetting the timer and enqueuing more actions
					// before the first group has had a chance.
					SandboxGameWrapper.MainGame.EnqueueActionSync(() =>
						{
							try
							{
								plugin.MainClass.Update();
							}
							catch (Exception ex)
							{
								LogManager.ErrorLog.WriteLineAndConsole(String.Format("DESERVE: Uncaught Exception in {0}. Unloading Plugin. Exception: {1}", plugin.Assembly.GetName().Name, ex.ToString()));
								ShutdownPlugin(plugin);
							}
						});
				}
				else
				{
					ShutdownPlugin(plugin);
				}
			}
			// Restart the timer.
			if (loadedPlugins.Count != 0)
			{
				m_pluginUpdateTimer.Start();
			}
		}

		private PluginInfo ValidatePlugin(String library)
		{
			byte[] bytes;
			Assembly libraryAssembly;
			try
			{
				bytes = File.ReadAllBytes(library);
				libraryAssembly = Assembly.Load(bytes);
				Guid guid = new Guid(((GuidAttribute)libraryAssembly.GetCustomAttributes(typeof(GuidAttribute), true)[0]).Value);

				PluginInfo plugin = new PluginInfo();
				plugin.Guid = guid;
				plugin.Assembly = libraryAssembly;

				Type[] pluginTypes = libraryAssembly.GetExportedTypes();

				foreach (Type pluginType in pluginTypes)
				{
					if (pluginType.GetInterface(typeof(IPlugin).FullName) != null)
					{
						plugin.MainClassType = pluginType;
						return plugin;
					}
				}
			}

			catch (Exception ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole(String.Format("DESERVE: Failed to load assembly: {0} Error: {1}", library, ex.ToString()));
			}
			return null;
		}
		#endregion
	}

	/// <summary>
	/// Small class to track plugins and related information.
	/// </summary>
	public class PluginInfo
	{
		#region Fields
		internal Assembly Assembly;
		public String Directory;
		public Guid Guid;
		public IPlugin MainClass;
		public Type MainClassType;
		#endregion

		#region Methods
		static public Boolean operator ==(PluginInfo obj1, PluginInfo obj2)
		{
			// If both are null, or both are same instance, return true.
			if (System.Object.ReferenceEquals(obj1, obj2))
			{
				return true;
			}

			// If one is null, but not both, return false.
			if (((object)obj1 == null) || ((object)obj2 == null))
			{
				return false;
			}
			return obj1.Guid == obj2.Guid;
		}

		static public Boolean operator !=(PluginInfo obj1, PluginInfo obj2)
		{
			return !(obj1 == obj2);
		}

		public override bool Equals(object obj)
		{
			if (obj is PluginInfo)
			{
				return this == (PluginInfo)obj;
			}
			return false;
		}

		public override int GetHashCode()
		{
			byte[] by = Guid.ToByteArray();
			int value = 0;
			for (int i = 0; i < by.GetLength(0); i++)
			{
				value += (int)(by[i] & 0xffL) << (8 * i);
			}
			return value;
		}
		#endregion
	}

	/// <summary>
	/// Base for a basic plugin with a configuration.
	/// 
	/// Provided to help simplify plugin development.
	/// </summary>
	public abstract class PluginBase : IPlugin
	{
		#region Fields
		protected Guid m_pluginId;
		protected String m_name;
		protected String m_version;
		protected String m_directory;

		protected Log m_log;
		protected PluginBaseConfig m_config;
		#endregion

		#region Properties
		public virtual Guid Id { get { return m_pluginId; } }
		public virtual String Name { get { return m_name; } }
		public virtual String Version { get { return m_version; } }
		public virtual String Directory { get { return m_directory; } }

		public virtual Log PluginLog { get { return m_log; } }
		public virtual PluginBaseConfig Config { get { return m_config; } }
		#endregion

		#region Methods
		public PluginBase()
		{
			Assembly assembly = Assembly.GetCallingAssembly();
			GuidAttribute guidAttr = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
			m_pluginId = new Guid(guidAttr.Value);

			AssemblyName asmName = assembly.GetName();
			m_name = asmName.Name;

			m_version = asmName.Version.ToString();

			m_config = new PluginBaseConfig(this);
		}
		public virtual void Init(String modDirectory)
		{
			m_directory = modDirectory;
			m_log = new Log(m_directory, Name + ".log");
			m_config.Init();
			m_config.Load();
		}

		public abstract void Update();
		public virtual void Shutdown()
		{
			m_config.Save();
		}
		#endregion
	}

	/// <summary>
	/// Basic and Standarized plugin configuation class.
	/// 
	/// Provided to help simplify plugin development.
	/// </summary>
	public class PluginBaseConfig
	{
		#region Fields
		protected String m_configFile;
		protected PluginBase m_plugin;
		protected Object[] m_settings = new Object[] { };
		protected readonly Object _lockObj = new Object();
		#endregion

		#region Events
		public event ConfigEventHandler ConfigLoaded;
		public event ConfigEventHandler ConfigSaved;
		#endregion

		#region Properties
		public virtual Object[] Settings { get { return m_settings; } set { m_settings = value; } }
		#endregion

		#region Methods
		public PluginBaseConfig(PluginBase plugin)
		{
			m_plugin = plugin;
		}

		public virtual void Init()
		{
			m_configFile = Path.Combine(m_plugin.Directory, m_plugin.Name + ".xml");
		}

		public virtual void Save()
		{
			try
			{
				XmlSerializer x = new XmlSerializer(Settings.GetType());
				TextWriter writer = new StreamWriter(m_configFile);
				lock (_lockObj)
				{
					x.Serialize(writer, Settings);
				}
				writer.Close();
			}
			catch (Exception ex)
			{
				m_plugin.PluginLog.WriteLineAndConsole("Could not save configuration: " + ex.ToString());
				return;
			}
			if (ConfigSaved != null)
			{
				ConfigSaved();
			}
		}

		public virtual void Load()
		{
			try
			{
				if (File.Exists(m_configFile))
				{
					XmlSerializer x = new XmlSerializer(Settings.GetType());
					XmlTextReader reader = new XmlTextReader(m_configFile);
					lock (_lockObj)
					{
						Settings = (Object[])x.Deserialize(reader);
						reader.Close();
					}
				}
			}
			catch (Exception ex)
			{
				m_plugin.PluginLog.WriteLineAndConsole("Could not load configuration: " + ex.ToString());
				return;
			}
			if (ConfigLoaded != null)
			{
				ConfigLoaded();
			}
		}
		#endregion
	}

	public interface IPlugin
	{
		#region Fields
		#endregion

		#region Events
		#endregion

		#region Properties
		Guid Id
		{ get; }
		string Name
		{ get; }
		string Version
		{ get; }
		#endregion

		#region Methods
		void Init(String ModDirectory);
		void Update();
		void Shutdown();
		#endregion
	}

	#region EventHandlers
	public delegate void ConfigEventHandler();
	#endregion
}
