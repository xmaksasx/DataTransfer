using System.Xml.Serialization;

namespace DataTransfer.Model.Structs.Config
{
	[XmlRoot(ElementName = "Lptp")]
	public class Lptp
	{

		[XmlElement(ElementName = "DynamicModel")]
		public DynamicModel DynamicModel { get; set; }
	}


}
