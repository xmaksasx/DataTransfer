using System.Xml.Serialization;

namespace DataTransfer.Model.Structs.Config
{
	[XmlRoot(ElementName = "Command")]
	public class Command
	{

		[XmlAttribute(AttributeName = "Port")]
		public int Port { get; set; }

		[XmlAttribute(AttributeName = "Ip")]
		public string Ip { get; set; }
	}


}
