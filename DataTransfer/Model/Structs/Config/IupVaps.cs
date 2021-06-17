using System.Xml.Serialization;

namespace DataTransfer.Model.Structs.Config
{
	[XmlRoot(ElementName = "IupVaps")]
	public class IupVaps
	{

		[XmlElement(ElementName = "ControlElement")]
		public ControlElement ControlElement { get; set; }

		[XmlElement(ElementName = "DynamicModel")]
		public DynamicModel DynamicModel { get; set; }

		[XmlElement(ElementName = "Route")]
		public Route Route { get; set; }

		[XmlElement(ElementName = "Landing")]
		public Landing Landing { get; set; }
	}


}
