using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HxModel.Models.Config
{
	[XmlRoot(ElementName = "Position")]
	public class Position
	{

		[XmlElement(ElementName = "IPPoint")]
		public List<IPPoint> IPPoint { get; set; }
	}
}
