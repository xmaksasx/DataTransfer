using System.Xml.Serialization;

namespace DataTransfer.Model.Structs.Config
{
	[XmlRoot(ElementName = "NetworkSettings")]
	public class NetworkSettings
	{

		[XmlElement(ElementName = "Model")]
		public Model Model { get; set; }

		[XmlElement(ElementName = "IupVaps")]
		public IupVaps IupVaps { get; set; }

		[XmlElement(ElementName = "Iup")]
		public Iup Iup { get; set; }

		[XmlElement(ElementName = "TacticalEditor")]
		public TacticalEditor TacticalEditor { get; set; }

		[XmlElement(ElementName = "Svvo")]
		public Svvo Svvo { get; set; }

		[XmlElement(ElementName = "Lptp")]
		public Lptp Lptp { get; set; }

		[XmlElement(ElementName = "Bpmi")]
		public Bpmi Bpmi { get; set; }
	}


}
