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
		public void SaveInstanceConfiguration(string instanceName)
		{
			var instanceConfig = new InstanceConfiguration();

			var server = InstanceManager.Instance.GetServerByName(instanceName);
			if (server == null)
				return;

			var name = server.Name;

			instanceConfig.InstanceName = name;
			instanceConfig.CommandLineArguments = server.Arguments;

			XmlSerializer serializer = new XmlSerializer(typeof(InstanceConfiguration));
			using (TextWriter writer = new StreamWriter(InstanceManager.Instance.CommonDataPath + "\\"+ name + "\\DESERVE.config"))
			{
				serializer.Serialize(writer, instanceConfig);
			} 

		}

		public InstanceConfiguration LoadInstanceConfiguration(string instanceName)
		{	
			var server = InstanceManager.Instance.GetServerByName(instanceName);
			var name = server.Name;

			XmlSerializer deserializer = new XmlSerializer(typeof(InstanceConfiguration));
			TextReader reader = new StreamReader(InstanceManager.Instance.CommonDataPath + "\\"+ name + "\\DESERVE.config");
			InstanceConfiguration instanceConfig = (InstanceConfiguration)deserializer.Deserialize(reader);
			reader.Close();
			return instanceConfig;
		}
		#endregion
	}
}
