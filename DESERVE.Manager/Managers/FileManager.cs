using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Xml;
using System.Xml.Serialization;

using DESERVE.Common;
using DESERVE.Managers;

namespace DESERVE.Manager.Managers
{
	// for anything specific to instances that should be saved
	[Serializable()]
	public class InstanceConfiguration
	{

		public string InstanceName { get; set; }
		public CommandLineArgs CommandLineArguments { get; set; }

		public InstanceConfiguration() {}
	}

	public class FileManager
	{
		
		#region Fields
		private static FileManager m_instance;
		#endregion

		public FileManager()
		{
			m_instance = this;
		}

		#region Properties
		public static FileManager Instance
		{
			get
			{
				if (m_instance == null)
					m_instance = new FileManager();

				return m_instance;
			}
		}
		#endregion

		#region Methods
		public void SaveInstanceConfiguration(Server server)
		{
			try
			{
				

				var instanceConfig = new InstanceConfiguration();

				if (server == null)
					return;

				var name = server.Name;

				string filePath = Path.Combine(InstanceManager.Instance.CommonDataPath, name, "DESERVEManager.cfg");

				instanceConfig.InstanceName = name;
				instanceConfig.CommandLineArguments = server.Arguments;

				XmlSerializer serializer = new XmlSerializer(typeof(InstanceConfiguration));
				using (TextWriter writer = new StreamWriter(filePath))
				{
					serializer.Serialize(writer, instanceConfig);
				} 
			}
			catch (Exception ex)
			{
				new Dialogs.ManagerException(ex);
			}
			

		}

		public InstanceConfiguration LoadInstanceConfiguration(Server server)
		{
			try
			{
				if (server == null)
					return null;

				var name = server.Name;

				string filePath = Path.Combine(InstanceManager.Instance.CommonDataPath, name, "DESERVEManager.cfg");

				XmlSerializer deserializer = new XmlSerializer(typeof(InstanceConfiguration));
				TextReader reader = new StreamReader(filePath);
				InstanceConfiguration instanceConfig = (InstanceConfiguration)deserializer.Deserialize(reader);
				reader.Close();
				return instanceConfig;
			}
			catch (Exception ex)
			{
				new Dialogs.ManagerException(ex);
				return null;
			}
			
		}
		#endregion
	}
}
