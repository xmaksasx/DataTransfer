using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace HxModel.Models.Config.Base
{
	[XmlRoot(ElementName = "Config")]
	public class Config
	{

		[XmlElement(ElementName = "NetworkSettings")]
		public NetworkSettings NetworkSettings { get; set; }

		[XmlAttribute(AttributeName = "xsi")]
		public string Xsi { get; set; }

		[XmlAttribute(AttributeName = "xsd")]
		public string Xsd { get; set; }


		private static Config instance;

		private Config()
		{ }

		public static Config Instance()
		{
			if (instance != null)
				return instance;

			try
			{
				var path = System.AppDomain.CurrentDomain.BaseDirectory;
				XmlSerializer serializer = new XmlSerializer(typeof(Config));
				using (StreamReader reader = new StreamReader(path + "/Config.xml"))
					instance = (Config)serializer.Deserialize(reader);

			}
			catch (Exception e)
			{
				
				var assembly = Assembly.GetExecutingAssembly();
				var resourceName = "HxModel.Resources.Config.xml";
				using (Stream stream = assembly.GetManifestResourceStream(resourceName))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(Config));
					using (StreamReader reader = new StreamReader(stream))
						instance = (Config)serializer.Deserialize(reader);


					using (FileStream fs = new FileStream("Config.xml", FileMode.OpenOrCreate))
					{
						serializer.Serialize(fs, instance);
						
					}

				}

				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Конфигурацмонный файл создан!");
				Console.ForegroundColor = ConsoleColor.Gray;
			}

			return instance;
		}
	}
}
