using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Ka50
{
	/// <summary>
	/// Кинематические параметры движения
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class KinematicsState
	{
		public KinematicsState()
		{
			
		}
		/// <summary>
		/// углы ориентации связной ск. относительно локальной с.к., град
		/// </summary>
		public AngleTriplet Angs;

		/// <summary>
		/// положение начала связной ск. относительно геоцентрической с.к., м
		/// </summary>
		public DGeoPosition Pos;

		/// <summary>
		/// абсолютная скорость перемещения начала связной ск. относительно локальной с.к., м/с
		/// </summary>
		public XVECTOR3 AbsSpeed;

		/// <summary>
		/// угловые скорости вращения осей связной с.к. (град/с)
		/// </summary>
		public XVECTOR3 Rotation;

		/// <summary>
		/// ускорения в связной с.к. (м/с**2) - имеются в виду кинематические ускорения, а не измеряемые перегрузки!
		/// </summary>
		public XVECTOR3 Accel;
	}
}