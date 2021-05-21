using DataTransfer.Model.Component.Base;
using DataTransfer.Model.Structs;

namespace DataTransfer.Model.Component
{
	class SimulationManagement : BaseComponent
	{
		private SimulationManagementStruct _simulationManagement;

		public SimulationManagement()
		{
			_simulationManagement = new SimulationManagementStruct();
		}
	}
}
