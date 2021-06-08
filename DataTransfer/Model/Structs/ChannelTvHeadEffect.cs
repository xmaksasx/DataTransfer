using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using DataTransfer.Model.Component.BaseComponent;

namespace DataTransfer.Model.Structs
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ChannelTvHeadEffect : Base
	{
		protected override void SetHead()
		{
			GetHeadDouble("ChannelTvHeadEffect");
		}

		public override void Reverse(ref byte[] dgram)
		{
			for (int i = 68; i < dgram.Length; i = i + 4)
				Array.Reverse(dgram, i, 4);
		}

		#region Fields
		/// <summary>
		/// использовать адаптацию яркости [0/1]
		/// </summary>
		[Description("использовать адаптацию яркости [0/1]")] 
		private int use_tone_map;

		/// <summary>
		/// использовать шум [0/1]
		/// </summary>
		[Description("использовать шум [0/1]")]
		private int use_time_noise;

		/// <summary>
		/// использовать эффект засветки [0/1]
		/// </summary>
		[Description("использовать эффект засветки [0/1]")]
		private int use_bloom;

		/// <summary>
		/// инверсия [0/1]
		/// </summary>
		[Description("инверсия [0/1]")]
		private int use_inverse;

		/// <summary>
		/// использовать коррекцию яркость/констраст [0/1]
		/// </summary>
		[Description("использовать коррекцию яркость/констраст [0/1]")]
		private int use_br;

		/// <summary>
		/// использовать фильтр сглаживания [0/1]
		/// </summary>
		[Description("использовать фильтр сглаживания [0/1]")]
		private int use_blur;

		/// <summary>
		/// Значение яркости [-1 .. 1] 
		/// </summary>
		[Description("Значение яркости [-1 .. 1] ")]
		private float br_brightness;

		/// <summary>
		/// Значение контраста [0.0 .. 5.0]
		/// </summary>
		[Description("Значение контраста [0.0 .. 5.0]")]
		private float br_contrast;

		/// <summary>
		/// пороговое значение для засветки [0..1] 
		/// </summary>
		[Description("пороговое значение для засветки [0..1] ")]
		private float bright_pass_threshold;

		/// <summary>
		/// Размер шума [0.1 .. 5.0] 
		/// </summary>
		[Description("Размер шума [0.1 .. 5.0] ")]
		private float noise_size;

		/// <summary>
		/// Величина шума [0.0 .. 2.0]  
		/// </summary>
		[Description("Величина шума [0.0 .. 2.0]")]
		private float noise_scale;

		/// <summary>
		/// Величина отдельных всплесков [0.0 .. 2.0] 
		/// </summary>
		[Description("Величина отдельных всплесков [0.0 .. 2.0]")]
		private float noise_scin;

		/// <summary>
		/// Уровень серого при использовании адоптации [0.0 .. 1.0] 
		/// </summary>
		[Description("Уровень серого при использовании адоптации [0.0 .. 1.0]")]
		private float tv_lum_gray;

		/// <summary>
		/// Эффект межстрочной развертки [0..1]	
		/// </summary>
		[Description("Эффект межстрочной развертки [0..1]")]
		private float tv_grid_scale;

		/// <summary>
		/// Масштаб межстрочной развертки [0.1..5]	
		/// </summary>
		[Description("Масштаб межстрочной развертки [0.1..5]")]
		private float tv_grid_size;

		/// <summary>
		/// Гамма: lum = pow(lum,gamma) [0..2]	
		/// </summary>
		[Description("иГамма: lum = pow(lum,gamma) [0..2]")]
		private float tv_gamma;

		#endregion
	}
}
