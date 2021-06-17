using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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

		#region Обновление данных

		public void Update(ObservableCollection<CollectionInfo> lst)
		{

			if (lst.Count == 0)
				SearchFields(this.GetType(), this.GetType().Name, "",lst);
			UpdateCollection(this, "BaseModel", lst);
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

		private void UpdateCollection(object obj, string parentName,  ObservableCollection<CollectionInfo> lst)
		{
			if (obj == null) return;
			FieldInfo[] Fields = obj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			foreach (FieldInfo field in Fields)
			{
				object fieldValue = field.GetValue(obj);
				if (field.FieldType.IsPrimitive || field.FieldType == typeof(String))
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
	}
}