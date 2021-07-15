using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace DataTransfer.Model.Structs.Config.Base
{
	[XmlRoot(ElementName = "Config")]
	public class Config
	{
		[XmlElement(ElementName = "Default")]
		public Default Default { get; set; }

		[XmlElement(ElementName = "NetworkSettings")]
		public NetworkSettings NetworkSettings { get; set; }


		private static Config instance;

		private Config()
		{ }

		public static Config Instance()
		{
			if (instance != null)
				return instance;
		
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(Config));
				using (StreamReader reader = new StreamReader("Config.xml"))
					instance = (Config)serializer.Deserialize(reader);

			}
			catch (Exception e)
			{
				var assembly = Assembly.GetExecutingAssembly();
				var resourceName = "DataTransfer.Infrastructure.Resource.Config.xml";
				using (Stream stream = assembly.GetManifestResourceStream(resourceName))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(Config));
					using (StreamReader reader = new StreamReader(stream))
						instance = (Config)serializer.Deserialize(reader);
				}
			}

			return instance;
		}

		private Config LoadConfig()
		{
			Config config = null;
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(Config));
				using (StreamReader reader = new StreamReader("Config.xml"))
					config = (Config)serializer.Deserialize(reader);

			}
			catch (Exception e)
			{
				var assembly = Assembly.GetExecutingAssembly();
				var resourceName = "DataTransfer.Infrastructure.Resource.Config.xml";
				using (Stream stream = assembly.GetManifestResourceStream(resourceName))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(Config));
					using (StreamReader reader = new StreamReader(stream))
						config = (Config)serializer.Deserialize(reader);
				}
			}

			return config;
		}

		
	}


}
