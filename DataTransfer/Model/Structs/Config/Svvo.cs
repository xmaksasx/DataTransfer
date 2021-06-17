using System.Xml.Serialization;

namespace DataTransfer.Model.Structs.Config
{
	[XmlRoot(ElementName = "Svvo")]
	public class Svvo
	{

		[XmlElement(ElementName = "Route")]
		public Route Route { get; set; }
	}


}
