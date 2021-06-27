using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Hx
{

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		class ModelHx : DynamicModel
		{
			protected override void SetHead()
			{
				GetHeadDouble("ModelHx");
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


			public ModelHx()
			{
				KinematicsState = new KinematicsState();
				VhclOutp = new VhclOutp();
			}

			public KinematicsState KinematicsState;
			public VhclOutp VhclOutp;
		}
	}
