using DataTransfer.Infrastructure.Helpers;
using DataTransfer.Model.Structs.DynamicModelStruct.Vaps;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Ka50
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ModelKa50 : DynamicModel
	{
		protected override void SetHead()
		{
			GetHeadDouble("ModelKa50");
		}

		public override void Reverse(ref byte[] dgram)
		{
			for (int i = 68; i < dgram.Length; i = i + 8)
				Array.Reverse(dgram, i, 8);
		}

	


		public override byte[] GetPosition(AircraftPosition aircraftPosition)
		{
			aircraftPosition.IsDegree = 1;
			aircraftPosition.Tang = KinematicsState.Angs.Fi;
			aircraftPosition.Kren = KinematicsState.Angs.Gam;
			aircraftPosition.Risk = KinematicsState.Angs.Psi;
			aircraftPosition.GeoCoordinate.Latitude = KinematicsState.Pos.Latitude;
			aircraftPosition.GeoCoordinate.Longitude = KinematicsState.Pos.Longitude;
			aircraftPosition.GeoCoordinate.H = KinematicsState.Pos.Elevation;
			aircraftPosition.GeoCoordinate.X = 0;
			aircraftPosition.GeoCoordinate.X = 0;
			return ConvertHelper.ObjectToByte(aircraftPosition);
		}


		public override byte[] GetForVaps(DynamicModelToVaps modelToVaps)
		{
			//todo: тут нужно заполнить модель

			modelToVaps.Eng1.N = VhclOutp.EngLeft.N1;
			modelToVaps.Eng1.Mode = 1;
			modelToVaps.Eng1.Egt = VhclOutp.EngLeft.Egt;
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


			modelToVaps.ModeFly = 1;
			modelToVaps.RemainingFuel = 0;
			modelToVaps.RotorSpeed = VhclOutp.RotorRPM;
			modelToVaps.MaximumPermissibleRotor = 0;
			modelToVaps.TotalRotor = VhclOutp.CollectivePitch;
			modelToVaps.RecommendedValueRotor = 0;
			modelToVaps.HeadingCurrent = KinematicsState.Angs.Psi;
			modelToVaps.HeadingTrack = 0;
			modelToVaps.AngleDrift = 0;
			modelToVaps.Angleslip = 0;
			modelToVaps.RollCurrent = KinematicsState.Angs.Gam;
			modelToVaps.MaximumPermissibleRoll = 0;
			modelToVaps.RecommendedRollVlue = 0;
			modelToVaps.PitchCurrent = KinematicsState.Angs.Fi;
			modelToVaps.RecommendedPitchValue = 0;
			modelToVaps.RermissiblePitchPitching = 0;
			modelToVaps.PermissiblePitchDiving = 0;
			modelToVaps.AngleAttack = 0;
			modelToVaps.PermissibleAngleAttack = 0;
			modelToVaps.PositionBall = 0;
			modelToVaps.AngleTrajectory = 0;
			modelToVaps.Vy = 0;
			modelToVaps.MinVy = 0;
			modelToVaps.MaxVy = 0;
			modelToVaps.InstrumentSpeedCurrent = 0;
			modelToVaps.MaxInstrumentSpeed = 0;
			modelToVaps.MinInstrumentSpeed = 0;
			modelToVaps.SpeedX = KinematicsState.Accel.X;
			modelToVaps.SpeedZ = KinematicsState.Accel.X;
			modelToVaps.RecommendedDiveSpeed = 0;
			modelToVaps.RecommendedSpeedDiveEnd = 0;
			modelToVaps.TrueSpeedCurrent = 0;
			modelToVaps.GroundSpeedX = 0;
			modelToVaps.GroundSpeedZ = 0;
			modelToVaps.Mach = 0;
			modelToVaps.RelativeHeight = KinematicsState.Pos.Elevation;
			modelToVaps.BarometricHeight = 0;
			modelToVaps.Pressure = 0;
			modelToVaps.HeightAltimeter = 0;
			modelToVaps.DangerousHeight = 0;

			modelToVaps.Ny.Value = 0;
			modelToVaps.Ny.Min = 0;
			modelToVaps.Ny.Max = 0;

			modelToVaps.Nx.Value = 0;
			modelToVaps.Nx.Min = 0;
			modelToVaps.Nx.Max = 0;

			modelToVaps.Nz.Value = 0;
			modelToVaps.Nz.Min = 0;
			modelToVaps.Nz.Max = 0;

			modelToVaps.HeadingWind = 0;
			modelToVaps.HorizontalWindSpeed = 0;
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
			for (int i = 68; i < dgram.Length; i = i + 8)
				Array.Reverse(dgram, i, 8);
			return dgram;
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
