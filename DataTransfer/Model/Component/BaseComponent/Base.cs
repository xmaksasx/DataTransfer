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


		//public virtual void Update(ObservableCollection<CollectionInfo> lst)
		//{
		//	if (lst.Count == 0)
		//		FillCollection(lst);

		//	foreach (var field in this.GetType()
		//		.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
		//	{
		//		var found = lst.FirstOrDefault(x => x.Name == field.Name);
		//		if (found != null)
		//		{
		//			var value = field.GetValue(this)?.ToString();
		//			found.Value = value?.Substring(0, Math.Min(value.Length, 7));
		//		}
		//	}
		//}

		//public virtual void FillCollection(ObservableCollection<CollectionInfo> lst)
		//{
		//	string ddFile = "";

		//	var fields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
		//	foreach (var field in fields)
		//	{
		//		string description = "";
		//		if (field.GetCustomAttribute<DescriptionAttribute>() != null &&
		//		    field.GetCustomAttribute<DescriptionAttribute>().Description != null)
		//			description = field.GetCustomAttribute<DescriptionAttribute>().Description;
		//		var value = field.GetValue(this)?.ToString();
		//		lst.Add(new CollectionInfo()
		//			{Name = field.Name, Value = value, Description = description});

		//	}
		//}

		public void Update(ObservableCollection<CollectionInfo> lst)
		{
			
			if (lst.Count == 0)
				SearchFields(this, this.GetType(), true, lst, "" );
			UpdateCollection(this, this.GetType(), true, lst );
		}

		public void SearchFields(object obj, Type pType, bool isFirst, ObservableCollection<CollectionInfo> lst, string description)
		{
			FieldInfo[] myFields = pType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < myFields.Length; i++)
			{
				if (myFields[i].FieldType.IsPrimitive || myFields[i].FieldType == typeof(String))
				{
					//if (!isFirst)
					{
						//object temp = Activator.CreateInstance(pType);
						//obj = temp;
						AddToCollection(myFields[i],obj, lst, description);
					}
				}
				else if (myFields[i].FieldType.IsClass)
				{
					string curdescription = "";
					if (myFields[i].GetCustomAttribute<DescriptionAttribute>() != null &&
						myFields[i].GetCustomAttribute<DescriptionAttribute>().Description != null)
						curdescription = myFields[i].GetCustomAttribute<DescriptionAttribute>().Description;
					Type tType = myFields[i].FieldType;
					SearchFields(myFields[i], tType, false, lst, curdescription);
				}
			}

		}
		private void AddToCollection(FieldInfo fieldInfo,object obj, ObservableCollection<CollectionInfo> lst, string description)
		{
			string curdescription = "";
			if (fieldInfo.GetCustomAttribute<DescriptionAttribute>() != null &&
				fieldInfo.GetCustomAttribute<DescriptionAttribute>().Description != null)
				curdescription = fieldInfo.GetCustomAttribute<DescriptionAttribute>().Description;
			if (string.IsNullOrEmpty(curdescription))
				curdescription = description;
			var guid = obj.ToString();	

			 lst.Add(new CollectionInfo()
			{ Name = fieldInfo.Name, Value = "0", Description = curdescription, GuidName = guid });
		
		}



		void UpdateCollection( object obj, Type pType, bool isFirst, ObservableCollection<CollectionInfo> lst)
		{
			FieldInfo[] myFields = pType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < myFields.Length; i++)
			{
				if (myFields[i].FieldType.IsPrimitive || myFields[i].FieldType == typeof(String))
				{
					//if (!isFirst)
					{
						if (obj != null)
						{
							var found = lst.FirstOrDefault(x => x.GuidName == "");
							if (found != null)
							{

								var value = myFields[i].GetValue(obj)?.ToString();
								found.Value = value?.Substring(0, Math.Min(value.Length, 8));
								

							}
						}

					}
				}
				else if (myFields[i].FieldType.IsClass)
				{
					Type tType = myFields[i].FieldType;
					UpdateCollection(myFields[i].GetValue(obj), tType, false, lst);
				}

			}
		}
	}
}