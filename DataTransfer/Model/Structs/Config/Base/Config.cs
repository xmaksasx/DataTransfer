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
	}


}
