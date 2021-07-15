using System.Xml.Serialization;

namespace DataTransfer.Model.Structs.Config
{
	[XmlRoot(ElementName = "TacticalEditor")]
	public class TacticalEditor
	{

		[XmlElement(ElementName = "DynamicModel")]
		public DynamicModel DynamicModel { get; set; }
	}



	
}