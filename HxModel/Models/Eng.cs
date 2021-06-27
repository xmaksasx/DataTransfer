using System.Runtime.InteropServices;

namespace HxModel.Models
{
	// Параметры двигателя:
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	struct Eng
	{
		double N1;      // обороты вентилятора, (% от номинальной величины)) 
		double N2;      // обороты турбокомпрессора, (% от номинальной величины)
		double Egt;     // температура газов за турбиной, (град С)
		double FuelFlow;// расход топлива данным двигателем, кг/ч
	}
}
