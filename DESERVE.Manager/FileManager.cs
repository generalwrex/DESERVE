using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Xml;
using System.Xml.Serialization;

using DESERVE.Common;

using System.Windows;

namespace DESERVE.Manager
{
	// for anything specific to instances that should be saved
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
		public void SaveArguments(string instancePath, CommandLineArgs args)
		{
			try
			{

				if (args == null)
					return;

				string filePath = Path.Combine(instancePath, "DESERVEManager.cfg");

				XmlSerializer serializer = new XmlSerializer(typeof(CommandLineArgs));
				using (TextWriter writer = new StreamWriter(filePath))
				{
					serializer.Serialize(writer, args);
				} 
			}
			catch (Exception ex)
			{
				//TODO: LogManager.Log("Something bad happened!");
				MessageBox.Show(ex.ToString());
			}
			

		}

		public CommandLineArgs LoadArguments(string fullInstancePath, string instanceName, ServerInstance currentInstance)
		{
			try
			{

				string filePath = Path.Combine(fullInstancePath, "DESERVEManager.cfg");

				if (File.Exists(filePath))
				{
					XmlSerializer deserializer = new XmlSerializer(typeof(CommandLineArgs));
					TextReader reader = new StreamReader(filePath);
					CommandLineArgs args = (CommandLineArgs)deserializer.Deserialize(reader);
					reader.Close();
					return args;
				}
				else
				{

					CommandLineArgs args = new CommandLineArgs();
					args.Instance = instanceName;
					args.AutosaveMinutes = -1;
					args.WCF = true;
					args.ModAPI = false;
					args.Plugins = false;

					SaveArguments(fullInstancePath, args);

					return args;
				}
								
			}
			catch (Exception ex)
			{
				//TODO: LogManager.Log("Something bad happened!");
				MessageBox.Show(ex.ToString());
				return null;
			}
			
		}
		#endregion
	}
}
