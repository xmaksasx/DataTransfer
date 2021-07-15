using System.Collections.Generic;
using System.Xml.Serialization;

namespace DataTransfer.Model.Structs.Config
{
	[XmlRoot(ElementName = "Command")]
	public class Command
	{

		[XmlElement(ElementName = "IPPoint")]
		public List<IPPoint> IPPoint { get; set; }
	}



	
}