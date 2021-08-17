using System.Xml.Serialization;

namespace HxModel.Models.Config
{
	[XmlRoot(ElementName = "NetworkSettings")]
	public class NetworkSettings
	{

		[XmlElement(ElementName = "DataTransfer")]
		public DataTransfer DataTransfer { get; set; }

		[XmlElement(ElementName = "Svvo")]
		public Svvo Svvo { get; set; }
	}
}
