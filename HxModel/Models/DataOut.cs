using System.Runtime.InteropServices;

namespace HxModel.Models
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class DataOut : Header
	{
		public DataOut()
		{
			GetHeadDouble("DynamicModelHx");
		}

		public KinematicsState KinematicsState;
		public VhclOutp VhclOutp;
		public VhclInp VhclInp;
	}
}
