using System.Collections.Generic;
using System.Xml.Serialization;

namespace DataTransfer.Model.Structs.Config
{
	[XmlRoot(ElementName = "State")]
	public class State
	{

		[XmlElement(ElementName = "IPPoint")]
		public List<IPPoint> IPPoint { get; set; }
	}



	
}