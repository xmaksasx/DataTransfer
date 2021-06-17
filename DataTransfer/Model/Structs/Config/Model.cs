using System.Xml.Serialization;

namespace DataTransfer.Model.Structs.Config
{
	[XmlRoot(ElementName = "Model")]
	public class Model
	{

		[XmlElement(ElementName = "Command")]
		public Command Command { get; set; }

		[XmlElement(ElementName = "ControlElement")]
		public ControlElement ControlElement { get; set; }
	}


}
