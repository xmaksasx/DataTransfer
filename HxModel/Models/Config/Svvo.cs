using System.Collections.Generic;
using System.Xml.Serialization;

namespace HxModel.Models.Config
{
	[XmlRoot(ElementName = "Svvo")]
	public class Svvo
	{

		[XmlElement(ElementName = "Position")]
		public Position Position { get; set; }
	}

}
