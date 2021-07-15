using System.Runtime.InteropServices;


namespace DataTransfer.Model.Structs.Brunner
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class CLSEState
    {
        public double PositionZ;       // текущее фактическое продольное положение ручки (0-1)
        public double PositionX;       // текущее фактическое поперечное положение ручки (0-1)
        double TrimPositionZ;   // текущее нейтральное положение пружинной загружки по продольном каналу (0-1)
        double TrimPositionX;   // текущее нейтральное положение пружинной загружки по поперечному каналу (0-1)
        public uint Buttons;       // битовая маска состояния нажатия кнопок ручки

        public CLSEState()
        {

            PositionZ = 0.5;
            PositionX = 0.5;
            TrimPositionZ = 0.5; TrimPositionX = 0.5;
            Buttons = 0;
        }

    }
}
