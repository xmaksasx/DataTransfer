using System.Xml.Serialization;

namespace DataTransfer.Model.Structs.Config
{
	[XmlRoot(ElementName = "Rus")]
	public class Rus
	{

		[XmlAttribute(AttributeName = "Guid")]
		public string Guid { get; set; }
	}



	
}