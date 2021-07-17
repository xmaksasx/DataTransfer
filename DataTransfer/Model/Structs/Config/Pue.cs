using System.Xml.Serialization;

namespace DataTransfer.Model.Structs.Config
{
	[XmlRoot(ElementName = "Pue")]
	public class Pue
	{

		[XmlElement(ElementName = "DynamicModel")]
		public DynamicModel DynamicModel { get; set; }
	}



	
}