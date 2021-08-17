using System.Xml.Serialization;

namespace HxModel.Models.Config
{

	[XmlRoot(ElementName = "DataTransfer")]
	public class DataTransfer
	{
		[XmlElement(ElementName = "DynamicModel")]
		public DynamicModel DynamicModel { get; set; }
	}
}
