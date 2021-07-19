using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Pue.Models
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
	class DynamicModel : Header
	{
		public DynamicModel()
		{
			GetHeadDouble("DynamicModelToVaps");
		}

        #region Обновление данных

        public void Update(ObservableCollection<CollectionInfo> lst)
        {

            if (lst.Count == 0)
                SearchFields(GetType(), GetType().Name, "", lst);
            UpdateCollection(this, GetType().Name, lst);
        }

        private void SearchFields(Type type, string parentName, string parentDescription,
            ObservableCollection<CollectionInfo> lst)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsPrimitive || field.FieldType == typeof(string))
                {
                    AddToCollection(field, parentName, parentDescription, lst);
                }
                else if (field.FieldType.IsClass && !field.FieldType.IsArray)
                {
                    var curDescription = GetDescription(field);
                    SearchFields(field.FieldType, field.Name, curDescription, lst);
                }
                else if (!field.FieldType.IsPrimitive && field.FieldType.IsValueType)
                {
                    var curDescription = GetDescription(field);
                    SearchFields(field.FieldType, field.Name, curDescription, lst);
                }
            }
        }

        private string GetDescription(FieldInfo fieldInfo)
        {
            string curDescription = "";
            if (fieldInfo.GetCustomAttribute<DescriptionAttribute>() != null &&
                fieldInfo.GetCustomAttribute<DescriptionAttribute>().Description != null)
                curDescription = fieldInfo.GetCustomAttribute<DescriptionAttribute>().Description;
            return curDescription;
        }

        private void AddToCollection(FieldInfo fieldInfo, string parentName, string parentDescription, ObservableCollection<CollectionInfo> lst)
        {
            string curDescription = GetDescription(fieldInfo);
            if (string.IsNullOrEmpty(curDescription))
                curDescription = parentDescription;
            lst.Add(new CollectionInfo()
            {
                Name = parentName + "." + fieldInfo.Name,
                Description = curDescription,
                Value = "0"
            });
        }

        private void UpdateCollection(object obj, string parentName, ObservableCollection<CollectionInfo> lst)
        {
            if (obj == null) return;
            FieldInfo[] Fields = obj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            foreach (FieldInfo field in Fields)
            {
                object fieldValue = field.GetValue(obj);
                if (field.FieldType.IsPrimitive || field.FieldType == typeof(string))
                {
                    var name = parentName + "." + field.Name;
                    var found = lst.FirstOrDefault(x => x.Name == name);
                    if (found != null)
                    {
                        var value = fieldValue.ToString();
                        found.Value = value?.Substring(0, Math.Min(value.Length, 8));
                    }
                }
                else
                {
                    UpdateCollection(fieldValue, field.Name, lst);
                }
            }
        }

        #endregion

        [Description("Двигатель1")]
		public Eng Eng1 = new Eng();
		[Description("Двигатель2")]
		public Eng Eng2 = new Eng();
		[Description("Двигатель3")]
		public Eng Eng3 = new Eng();
		[Description("Двигатель4")]
		public Eng Eng4 = new Eng();

		[Description("режим полета(шасси не на земле)")]
		public double ModeFly;
		[Description("остаток топлива, кг")]
		public double RemainingFuel;
		[Description("обороты винта")]
		public double RotorSpeed;
		[Description("максимально допустимое значение оборотов винта")]
		public double MaximumPermissibleRotor;
		[Description("общий шаг винта")]
		public double TotalRotor;
		[Description("рекомендуемое значение шага винта")]
		public double RecommendedValueRotor;
		[Description("курс текущий")]
		public double HeadingCurrent;
		[Description("курс путевой")]
		public double HeadingTrack;
		[Description("угол сноса")]
		public double AngleDrift;
		[Description("угол скольжения")]
		public double Angleslip;
		[Description("крен текущий")]
		public double RollCurrent;
		[Description("максимальное допустимое значение крена")]
		public double MaximumPermissibleRoll;
		[Description("рекомендуемое значение крена")]
		public double RecommendedRollValue;
		[Description("тангаж текущий")]
		public double PitchCurrent;
		[Description("рекомендуемое значение тангажа")]
		public double RecommendedPitchValue;
		[Description("допустимое значение тангажа при кабрировании")]
		public double RermissiblePitchPitching;
		[Description("допустимое значение тангажа при пикировании")]
		public double PermissiblePitchDiving;
		[Description("угол атаки")]
		public double AngleAttack;
		[Description("допустимый угол атаки")]
		public double PermissibleAngleAttack;
		[Description("положение шарика(-1 - левый упор, +1 - правый упор)")]
		public double PositionBall;
		[Description("угол наклона траектории")]
		public double AngleTrajectory;
		[Description("скорость Vy в нормальной СК, м/сек")]
		public double Vy;
		[Description("минимальное допустимое значение Vy, м/сек")]
		public double MinVy;
		[Description("максимально допустимое значение Vy, м/сек")]
		public double MaxVy;
		[Description("приборная скорость текущая")]
		public double InstrumentSpeedCurrent;
		[Description("максимальное значение приборной скорости")]
		public double MaxInstrumentSpeed;
		[Description("минимальное значение приборной скорости")]
		public double MinInstrumentSpeed;
		[Description("составляющие скорости по оси X в нормальной СК")]
		public double SpeedX;
		[Description("составляющие скорости по оси Z в нормальной СК")]
		public double SpeedZ;
		[Description("рекомендуемая скорость пикирования")]
		public double RecommendedDiveSpeed;
		[Description("рекомендуемая скорость выхода из пикирования")]
		public double RecommendedSpeedDiveEnd;
		[Description("истинная скорость текущая")]
		public double TrueSpeedCurrent;
		[Description("составляющая путевой скорости по оси X в нормальной СК ЛА")]
		public double GroundSpeedX;
		[Description("составляющая путевой скорости по оси Z в нормальной СК ЛА")]
		public double GroundSpeedZ;
		[Description("число Маха")]
		public double Mach;
		[Description("Высота относительная")]
		public double RelativeHeight;
		[Description("Высота барометрическая")]
		public double BarometricHeight;
		[Description("Установленное давление, мм рт ст")]
		public double Pressure;
		[Description("Высота от радиовысотомера")]
		public double HeightAltimeter;
		[Description("Опасная высота")]
		public double DangerousHeight;
		[Description("Перегрузка Ny")]
		public Overload Ny = new Overload();
		[Description("Перегрузка Nx")]
		public Overload Nx = new Overload();
		[Description("Перегрузка Nz")]
		public Overload Nz = new Overload();
		[Description("курс метеорологического ветра(откуда дует), град")]
		public double HeadingWind;
		[Description("горизонтальная скорость ветра, м/с")]
		public double HorizontalWindSpeed;
		[Description("Максимально допустимая скорость ветра")]
		public double MaxPermissibleWindSpeed;
		[Description("Механизация")]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
		public double[] Mechanization = new double[30];
	}
}