using System.Runtime.InteropServices;

namespace Ka50Model.Models
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class DataOut:Header
	{
		public DataOut()
		{
			GetHeadDouble("DynamicModelKa50");
		}
	
		public KinematicsState KinematicsState;
		public VhclOutp VhclOutp;
	}
}
