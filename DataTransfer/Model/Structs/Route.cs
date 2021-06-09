using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using DataTransfer.Infrastructure.Helpers;
using DataTransfer.Model.Component.BaseComponent;
using DataTransfer.Model.Structs.AerodromeStruct;
using DataTransfer.Model.Structs.NavigationPointStruct;

namespace DataTransfer.Model.Structs
{

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class Route:Base
	{
		protected override void SetHead()
		{
			GetHeadDouble("Route");
		}

		protected override void ReverseName()
		{
			DepartureAerodrome.Name =new char[40];
			DepartureAerodrome.Name[0] = 'а';


			if (DepartureAerodrome.Name != null)
				ToBigEndian(DepartureAerodrome.Name);
			//if (ArrivalAerodrome.Name != null)
			//	ToBigEndian(ArrivalAerodrome.Name);
			//if (NavigationPoints != null)
			//	foreach (var navigationPoint in NavigationPoints)
			//		if (navigationPoint.Name != null)
			//			ToBigEndian(navigationPoint.Name);
			
		}


		public override void Reverse(ref byte[] dgram)
		{
			CountPoints = 10;
			for (int i = 68; i < dgram.Length; i = i + 8)
				Array.Reverse(dgram, i, 8);

		//	if (DepartureAerodrome.Name != null)
		//		ToLittleEndian(DepartureAerodrome.Name);
			//if (ArrivalAerodrome.Name != null)
			//	ToLittleEndian(ArrivalAerodrome.Name);
			//if (NavigationPoints != null)
			//	foreach (var navigationPoint in NavigationPoints)
			//		if (navigationPoint.Name != null)
			//			ToLittleEndian(navigationPoint.Name);
		}

		private void ToBigEndian(char[] str)
		{
			//Array.Copy(Encoding.BigEndianUnicode.GetBytes(str), str, str.Length);
			//for (int i = 0; i < str.Length; i = i + 8)
			//	Array.Reverse(str, i, 8);

			var nameBytes = Encoding.Default.GetBytes(new string(str).Trim('\0'));
			var bytes = new byte[str.Length];
			nameBytes.CopyTo(bytes, 0);
			for (int i = 0; i < bytes.Length; i = i + 2)
						Array.Reverse(bytes, i, 2);
			for (int i = 0; i < bytes.Length; i = i + 8)
				Array.Reverse(bytes, i, 8);


			Array.Copy(bytes, str, str.Length);
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
		[Description("Аэродром вылета")]
		public Aerodrome DepartureAerodrome = new Aerodrome();
		
		///// <summary>
		///// Навигационные точки
		///// </summary>
		//[Description("Навигационные точки")]
		//[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		//public NavigationPoint[] NavigationPoints;

		///// <summary>
		///// Аэродром посадки
		///// </summary>
		//[Description("Аэродром посадки")]
		//public Aerodrome ArrivalAerodrome = new Aerodrome();
	}
}
