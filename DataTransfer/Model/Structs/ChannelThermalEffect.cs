using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using DataTransfer.Model.Component.BaseComponent;

namespace DataTransfer.Model.Structs
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ChannelThermalEffect : Base
	{
		protected override void SetHead()
		{
			GetHeadDouble("ChannelThermalEffect");
		}
		public override void Reverse(ref byte[] dgram)
		{
			for (int i = 68; i < dgram.Length; i = i + 4)
				Array.Reverse(dgram, i, 4);
		}

		#region Fields
		/// <summary>
		/// использовать коррекцию яркость/констраст [0 / 1]
		/// </summary>
		[Description("использовать коррекцию яркость/констраст [0 / 1]")]
		private int use_br;

		/// <summary>
		/// использовать фильтр сглаживания [0 / 1]
		/// </summary>
		[Description("использовать фильтр сглаживания [0 / 1]")]
		int use_blur;

		/// <summary>
		/// использовать эффект засветки [0 / 1]
		/// </summary>
		[Description("использовать эффект засветки [0 / 1]")]
		int use_bloom;

		/// <summary>
		/// использовать шум [0 / 1]
		/// </summary>
		[Description("использовать шум [0 / 1]")]
		int use_time_noise;

		/// <summary>
		/// инверсия [0 / 1]
		/// </summary>
		[Description("инверсия [0 / 1]")]
		int use_inverse;

		/// <summary>
		/// использовать оклюжн [0 / 1]
		/// </summary>
		[Description("использовать оклюжн [0 / 1]")]
		int use_ssao;

		/// <summary>
		/// использовать АРУ [0 / 1]
		/// </summary>
		[Description("использовать АРУ [0 / 1]")]
		int use_AGC;

		/// <summary>
		/// заморозить АРУ в текущем состоянии [0 / 1]
		/// </summary>
		[Description("заморозить АРУ в текущем состоянии [0 / 1]")]
		int freeze_AGC;

		/// <summary>
		/// Значение яркости [-1..1]
		/// </summary>
		[Description("Значение яркости [-1..1]")]
		float br_brightness;

		/// <summary>
		/// Значение контраста [0.0..5.0]
		/// </summary>
		[Description("Значение контраста [0.0..5.0]")]
		float br_contrast;

		/// <summary>
		/// пороговое значение для засветки [0..500]
		/// </summary>
		[Description("ороговое значение для засветки [0..500]")]
		float bright_pass_threshold;

		/// <summary>
		/// Размер шума [0.1..5.0]
		/// </summary>
		[Description("Размер шума [0.1..5.0]")]
		float noise_size;

		/// <summary>
		/// Величина шума [0.0..2.0]
		/// </summary>
		[Description("Величина шума [0.0..2.0]")]
		float noise_scale;

		/// <summary>
		/// Величина отдельных всплесков [0.0..2.0]
		/// </summary>
		[Description("Величина отдельных всплесков [0.0..2.0]")]
		float noise_scin;

		/// <summary>
		/// Минимальная температура [200..700]
		/// </summary>
		[Description("Минимальная температура [200..700]")]
		float flir_T_min;

		/// <summary>
		/// Максимальная температура [200..700]
		/// </summary>
		[Description("Максимальная температура [200..700]")]
		float flir_T_max;

		/// <summary>
		/// Гамма: lum = pow(lum, gamma) [0..2]
		/// </summary>
		[Description("Гамма: lum = pow(lum, gamma) [0..2]")]
		float flir_gamma;

		/// <summary>
		/// эффект адаптации fAdapt = 1.f - powf(m_fAdapt_base, m_fAdapt_scale * time); [0.1..1.5]
		/// </summary>
		[Description("эффект адаптации fAdapt = 1.f - powf(m_fAdapt_base, m_fAdapt_scale * time); [0.1..1.5]")]
		float agc_adoptation_base;

		/// <summary>
		/// [5..100]
		/// </summary>
		[Description("[5..100]")]
		float agc_adoptation_scale; 
		#endregion
	}
}
