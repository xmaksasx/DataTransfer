using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Model
{
	class SimulationManagement
	{
		// 0 - стоп
		// 1 - старт
		// 2 - пауза
		// Команда на управление
		private double ModeState;

		// 0 - автопилот
		// 1 - сеть
		// 2 - джойстик НИИЭС
		// 3 - локальный джойстик
		// Тип огранов управления
		private double TypeCockpit;

	}
}
