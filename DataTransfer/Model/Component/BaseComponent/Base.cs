using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using DataTransfer.Infrastructure.Helpers;

namespace DataTransfer.Model.Component.BaseComponent
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public class Base : Header
	{
		#region Обновление объекта

		public bool Assign(byte[] dgram)
		{
		   return Set(dgram);
		}

		public void AssignReverse(byte[] dgram)
		{
			Reverse(ref dgram);
			Set(dgram);
		}

		public virtual void Reverse(ref byte[] dgram)
		{
			
		}

		protected virtual bool Set(byte[] dgram)
		{
			return ConvertHelper.ByteToObject(dgram, this);
		}

		#endregion

		#region Получение объекта

		protected virtual void SetHead()
		{

		}

		protected virtual void ReverseName()
		{

		}

		public virtual byte[] GetBytes()
		{
			SetHead();
			return ConvertHelper.ObjectToByte(this);
		}

		public virtual byte[] GetReverseBytes()
		{
			SetHead();
			ReverseName();
			var bytes = ConvertHelper.ObjectToByte(this);
			Reverse(ref bytes);
			return bytes;
		}

		#endregion


		public void Update(ObservableCollection<CollectionInfo> lst)
		{

			if (lst.Count == 0)
					SearchFields(this.GetType(), lst, "", "BaseModel");
				UpdateCollection(this, "BaseModel",  lst);
		}

		public void SearchFields(Type type, ObservableCollection<CollectionInfo> lst, string description, string parentName)
		{
			FieldInfo[] Fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			foreach (FieldInfo field in Fields)
			{
				if (field.FieldType.IsPrimitive || field.FieldType == typeof(string))
				{
					AddToCollection(field, lst, description, parentName);
				}
				else if (field.FieldType.IsClass && !field.FieldType.IsArray)
				{
					var curdescription = GetDescription(field);
					SearchFields(field.FieldType, lst, curdescription, field.Name);
				}
			}


		}
		private string GetDescription(FieldInfo fieldInfo)
		{
			string curdescription = "";
			if (fieldInfo.GetCustomAttribute<DescriptionAttribute>() != null &&
				fieldInfo.GetCustomAttribute<DescriptionAttribute>().Description != null)
				curdescription = fieldInfo.GetCustomAttribute<DescriptionAttribute>().Description;
			return curdescription;
		}

		private void AddToCollection(FieldInfo fieldInfo, ObservableCollection<CollectionInfo> lst, string description, string Parentname)
		{
			string curdescription = GetDescription(fieldInfo);
			if (string.IsNullOrEmpty(curdescription))
				curdescription = description;
			lst.Add(new CollectionInfo()
			{
				Name = Parentname + "." + fieldInfo.Name,
				Description = curdescription,
				Value = "0"
			});
		}




		void UpdateCollection(object obj, string paretnName,  ObservableCollection<CollectionInfo> lst)
		{
			if (obj == null)
				return;
			FieldInfo[] Fields = obj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			foreach (FieldInfo field in Fields)
			{
				object fieldValue = field.GetValue(obj);
				if (field.FieldType.IsPrimitive || field.FieldType == typeof(String))
				{
					var name = paretnName + "." + field.Name;
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
	}
}