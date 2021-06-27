using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Hx
{
	// Кинематические параметры движения:
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	struct KinematicsState
	{
		public AngleTriplet Angs;      // углы ориентации связной ск. относительно локальной с.к., град
		public DGeoPosition Pos;       // положение начала связной ск. относительно геоцентрической с.к., м
		public XVECTOR3 AbsSpeed;  // абсолютная скорость перемещения начала связной ск. относительно локальной с.к., м/с
		public XVECTOR3 Rotation;  // угловые скорости вращения осей связной с.к. (град/с)
		public XVECTOR3 Accel;     // ускорения в связной с.к. (м/с**2) - имеются в виду кинематические ускорения, а не измеряемые перегрузки!
	}
}
