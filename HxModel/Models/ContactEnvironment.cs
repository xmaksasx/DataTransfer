﻿using System.Runtime.InteropServices;

namespace HxModel.Models
{
	// параметры окружаюих контактных объектов:
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	struct ContactEnvironment
	{
		// параметры основной контактной плоскости:
		public double Elevation;       // высота пересечения плоскости с осью Y локальной с.к.(м)
		public XVECTOR3 Normal;            // вектор нормали к плоскости поверхности, нормированный
		public double ExtObjects;   // зарезервированный указатель для дальнейшего расширения модели
	}
}
