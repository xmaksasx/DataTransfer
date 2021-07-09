using System;
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
			//DepartureAerodrome =new Aerodrome();
			//DepartureAerodrome.Name = new char[40];
			//DepartureAerodrome.Name[0] = 'А';
			//DepartureAerodrome.Name[1] = 'д';
			//DepartureAerodrome.Name[2] = 'л';
			//DepartureAerodrome.Name[3] = 'е';
			//DepartureAerodrome.Name[4] = 'р';
			//NavigationPoints = new NavigationPoint[20];
			//NavigationPoints[0] = new NavigationPoint();
			//NavigationPoints[0].Name = new char[16];
			//NavigationPoints[0].Name[0] = 'П';
			//NavigationPoints[0].Name[1] = 'П';
			//NavigationPoints[0].Name[2] = 'М';
			//NavigationPoints[0].Name[3] = '5';
			//NavigationPoints[0].Name[4] = '5';
			//NavigationPoints[0].Name[5] = '5';
			//NavigationPoints[0].Name[6] = '5';
			//NavigationPoints[0].Name[0] = 'А';
			//NavigationPoints[0].Name[1] = 'д';
			//NavigationPoints[0].Name[2] = 'л';
			//NavigationPoints[0].Name[3] = 'е';
			//NavigationPoints[0].Name[4] = 'р';
			//NavigationPoints[1].Name[0] = 'А';
			//NavigationPoints[1].Name[1] = 'д';
			//NavigationPoints[1].Name[2] = 'л';
			//NavigationPoints[1].Name[3] = 'е';
			//NavigationPoints[1].Name[4] = 'р';
			//NavigationPoints[2].Name[0] = 'А';
			//NavigationPoints[2].Name[1] = 'д';
			//NavigationPoints[2].Name[2] = 'л';
			//NavigationPoints[2].Name[3] = 'е';
			//NavigationPoints[2].Name[4] = 'р';
			DepartureAerodrome.Name?.ToBigEndianUnicode40();
			ArrivalAerodrome.Name?.ToBigEndianUnicode40();
			if (NavigationPoints == null) return;
			foreach (var navigationPoint in NavigationPoints) 
				navigationPoint.Name?.ToBigEndianUnicode16();

		}


		public override void Reverse(ref byte[] dgram)
		{
			for (int i = 68; i < dgram.Length; i = i + 8)
				Array.Reverse(dgram, i, 8);
		
			//if (DepartureAerodrome.Name != null)
			//	DepartureAerodrome.Name.ToLittleEndianUnicode();
			//if (ArrivalAerodrome.Name != null)
			//	ToLittleEndian(ArrivalAerodrome.Name);
			//if (NavigationPoints != null)
			//	foreach (var navigationPoint in NavigationPoints)
			//		if (navigationPoint.Name != null)
			//			ToLittleEndian(navigationPoint.Name);
		}






		private void ToLittleEndian(char[] str)
		{
			for (int i = 0; i < str.Length; i = i + 8)
				Array.Reverse(str, i, 8);
			var bytes = Encoding.UTF8.GetBytes(str);
			string st = Encoding.BigEndianUnicode.GetString(bytes);
			for (int i = 0; i < str.Length; i++)
			{
				str[i] = '0';
			}

			Array.Copy(st.ToCharArray(), str, st.Length);
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
