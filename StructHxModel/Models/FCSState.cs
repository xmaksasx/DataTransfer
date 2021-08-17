using System.Runtime.InteropServices;

namespace StructHxModel.Models
{
	// параметры, необходимые для работы системы управления:
	[StructLayout(LayoutKind.Sequential,Pack = 1)]
	public struct FCSState
	{
		//public FCSState()
		//{
		//	TurnCoordSpd = 80;
		//	TurnCoordination = true;
		//	PitchChnl.StickTrimmedPos = 0.5;
		//	PitchChnl.StickAngleSpd = 9;
		//	PitchChnl.StickDeadzone = 0.02;
		//	PitchChnl.MinAngle = -12;
		//	PitchChnl.MaxAngle = 16;

		//	RollChnl.StickTrimmedPos = 0.5;
		//	RollChnl.StickAngleSpd = 22;
		//	RollChnl.StickDeadzone = 0.02;
		//	RollChnl.MinAngle = -24;
		//	RollChnl.MaxAngle = 24;
		//}
      public  uint Mode;  // режим работы системы упрвления: 0 - Direct, 1 - AugmentedStability, 2 - TrimmeredStick(Classic), 3 - Auto

        // уставочные параметры системы управления, обрабатываются только при Mode = Auto :
        public FCSValue HorSpeedReq; // заданная горизонтальная скорость (приборная), м/с
        public FCSValue VertSpeedReq; // заданная вертикальная скорость, м/с
        public FCSValue HdgReq; // заданный угол курса, град
        public FCSValue BaroAltitudeReq; // заданная барометрическая высота, м

		// настройка каналов управления:
		public FCSCtrlChnl PitchChnl;
		public FCSCtrlChnl RollChnl;


		//public double RoolLimit; // велична ограничения по углу крена, град
		// прочие параметры настройки органов управления 
		public double TurnCoordSpd; // скорость включения автокоординирования разворота, км/ч
		public byte TurnCoordination; // признак допустимости включения автокоординирования разворота;

    }
}