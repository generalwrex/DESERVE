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
	public class FileManager
	{
		
		#region Fields
		private static FileManager m_instance;
		#endregion

		public FileManager() { m_instance = this; }

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
		/// <summary>
		/// Serializes CommandLineArgs into a config file.
		/// </summary>
		/// <param name="instancePath"> Where to save the config file to. </param>
		/// <param name="args"> The CommandLineArgs to serialize. </param>
		public CommandLineArgs SaveArguments(string instancePath, CommandLineArgs args)
		{
			try
			{
				if (args == null)
					return null;

				string filePath = Path.Combine(instancePath, "DESERVEManager.cfg");

				XmlSerializer serializer = new XmlSerializer(typeof(CommandLineArgs));
				using (TextWriter writer = new StreamWriter(filePath))
				{
					serializer.Serialize(writer, args);
				} 
				return args;
			}
			catch (Exception ex)
			{
				Manager.ErrorLog.WriteLine(String.Format("Manager Uncaught Exception while saving arguments. Exception: {0}", ex.ToString()));
				MessageBox.Show(ex.ToString());
				return null;
			}
		}

		/// <summary>
		/// Loads CommandLineArgs from a config file.
		/// </summary>
		/// <param name="instanceName"> The full path to the instance folder where the config file is located </param>
		/// <param name="currentInstance"> The ServerInstance of the instance to load the config into. </param>
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
					return SaveArguments(fullInstancePath, new CommandLineArgs() { Instance = instanceName, WCF = true }); ;					
			}
			catch (Exception ex)
			{
				Manager.ErrorLog.WriteLine(String.Format("Manager Uncaught Exception while loading arguments. Exception: {0}", ex.ToString()));
				MessageBox.Show(ex.ToString());
				return null;
			}		
		}
		#endregion
	}
}

