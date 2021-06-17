using System.Xml.Serialization;

namespace DataTransfer.Model.Structs.Config
{
	[XmlRoot(ElementName = "Rud")]
	public class Rud
	{

		[XmlAttribute(AttributeName = "Guid")]
		public string Guid { get; set; }
	}


}
