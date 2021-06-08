using System.ComponentModel;
using System.Runtime.InteropServices;
using DataTransfer.Model.Component.BaseComponent;
using DataTransfer.Model.Structs.Route;

namespace DataTransfer.Model.Structs
{

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class TacticalEditorRoute:Base
	{
		/// <summary>
		/// Количество точек в маршруте
		/// </summary>
		[Description("Количество точек в маршруте")] 
		public double CountPoints;
		
		/// <summary>
		/// Аэродром вылета
		/// </summary>
		[Description("Аэродром вылета")]
		public Aerodrome DepartureAerodrome = new Aerodrome();
		
		/// <summary>
		/// Навигационные точки
		/// </summary>
		[Description("Навигационные точки")]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		public NavigationPoint[] NavigationPoints = new NavigationPoint[20];

		/// <summary>
		/// Аэродром посадки
		/// </summary>
		[Description("Аэродром посадки")]
		public Aerodrome ArrivalAerodrome = new Aerodrome();
	}
}
