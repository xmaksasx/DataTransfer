using System.Collections.Generic;
using System.Xml.Serialization;

namespace DataTransfer.Model.Structs.Config
{
	[XmlRoot(ElementName = "Route")]
	public class Route
	{

		[XmlElement(ElementName = "IPPoint")]
		public List<IPPoint> IPPoint { get; set; }
	}



	
}