using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using DataTransfer.Model.Component;
using DataTransfer.Model.Component.BaseComponent;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Ka50
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ModelKa50 : DynamicModel
	{
		protected override void SetHead()
		{
			GetHeadDouble("DynamicModelKa52");
		}

		public override void Reverse(ref byte[] dgram)
		{
			for (int i = 68; i < dgram.Length; i = i + 8)
				Array.Reverse(dgram, i, 8);
		}


	


		public ModelKa50()
		{
			KinematicsState = new KinematicsState();
			VhclOutp = new VhclOutp();
		}

		private KinematicsState KinematicsState;
		private VhclOutp VhclOutp;
	}
}
