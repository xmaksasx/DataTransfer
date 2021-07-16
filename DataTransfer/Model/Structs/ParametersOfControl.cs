using DataTransfer.Model.Component.BaseComponent;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ParametersOfControl: Base
	{
		protected override void SetHead()
		{
			GetHeadDouble("ParametersOfControl");
		}
		public override void Reverse(ref byte[] dgram)
		{
			for (int i = 68; i < dgram.Length; i = i + 8)
				Array.Reverse(dgram, i, 8);
		}

		/// <summary>
		/// Давление
		/// </summary>
		[Description("Давление")]
		double Pressure;

		/// <summary>
		/// ОУ (центральная ручка или боковая)
		/// </summary>
		[Description("ОУ (центральная ручка или боковая)")]
		double ControlElementChannel;

		/// <summary>
		/// Текущий ппм
		/// </summary>
		[Description("Текущий ппм")]
		double CurrentPpm;

		/// <summary>
		/// Текущий аэр
		/// </summary>
		[Description("Текущий аэр")]
		double CurrentAerodrome;

		/// <summary>
		/// Режим полёта(навигация)
		/// <summary>
		[Description("Режим полёта(навигация)")]
		double FlyMode;

	}
}
