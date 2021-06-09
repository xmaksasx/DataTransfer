using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using DataTransfer.Model.Component.BaseComponent;

namespace DataTransfer.Model.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Landing : Base
    {
	    protected override void SetHead()
	    {
		    GetHeadDouble("Landing");
	    }

	    public override void Reverse(ref byte[] dgram)
	    {
		    for (int i = 68; i < dgram.Length; i = i + 8)
			    Array.Reverse(dgram, i, 8);
	    }
        /// <summary>
        /// Удаление от торца ВПП
        /// </summary>
        [Description("Удаление от торца ВПП")]
        public double DistanceToRwy;

        /// <summary>
        /// Признак прохода БПРМ
        /// </summary>
        [Description("Признак прохода БПРМ")]
        public double PassedLocatorMiddle;

        /// <summary>
        /// Признак прохода ДПРМ
        /// </summary>
        [Description("Признак прохода ДПРМ")]
        public double PassedLocatorOuter;

        /// <summary>
        /// Положение курсой планки
        /// </summary>
        [Description("Положение курсой планки")]
        public double IndicatorLoc;

        /// <summary>
        /// Положение глиссадной планки
        /// </summary>
        [Description("Положение глиссадной планки")]
        public double IndicatorGs;

        /// <summary>
        /// Признак отображения курсовой планки
        /// </summary>
        [Description("Признак отображения курсовой планки")]
        public double IndicatorLocIsVisible;

        /// <summary>
        /// Признак отображения глиссадной планки
        /// </summary>
        [Description("Признак отображения глиссадной планки")]
        public double IndicatorGsIsVisible;

        /// <summary>
        /// Курс на ДПРМ
        /// </summary>
        [Description("Курс на ДПРМ")]
        public double CourseOM;

        /// <summary>
        /// Удаление от ДПРМ
        /// </summary>
        [Description("Удаление от ДПРМ")]
        public double DistanceToOM;
    }
}
