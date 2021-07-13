using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using DataTransfer.Infrastructure.Helpers;
using DataTransfer.Model.Component.BaseComponent;
using DataTransfer.Model.Structs.RouteStruct.AerodromeStruct;
using DataTransfer.Model.Structs.RouteStruct.NavigationPointStruct;

namespace DataTransfer.Model.Structs.RouteStruct
{

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class Route : Base
	{
		protected override void SetHead()
		{
			GetHeadDouble("Route");
		}

		protected override void ReverseName()
		{
			

		}


		public override void Reverse(ref byte[] dgram)
		{

			List<byte> result = new List<byte>();
			result.Clear();
			result.AddRange(Head);
			result.AddRange(BitConverter.GetBytes(CountPoints));
			result.AddRange(ConvertHelper.ObjectToByte(DepartureAerodrome.Runway));
			foreach (var np in NavigationPoints)
			{
				result.AddRange(ConvertHelper.ObjectToByte(np.Type));
				result.AddRange(ConvertHelper.ObjectToByte(np.Executable));
				result.AddRange(ConvertHelper.ObjectToByte(np.PrPro));
				result.AddRange(ConvertHelper.ObjectToByte(np.GeoCoordinate));
				result.AddRange(ConvertHelper.ObjectToByte(np.Measure));
			}
			result.AddRange(ConvertHelper.ObjectToByte(ArrivalAerodrome.Runway));
			dgram = result.ToArray();
			for (int i = 68; i < dgram.Length; i = i + 8)
				Array.Reverse(dgram, i, 8);
		}

		/// <summary>
		/// Количество точек в маршруте
		/// </summary>
		[Description("Количество точек в маршруте")]
		public double CountPoints;

		/// <summary>
		/// Аэродром вылета
		/// </summary>
		[Description("Аэродром вылета")] public Aerodrome DepartureAerodrome = new Aerodrome();

		/// <summary>
		/// Навигационные точки
		/// </summary>
		[Description("Навигационные точки")] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		public NavigationPoint[] NavigationPoints;

		/// <summary>
		/// Аэродром посадки
		/// </summary>
		[Description("Аэродром посадки")] public Aerodrome ArrivalAerodrome = new Aerodrome();
	}

	
}
