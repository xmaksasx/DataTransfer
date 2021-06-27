using System.ComponentModel;
using System.Runtime.InteropServices;

namespace HxModel.Models
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ControlElement : Header
	{
		protected int Channel;
		public CyclicStepHandle _cyclicStepHandleLeft;
		public CyclicStepHandle _cyclicStepHandleRight;
		public GeneralStepHandle _generalStepHandleLeft;
		public GeneralStepHandle _generalStepHandleRight;
		public Pedals _pedalsLeft;
		public Pedals _pedalsRight;

		public ControlElement()
		{
			_cyclicStepHandleLeft = new CyclicStepHandle();
			_cyclicStepHandleRight = new CyclicStepHandle();
			_generalStepHandleLeft = new GeneralStepHandle();
			_generalStepHandleRight = new GeneralStepHandle();
			_pedalsLeft = new Pedals();
			_pedalsRight = new Pedals();
		}
	}
}