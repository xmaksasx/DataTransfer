using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.Route
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Measure
    {
        /// <summary>
        /// курс заданный на НТ
        /// </summary>
        [Description("курс заданный на НТ")]
        public double Psi { get; set; }

        /// <summary>
        /// заданный путевой угол на НТ
        /// </summary>
        [Description("заданный путевой угол на НТ")]
        public double PsiPath { get; set; }

        /// <summary>
        /// радиус прохода ППМ
        /// </summary>
        [Description("радиус прохода ППМ")]
        public double RDetect { get; set; }

        /// <summary>
        /// дистанция относительно ЛА
        /// </summary>
        [Description("дистанция относительно ЛА")]
        public double Distance { get; set; }

        /// <summary>
        /// оставшееся время полета до НТ (сек)
        /// </summary>
        [Description("оставшееся время полета до НТ (сек)")]
        public double RemainingTime;
    }
}
