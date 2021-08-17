using System.Collections.Generic;
using System.Xml.Serialization;

namespace HxModel.Models.Config
{
	[XmlRoot(ElementName = "DynamicModel")]
	public class DynamicModel
	{

		[XmlElement(ElementName = "IPPoint")]
		public List<IPPoint> IPPoint { get; set; }
	}
}
