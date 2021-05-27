using System.Runtime.InteropServices;
using DataTransfer.Model.Component.BaseComponent;

namespace DataTransfer.Model.Structs
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class StartPosition : Base
	{
		public void InitPosition()
		{
			flag = 0;
			LAND = 0;
			StartX = 85554.36;
			StartY = 77255.45;
			in_V = 0;
			in_Hgeom = 14;
			in_t = 0;
			in_Shag = 0.01f;
			in_TemperatVozd0 = 20;
			in_Massa0 = 10400;
			in_Center0 = 0.08f;
			in_Toplivo = 1500;
			in_Kurs0 = 0; //90;
			in_Hbar = in_Hgeom;
			
		}


		public void StateOfModel(int state)
		{
			flag = state;
		}

		/// <summary>
		/// 0 - установка начальных условий
		/// 1 - старт
		/// 2 - пауза
		/// Команда на управление 
		/// </summary>
		int flag;

		/// <summary>
		/// на земле
		/// </summary>
		byte LAND;
		
		/// <summary>
		/// начальное положение по Х
		/// </summary>
		double StartX;

		/// <summary>
		/// начальное положение по Y
		/// </summary>
		double StartY;
		
		/// <summary>
		/// начальная скорость
		/// </summary>
		float in_V;
		
		/// <summary>
		/// Начальная высота
		/// </summary>
		float in_Hgeom;
		
		/// <summary>
		/// 
		/// </summary>
		float in_t;
		
		/// <summary>
		/// 
		/// </summary>
		float in_Shag;
		
		/// <summary>
		/// 
		/// </summary>
		float in_TemperatVozd0;
		
		/// <summary>
		/// 
		/// </summary>
		float in_Massa0;
		
		/// <summary>
		/// 
		/// </summary>
		float in_Center0;
		
		/// <summary>
		/// 
		/// </summary>
		float in_Toplivo;
		
		/// <summary>
		/// начальный курс
		/// </summary>
		float in_Kurs0;

		/// <summary>
		/// бараметрическая высота
		/// </summary>
		float in_Hbar;
	}
}
