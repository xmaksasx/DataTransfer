using System.Runtime.InteropServices;
using DataTransfer.Model.Component.BaseComponent;

namespace DataTransfer.Model.Structs
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ChannelTvHeadEffectStruct : Base
	{
		#region Fields
		/// <summary>
		/// использовать адаптацию яркости [0/1]
		/// </summary>
		private int use_tone_map;

		/// <summary>
		/// использовать шум [0/1]
		/// </summary>
		private int use_time_noise;

		/// <summary>
		/// использовать эффект засветки [0/1]
		/// </summary>
		private int use_bloom;

		/// <summary>
		/// инверсия [0/1]
		/// </summary>
		private int use_inverse;

		/// <summary>
		/// использовать коррекцию яркость/констраст [0/1]
		/// </summary>
		private int use_br;

		/// <summary>
		/// использовать фильтр сглаживания [0/1]
		/// </summary>
		private int use_blur;

		/// <summary>
		/// Значение яркости [-1 .. 1] 
		/// </summary>
		private float br_brightness;

		/// <summary>
		///  Значение контраста [0.0 .. 5.0]
		/// </summary>
		private float br_contrast;

		/// <summary>
		/// пороговое значение для засветки [0..1] 
		/// </summary>
		private float bright_pass_threshold;

		/// <summary>
		/// Размер шума [0.1 .. 5.0] 
		/// </summary>
		private float noise_size;

		/// <summary>
		/// Величина шума [0.0 .. 2.0]  
		/// </summary>
		private float noise_scale;

		/// <summary>
		/// Величина отдельных всплесков [0.0 .. 2.0] 
		/// </summary>
		private float noise_scin;

		/// <summary>
		/// Уровень серого при использовании адоптации [0.0 .. 1.0] 
		/// </summary>
		private float tv_lum_gray;

		/// <summary>
		/// Эффект межстрочной развертки [0..1]	
		/// </summary>
		private float tv_grid_scale;

		/// <summary>
		/// Масштаб межстрочной развертки [0.1..5]	
		/// </summary>
		private float tv_grid_size;

		/// <summary>
		/// Гамма: lum = pow(lum,gamma) [0..2]	
		/// </summary>
		private float tv_gamma;

		#endregion
	}
}
