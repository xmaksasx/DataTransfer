using System.ComponentModel;

namespace DataTransfer.Model.Structs.ControlElements
{
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
