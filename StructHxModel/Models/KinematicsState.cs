using System.ComponentModel;
using System.Runtime.InteropServices;

namespace StructHxModel.Models
{
	// Кинематические параметры движения:
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	public struct KinematicsState
	{
		/// <summary>
		/// углы ориентации связной ск. относительно локальной с.к., град
		/// </summary>
		[Description("углы ориентации связной ск. относительно локальной с.к., град")]
		public AngleTriplet Angs;

		/// <summary>
		/// положение начала связной ск. относительно геоцентрической с.к., м
		/// </summary>
		[Description("положение начала связной ск. относительно геоцентрической с.к., м")]
		public DGeoPosition Pos;

		/// <summary>
		/// абсолютная скорость перемещения начала связной ск. относительно локальной с.к., м/с
		/// </summary>
		[Description("абсолютная скорость перемещения начала связной ск. относительно локальной с.к., м/с")]
		public XVECTOR3 AbsSpeed;

		/// <summary>
		/// угловые скорости вращения осей связной с.к. (град/с)
		/// </summary>
		[Description("угловые скорости вращения осей связной с.к. (град/с)")]
		public XVECTOR3 Rotation;


		/// <summary>
		/// ускорения в связной с.к. (м/с**2) - имеются в виду кинематические ускорения, а не измеряемые перегрузки!
		/// </summary>
		[Description("ускорения в связной с.к. (м/с**2) - имеются в виду кинематические ускорения, а не измеряемые перегрузки!")]
		public XVECTOR3 Accel;

	}
}
