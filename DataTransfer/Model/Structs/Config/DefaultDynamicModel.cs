using System.Xml.Serialization;

namespace DataTransfer.Model.Structs.Config
{
	[XmlRoot(ElementName = "DefaultDynamicModel")]
	public class DefaultDynamicModel
	{

		[XmlAttribute(AttributeName = "Value")]
		public string Value { get; set; }
	}



	
}