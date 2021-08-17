using System.Xml.Serialization;

namespace HxModel.Models.Config
{
	[XmlRoot(ElementName = "IPPoint")]
	public class IPPoint
	{

		[XmlAttribute(AttributeName = "Port")]
		public int Port { get; set; }

		[XmlAttribute(AttributeName = "Ip")]
		public string Ip { get; set; }
	}
}
