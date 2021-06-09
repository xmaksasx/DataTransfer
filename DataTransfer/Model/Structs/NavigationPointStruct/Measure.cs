using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs.NavigationPointStruct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Measure
    {
	    /// <summary>
	    /// курс заданный на НТ
	    /// </summary>
	    [Description("курс заданный на НТ")] public double Psi;

	    /// <summary>
	    /// заданный путевой угол на НТ
	    /// </summary>
	    [Description("заданный путевой угол на НТ")]

	    public double PsiPath;

	    /// <summary>
	    /// радиус прохода ППМ
	    /// </summary>
	    [Description("радиус прохода ППМ")] public double RDetect;

	    /// <summary>
	    /// дистанция относительно ЛА
	    /// </summary>
	    [Description("дистанция относительно ЛА")]
	    public double Distance;

        /// <summary>
        /// оставшееся время полета до НТ (сек)
        /// </summary>
        [Description("оставшееся время полета до НТ (сек)")]
        public double RemainingTime;
    }
}
