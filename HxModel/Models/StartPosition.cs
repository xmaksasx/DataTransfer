using System.ComponentModel;
using System.Runtime.InteropServices;


namespace HxModel.Models
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class StartPosition : Header
	{
		public void InitPosition(int state)
		{
			flag = state;
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

		#region Fields
		/// <summary>
		/// 0 - установка начальных условий
		/// 1 - старт
		/// 2 - пауза
		/// Команда на управление 
		/// </summary>
		[Description("Команда на управление 1 - старт 2 - пауза -1 - стоп")]
		public int flag;

		/// <summary>
		/// на земле
		/// </summary>
		[Description("на земле")]
		public byte LAND;

		/// <summary>
		/// начальное положение по Х
		/// </summary>
		[Description("начальное положение по Х")]
		public double StartX;

		/// <summary>
		/// начальное положение по Y
		/// </summary>
		[Description("начальное положение по Y")]
		public double StartY;

		/// <summary>
		/// начальная скорость
		/// </summary>
		[Description("начальная скорость")]
		public float in_V;

		/// <summary>
		/// Начальная высота
		/// </summary>
		[Description("Начальная высота")]
		public float in_Hgeom;

		/// <summary>
		/// in_t
		/// </summary>
		[Description("in_t")]
		public float in_t;

		/// <summary>
		/// in_Shag
		/// </summary>
		[Description("in_Shag")]
		public float in_Shag;

		/// <summary>
		/// начальная температура воздуха
		/// </summary>
		[Description("начальная температура воздуха")]
		public float in_TemperatVozd0;

		/// <summary>
		/// начальная масса
		/// </summary>
		[Description("начальная масса")]
		public float in_Massa0;

		/// <summary>
		/// in_Center0
		/// </summary>
		[Description("in_Center0")]
		public float in_Center0;

		/// <summary>
		/// начальное топливо
		/// </summary>
		[Description("начальное топливо")]
		public float in_Toplivo;

		/// <summary>
		/// начальный курс
		/// </summary>
		[Description("начальный курс")]
		public float in_Kurs0;

		/// <summary>
		/// бараметрическая высота
		/// </summary>
		[Description("бараметрическая высота")]
		public float in_Hbar;
		#endregion
	}
}
