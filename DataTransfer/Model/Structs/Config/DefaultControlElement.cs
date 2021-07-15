using System.Xml.Serialization;

namespace DataTransfer.Model.Structs.Config
{
	[XmlRoot(ElementName = "DefaultControlElement")]
	public class DefaultControlElement
	{

		[XmlElement(ElementName = "Rus")]
		public Rus Rus { get; set; }

		[XmlElement(ElementName = "Rud")]
		public Rud Rud { get; set; }

		[XmlAttribute(AttributeName = "Value")]
		public string Value { get; set; }
	}



	
}