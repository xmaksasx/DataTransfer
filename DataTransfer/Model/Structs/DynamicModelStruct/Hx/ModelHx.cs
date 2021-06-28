using DataTransfer.Infrastructure.Helpers;
using DataTransfer.Model.Structs.DynamicModelStruct.Vaps;
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

		public override byte[] GetForVaps(DynamicModelToVaps modelToVaps)
		{
			//todo: тут нужно заполнить модель

			modelToVaps.Eng1.N = VhclOutp.EngLeft.N1;
			modelToVaps.Eng1.Mode = 1;
			modelToVaps.Eng1.Egt= VhclOutp.EngLeft.Egt;
			modelToVaps.Eng1.MaxAllowedEgt = 0;
			modelToVaps.Eng1.EmergencyEgt = 0;
			modelToVaps.Eng1.EngState = 1;
			modelToVaps.Eng1.FuelFlow = VhclOutp.EngLeft.FuelFlow;

			modelToVaps.Eng2.N = VhclOutp.EngRight.N1;
			modelToVaps.Eng2.Mode = 1;
			modelToVaps.Eng2.Egt = VhclOutp.EngRight.Egt;
			modelToVaps.Eng2.MaxAllowedEgt = 0;
			modelToVaps.Eng2.EmergencyEgt = 0;
			modelToVaps.Eng2.EngState = 1;
			modelToVaps.Eng2.FuelFlow = VhclOutp.EngRight.FuelFlow;


			modelToVaps.ModeFly=1;
			modelToVaps.RemainingFuel= VhclOutp.InstrumentsState.FuelMass;
			modelToVaps.RotorSpeed = VhclOutp.InstrumentsState.RotorRPM;
			modelToVaps.MaximumPermissibleRotor =0;
			modelToVaps.TotalRotor = VhclOutp.InstrumentsState.CollectivePitch;
			modelToVaps.RecommendedValueRotor = 0;
			modelToVaps.HeadingCurrent = KinematicsState.Angs.Psi;
			modelToVaps.HeadingTrack = 0;
			modelToVaps.AngleDrift = 0;
			modelToVaps.Angleslip = VhclOutp.InstrumentsState.AirPars.Beta;
			modelToVaps.RollCurrent = KinematicsState.Angs.Gam;
			modelToVaps.MaximumPermissibleRoll = VhclInp.FCSState.RoolLimit;
			modelToVaps.RecommendedRollVlue = 0;
			modelToVaps.PitchCurrent = KinematicsState.Angs.Fi;
			modelToVaps.RecommendedPitchValue = 0;
			modelToVaps.RermissiblePitchPitching = 0;
			modelToVaps.PermissiblePitchDiving = 0;
			modelToVaps.AngleAttack = VhclOutp.InstrumentsState.AirPars.AOA;
			modelToVaps.PermissibleAngleAttack = 0;
			modelToVaps.PositionBall = VhclOutp.InstrumentsState.SlipBallPos;
			modelToVaps.AngleTrajectory = 0;
			modelToVaps.Vy = VhclOutp.InstrumentsState.VyVar;
			modelToVaps.MinVy=0;
			modelToVaps.MaxVy=0;
			modelToVaps.InstrumentSpeedCurrent = VhclOutp.InstrumentsState.IAS;
			modelToVaps.MaxInstrumentSpeed = 0;
			modelToVaps.MinInstrumentSpeed = 0;
			modelToVaps.SpeedX = KinematicsState.Accel.X;
			modelToVaps.SpeedZ = KinematicsState.Accel.X;
			modelToVaps.RecommendedDiveSpeed = 0;
			modelToVaps.RecommendedSpeedDiveEnd = 0;
			modelToVaps.TrueSpeedCurrent = VhclOutp.InstrumentsState.TAS;
			modelToVaps.GroundSpeedX = VhclOutp.InstrumentsState.VsurfX;
			modelToVaps.GroundSpeedZ = VhclOutp.InstrumentsState.VsurfZ;
			modelToVaps.Mach = 0;
			modelToVaps.RelativeHeight = KinematicsState.Pos.Elevation;
			modelToVaps.BarometricHeight = VhclOutp.InstrumentsState.Hbaro;
			modelToVaps.Pressure = VhclInp.VehicleCtrl.AltimeterBaroPressure;
			modelToVaps.HeightAltimeter = 0;
			modelToVaps.DangerousHeight = 0;

			modelToVaps.Ny.Value= VhclOutp.InstrumentsState.GLoad.Y;
			modelToVaps.Ny.Min = 0;
			modelToVaps.Ny.Max = 0;

			modelToVaps.Nx.Value = VhclOutp.InstrumentsState.GLoad.X;
			modelToVaps.Nx.Min = 0;
			modelToVaps.Nx.Max = 0;

			modelToVaps.Nz.Value = VhclOutp.InstrumentsState.GLoad.Z;
			modelToVaps.Nz.Min = 0;
			modelToVaps.Nz.Max = 0;

			modelToVaps.HeadingWind =0;
			modelToVaps.HorizontalWindSpeed = VhclInp.AirState.WindSpeed.X;
			modelToVaps.MaxPermissibleWindSpeed = 0;

			modelToVaps.Mechanization[0] = VhclOutp.NoseGear.RodShift;
			modelToVaps.Mechanization[1] = VhclOutp.NoseGear.TireShift;
			modelToVaps.Mechanization[2] = VhclOutp.NoseGear.WheelRot;
			modelToVaps.Mechanization[3] = VhclOutp.NoseGear.WheelSteer;

			modelToVaps.Mechanization[4] = VhclOutp.MainGearLeft.RodShift;
			modelToVaps.Mechanization[5] = VhclOutp.MainGearLeft.TireShift;
			modelToVaps.Mechanization[6] = VhclOutp.MainGearLeft.WheelRot;
			modelToVaps.Mechanization[7] = VhclOutp.MainGearLeft.WheelSteer;

			modelToVaps.Mechanization[8] = VhclOutp.MainGearRight.RodShift;
			modelToVaps.Mechanization[9] = VhclOutp.MainGearRight.TireShift;
			modelToVaps.Mechanization[10] = VhclOutp.MainGearRight.WheelRot;
			modelToVaps.Mechanization[11] = VhclOutp.MainGearRight.WheelSteer;

			var dgram = ConvertHelper.ObjectToByte(modelToVaps);
			for (int i = 68; i < dgram.Length; i = i + 4)
				Array.Reverse(dgram, i, 4);
			return dgram;
		}


		public ModelHx()
			{
				KinematicsState = new KinematicsState();
				VhclOutp = new VhclOutp();
			VhclInp = new VhclInp();
			}

			public KinematicsState KinematicsState;
			public VhclOutp VhclOutp;
		public VhclInp VhclInp;
	}
	}
