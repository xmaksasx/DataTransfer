using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using DataTransfer.Infrastructure.Helpers;
using DataTransfer.Model.Component;
using DataTransfer.Model.Component.BaseComponent;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Ka50
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ModelKa50 : DynamicModel
	{
		protected override void SetHead()
		{
			GetHeadDouble("ModelKa52");
		}

		public override void Reverse(ref byte[] dgram)
		{
			for (int i = 68; i < dgram.Length; i = i + 8)
				Array.Reverse(dgram, i, 8);
		}


		public override byte[] GetPosition()
		{
			List<byte> lst = new List<byte>();
			lst.AddRange(BitConverter.GetBytes(KinematicsState.Angs.Fi));
			lst.AddRange(BitConverter.GetBytes(KinematicsState.Angs.Gam));
			lst.AddRange(BitConverter.GetBytes(KinematicsState.Angs.Psi));
			lst.AddRange(BitConverter.GetBytes(KinematicsState.Pos.Latitude));
			lst.AddRange(BitConverter.GetBytes(KinematicsState.Pos.Longitude));
			lst.AddRange(BitConverter.GetBytes(KinematicsState.Pos.Elevation));
			lst.AddRange(BitConverter.GetBytes(0));
			lst.AddRange(BitConverter.GetBytes(0));
			return lst.ToArray();
		}


		public ModelKa50()
		{
			KinematicsState = new KinematicsState();
			VhclOutp = new VhclOutp();
		}

		public KinematicsState KinematicsState;
		public VhclOutp VhclOutp;
	}
}
