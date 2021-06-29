using System.Xml.Serialization;

namespace DataTransfer.Model.Structs.Config
{
	[XmlRoot(ElementName = "Default")]
	public class Default
	{

		[XmlElement(ElementName = "DefaultDynamicModel")]
		public DefaultDynamicModel DefaultDynamicModel { get; set; }

		[XmlElement(ElementName = "DefaultControlElement")]
		public DefaultControlElement DefaultControlElement { get; set; }
	}


}
