using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.AerodromeStruct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Aerodrome
    {
        /// <summary>
        /// Название аэропорта на кириллице
        /// </summary>
        [Description("Название аэропорта на кириллице")]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public char[] Name;

        
        /// <summary>
        /// Информация о взлетной полосе
        /// </summary>
        [Description("Информация о взлетной полосе")]
        public RunwayInfo Runway;


    }
}
