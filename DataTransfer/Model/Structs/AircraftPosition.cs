using System.ComponentModel;
using System.Runtime.InteropServices;
using DataTransfer.Model.Component.BaseComponent;
using DataTransfer.Model.Structs.RouteStruct.NavigationPointStruct;


namespace DataTransfer.Model.Structs
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class AircraftPosition : Header
	{
		public AircraftPosition()
		{
			GetHeadDouble("AircraftPosition");
		}

		[Description("Признак того что координаты в градусах")]
		public double IsDegree;

		[Description("угол тангажа угол между продольной осью ОХ связанной с.к.и горизонтом, [град]")]
		public double Tang;

		[Description("угол крена угол между поперечной осью связанной с.к.и осью OZ нормальной земной с.к.[град]")]
		public double Kren;

		[Description("угол рысканья угол между продольной осью связанной с.к.и осью ОХ земной с.к., [град]")]
		public double Risk;

		[Description("высота ландшафта над уровнем моря [м]")]
		public double HLand;

		[Description("скорость [км/ч]")]
		public double V;

		public GeoCoordinate GeoCoordinate;
	}
}

