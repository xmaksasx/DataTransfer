using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Ka50Model.Models
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class Pedals
	{
		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("Педали")] public float Pedal;
		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("Reserv")] public float Reserv1;
		
		/// <summary>
		/// аналоговые сигналы
		/// </summary>
		[Description("Reserv")] public float Reserv2;
	}
}
