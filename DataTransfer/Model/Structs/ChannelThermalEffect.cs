using System;
using System.Runtime.InteropServices;
using DataTransfer.Model.Component.BaseComponent;

namespace DataTransfer.Model.Structs
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ChannelThermalEffect : Base
	{
		public override void Reverse(ref byte[] dgram)
		{
			for (int i = 68; i < dgram.Length; i = i + 8)
				Array.Reverse(dgram, i, 8);
		}

		#region Fields
		/// <summary>
		/// использовать коррекцию яркость/констраст [0 / 1]
		/// </summary>
		private int use_br;

		/// <summary>
		/// использовать фильтр сглаживания [0 / 1]
		/// </summary>
		int use_blur;

		/// <summary>
		/// использовать эффект засветки [0 / 1]
		/// </summary>
		int use_bloom;

		/// <summary>
		/// использовать шум [0 / 1]
		/// </summary>
		int use_time_noise;

		/// <summary>
		/// инверсия [0 / 1]
		/// </summary>
		int use_inverse;

		/// <summary>
		/// использовать оклюжн [0 / 1]
		/// </summary>
		int use_ssao;

		/// <summary>
		/// использовать АРУ [0 / 1]
		/// </summary>
		int use_AGC;

		/// <summary>
		/// заморозить АРУ в текущем состоянии [0 / 1]
		/// </summary>
		int freeze_AGC;

		/// <summary>
		/// Значение яркости [-1..1]
		/// </summary>
		float br_brightness;

		/// <summary>
		/// Значение контраста [0.0..5.0]
		/// </summary>
		float br_contrast;

		/// <summary>
		/// пороговое значение для засветки [0..500]
		/// </summary>
		float bright_pass_threshold;

		/// <summary>
		/// Размер шума [0.1..5.0]
		/// </summary>
		float noise_size;

		/// <summary>
		///  Величина шума [0.0..2.0]
		/// </summary>
		float noise_scale;

		/// <summary>
		/// Величина отдельных всплесков [0.0..2.0]
		/// </summary>
		float noise_scin;

		/// <summary>
		/// Минимальная температура [200..700]
		/// </summary>
		float flir_T_min;

		/// <summary>
		/// Максимальная температура [200..700]
		/// </summary>
		float flir_T_max;

		/// <summary>
		///  Гамма: lum = pow(lum, gamma) [0..2]
		/// </summary>
		float flir_gamma;

		/// <summary>
		/// эфект адаптации fAdapt = 1.f - powf(m_fAdapt_base, m_fAdapt_scale * time); [0.1..1.5]
		/// </summary>
		float agc_adoptation_base;

		/// <summary>
		/// [5..100]
		/// </summary>
		float agc_adoptation_scale; 
		#endregion
	}
}
