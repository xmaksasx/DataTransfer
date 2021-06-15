using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Ka50
{
	/// <summary>
	/// Параметры окружаюих контактных объектов
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ContactEnvironment
	{
		// параметры основной контактной плоскости:

		/// <summary>
		/// высота пересечения плоскости с осью Y локальной с.к.(м)
		/// </summary>
		public double Elevation;

		/// <summary>
		/// вектор нормали к плоскости поверхности, нормированный
		/// </summary>
		public XVECTOR3 Normal;

		/// <summary>
		/// зарезервированный указатель для дальнейшего расширения модели
		/// </summary>
		private double ExtObjects;
	}
}