using DataTransfer.Infrastructure.Helpers;
using DataTransfer.Model.Structs.DynamicModelStruct.Vaps;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DataTransfer.Model.Structs.Bmpi;

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

		public override byte[] GetPosition(AircraftPosition aircraftPosition)
		{
			aircraftPosition.IsDegree=1;
			aircraftPosition.Tang=KinematicsState.Angs.Fi;
			aircraftPosition.Kren=KinematicsState.Angs.Gam;
			aircraftPosition.Risk=KinematicsState.Angs.Psi;
			aircraftPosition.GeoCoordinate.Latitude=KinematicsState.Pos.Latitude;
			aircraftPosition.GeoCoordinate.Longitude= KinematicsState.Pos.Longitude;
			aircraftPosition.GeoCoordinate.H= KinematicsState.Pos.Elevation;
			aircraftPosition.GeoCoordinate.X= 0;
			aircraftPosition.GeoCoordinate.Z = 0;
			return ConvertHelper.ObjectToByte(aircraftPosition);
		}

		public override byte[] GetForVaps(DynamicModelToVaps modelToVaps)
		{
			double Vpth = Math.Sqrt(KinematicsState.AbsSpeed.X * KinematicsState.AbsSpeed.X + KinematicsState.AbsSpeed.Z * KinematicsState.AbsSpeed.Z); // м/с
			double PsiP = Math.Asin(KinematicsState.AbsSpeed.Z / Vpth);
			double D2R = 180 / Math.PI;
			double Psi = KinematicsState.Angs.Psi;
			double psi_hi, psi_p_hi; // значения угла курса и путевого угла +-Pi (+-180)
			if (PsiP >= 0) psi_p_hi = PsiP;
			else psi_p_hi = PsiP - 2.0 * Math.PI; // путевой угол +-Pi (+-180)
			if (Psi >= 0) psi_hi = Psi;
			else psi_hi = Psi - 2.0 * Math.PI; // угол курса +-Pi (+-180)
			double hi = psi_p_hi - psi_hi; // угол сноса +-Pi (+-180)
			if (hi >= Math.PI) hi = hi - 2.0 * Math.PI;
			if (hi <= -Math.PI) hi = hi + 2.0 * Math.PI;

			double Tetr = 0; // угол наклона траектории, рад
							 // 1 вариант
			if (VhclOutp.InstrumentsState.TAS != 0)
				Tetr = Math.Asin(KinematicsState.AbsSpeed.Y / VhclOutp.InstrumentsState.TAS);

			// 2 вариант, альтернативно
			// истинная воздушная скорость полета
			double Vp = Math.Sqrt(
				KinematicsState.AbsSpeed.X
				* KinematicsState.AbsSpeed.X
				+ KinematicsState.AbsSpeed.Y
				* KinematicsState.AbsSpeed.Y
				+ KinematicsState.AbsSpeed.Z
				* KinematicsState.AbsSpeed.Z);

			//(кинематическая)м / с
			if (Vp != 0)
				Tetr = Math.Asin(KinematicsState.AbsSpeed.Y / Vp);

			// ограничение для обоих вараинтов
			if (Tetr > Math.PI / 2.0) Tetr = Tetr - Math.PI / 2.0;
			if (Tetr < -Math.PI / 2.0) Tetr = Tetr + Math.PI / 2.0;


			//todo: тут нужно заполнить модель

			modelToVaps.Eng1.N = VhclOutp.EngLeft.N1;
			modelToVaps.Eng1.Mode = 1;
			modelToVaps.Eng1.Egt = VhclOutp.EngLeft.Egt;
			modelToVaps.Eng1.MaxAllowedEgt = 705;
			modelToVaps.Eng1.EmergencyEgt = 735;
			modelToVaps.Eng1.EngState = 1;
			modelToVaps.Eng1.FuelFlow = VhclOutp.EngLeft.FuelFlow;

			modelToVaps.Eng2.N = VhclOutp.EngRight.N1;
			modelToVaps.Eng2.Mode = 1;
			modelToVaps.Eng2.Egt = VhclOutp.EngRight.Egt;
			modelToVaps.Eng2.MaxAllowedEgt = 705;
			modelToVaps.Eng2.EmergencyEgt = 735;
			modelToVaps.Eng2.EngState = 1;
			modelToVaps.Eng2.FuelFlow = VhclOutp.EngRight.FuelFlow;


			modelToVaps.ModeFly = 1;
			modelToVaps.RemainingFuel = VhclOutp.InstrumentsState.FuelMass;
			modelToVaps.RotorSpeed = VhclOutp.InstrumentsState.RotorRPM;

			//todo: нужно написать условия о смене значения от скорости
			///98	-	до 200
			///93	-	от 200 до 270
			///91	-	от 270 до 300
			modelToVaps.MaximumPermissibleRotor = 93;
			modelToVaps.TotalRotor = VhclOutp.InstrumentsState.CollectivePitch;
			modelToVaps.RecommendedValueRotor = 0;
			modelToVaps.HeadingCurrent = 360.0-KinematicsState.Angs.Psi;
			modelToVaps.HeadingTrack = PsiP * D2R;
			modelToVaps.AngleDrift = hi * D2R;
			modelToVaps.Angleslip = VhclOutp.InstrumentsState.AirPars.Beta;
			modelToVaps.RollCurrent = KinematicsState.Angs.Gam;
			modelToVaps.MaximumPermissibleRoll = VhclInp.FCSState.RoolLimit;
			modelToVaps.RecommendedRollValue = 0;
			modelToVaps.PitchCurrent = KinematicsState.Angs.Fi;
			modelToVaps.RecommendedPitchValue = 0;
			modelToVaps.RermissiblePitchPitching = 60;
			modelToVaps.PermissiblePitchDiving = -60;
			modelToVaps.AngleAttack = VhclOutp.InstrumentsState.AirPars.AOA;
			modelToVaps.PermissibleAngleAttack = 0;
			modelToVaps.PositionBall = VhclOutp.InstrumentsState.SlipBallPos;
			modelToVaps.AngleTrajectory = Tetr * D2R;
			modelToVaps.Vy = VhclOutp.InstrumentsState.VyVar;
			modelToVaps.MinVy = -5;
			modelToVaps.MaxVy = +5;
			modelToVaps.InstrumentSpeedCurrent = VhclOutp.InstrumentsState.IAS * 3.6;
			modelToVaps.MaxInstrumentSpeed = 300;
			modelToVaps.MinInstrumentSpeed = 50;
			modelToVaps.SpeedX = VhclOutp.InstrumentsState.VsurfX;
			modelToVaps.SpeedZ = VhclOutp.InstrumentsState.VsurfZ;
			modelToVaps.RecommendedDiveSpeed = 0;
			modelToVaps.RecommendedSpeedDiveEnd = 0;
			modelToVaps.TrueSpeedCurrent = VhclOutp.InstrumentsState.TAS * 3.6;
			modelToVaps.GroundSpeedX = KinematicsState.AbsSpeed.X * 3.6;
			modelToVaps.GroundSpeedZ = KinematicsState.AbsSpeed.Z * 3.6;
			modelToVaps.Mach = VhclOutp.InstrumentsState.TAS / 343.0;
			modelToVaps.RelativeHeight = KinematicsState.Pos.Elevation;
			modelToVaps.BarometricHeight = VhclOutp.InstrumentsState.Hbaro;
			modelToVaps.Pressure = VhclInp.VehicleCtrl.AltimeterBaroPressure;

			//минус высота рельефа
			modelToVaps.HeightAltimeter = KinematicsState.Pos.Elevation;
			modelToVaps.DangerousHeight = 50;

			modelToVaps.Ny.Value = VhclOutp.InstrumentsState.GLoad.Y;
			modelToVaps.Ny.Min = -0.5;
			modelToVaps.Ny.Max = 2.5;

			modelToVaps.Nx.Value = VhclOutp.InstrumentsState.GLoad.X;
			modelToVaps.Nx.Min = 0;
			modelToVaps.Nx.Max = 0;

			modelToVaps.Nz.Value = VhclOutp.InstrumentsState.GLoad.Z;
			modelToVaps.Nz.Min = 0;
			modelToVaps.Nz.Max = 0;

			modelToVaps.HeadingWind = 0;
			modelToVaps.HorizontalWindSpeed = Math.Sqrt(
				VhclInp.AirState.WindSpeed.X *
				VhclInp.AirState.WindSpeed.X +
				VhclInp.AirState.WindSpeed.Z *
				VhclInp.AirState.WindSpeed.Z);

			modelToVaps.MaxPermissibleWindSpeed = 25;

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

		public override byte[] GetForBmpi(DynamicModelToBmpi modelToBmpi)
		{
			modelToBmpi.lat_sns = KinematicsState.Pos.Latitude;
			modelToBmpi.lon_sns = KinematicsState.Pos.Longitude;
			modelToBmpi.H_sns = KinematicsState.Pos.Elevation;
			modelToBmpi.Day = (ushort)DateTime.Now.Day;
			modelToBmpi.Month = (ushort)DateTime.Now.Month;
			modelToBmpi.Year = (ushort)DateTime.Now.Year;
			modelToBmpi.Minute = (ushort)DateTime.Now.Minute;
			modelToBmpi.Hour = (ushort)DateTime.Now.Hour;
			modelToBmpi.Second = (ushort)DateTime.Now.Second;
			modelToBmpi.FPU_sns = 0;
			modelToBmpi.Vputev_sns = 0;//??
			modelToBmpi.Vy_sns = (float)VhclOutp.InstrumentsState.VyVar;
			modelToBmpi.Vxg = (float)(VhclOutp.InstrumentsState.VsurfX * 1.944);
			modelToBmpi.Vzg = (float)(VhclOutp.InstrumentsState.VsurfZ * 1.944);

			modelToBmpi.lat_ins = KinematicsState.Pos.Latitude;
			modelToBmpi.lon_ins = KinematicsState.Pos.Longitude;
			modelToBmpi.Vputev_ins = 0;//??
			modelToBmpi.PU = (float)KinematicsState.Angs.Psi;//??
			modelToBmpi.PsiIst = (float)KinematicsState.Angs.Psi;
			modelToBmpi.Uwind = (float)(VhclInp.AirState.WindSpeed.X * 3.6);
			modelToBmpi.AlfaWind = 0;
			modelToBmpi.FPUmagn = 0;//??
			modelToBmpi.PSImagn = 0;//??
			modelToBmpi.Snos = 0;//??
			modelToBmpi.Teta = (float)KinematicsState.Angs.Fi;
			modelToBmpi.Gamma = (float)KinematicsState.Angs.Gam;
			modelToBmpi.OmegaZ = (float)KinematicsState.Rotation.Z;
			modelToBmpi.OmegaX = (float)KinematicsState.Rotation.X;
			modelToBmpi.OmegaY = (float)KinematicsState.Rotation.Y;
			modelToBmpi.JX = (float)KinematicsState.Accel.X;
			modelToBmpi.JZ = (float)KinematicsState.Accel.Z;
			modelToBmpi.JY = (float)KinematicsState.Accel.Y;
			modelToBmpi.JYg = 0;//??

			modelToBmpi.Hotn_QFE = (float)KinematicsState.Pos.Elevation;//??
			modelToBmpi.Hotn_QNH = (float)KinematicsState.Pos.Elevation;//??
			modelToBmpi.Vpr = (float)VhclOutp.InstrumentsState.IAS;
			modelToBmpi.Hbar_abs = (float)KinematicsState.Pos.Elevation;
			modelToBmpi.Vist = (float)VhclOutp.InstrumentsState.TAS;
			modelToBmpi.Tvozd = (float)VhclOutp.InstrumentsState.AirPars.TAT;

			modelToBmpi.Hrv = (float)KinematicsState.Pos.Elevation; ;

			modelToBmpi.lat_vpp = 0;
			modelToBmpi.lon_vpp = 0;
			modelToBmpi.Hzad = 0;
			modelToBmpi.TOffset_Minute = 0;
			modelToBmpi.TOffset_Hour = 0;
			modelToBmpi.TOffset_Second = 0;
			return ConvertHelper.ObjectToByte(modelToBmpi);
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
