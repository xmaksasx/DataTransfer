using System.Xml.Serialization;

namespace DataTransfer.Model.Structs.Config
{
	// using System.Xml.Serialization;
	// XmlSerializer serializer = new XmlSerializer(typeof(Config));
	// using (StringReader reader = new StringReader(xml))
	// {
	//    var test = (Config)serializer.Deserialize(reader);
	// }


	[XmlRoot(ElementName = "DefaultDynamicModel")]
	public class DefaultDynamicModel
	{

		[XmlAttribute(AttributeName = "Value")]
		public string Value { get; set; }
	}


}
