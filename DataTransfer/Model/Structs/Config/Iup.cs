using System.Xml.Serialization;

namespace DataTransfer.Model.Structs.Config
{
	[XmlRoot(ElementName = "Iup")]
	public class Iup
	{

		[XmlElement(ElementName = "DynamicModel")]
		public DynamicModel DynamicModel { get; set; }
	}


}
