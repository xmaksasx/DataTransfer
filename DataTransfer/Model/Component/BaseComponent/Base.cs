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

		public void Assign(byte[] dgram)
		{
		    Set(dgram);
		}

		public void AssignReverse(byte[] dgram)
		{
			Reverse(ref dgram);
			Set(dgram);
		}

		public virtual void Reverse(ref byte[] dgram)
		{
			
		}

		protected virtual void Set(byte[] dgram)
		{
			ConvertHelper.ByteToObject(dgram, this);
		}

		#endregion

		#region Получение объекта

		protected virtual void SetHead()
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
			var bytes = ConvertHelper.ObjectToByte(this);
			Reverse(ref bytes);
			return bytes;
		}

		#endregion


		public void Update(ObservableCollection<CollectionInfo> lst)
		{
			if (lst.Count == 0)
				FillCollection(lst);

			foreach (var field in this.GetType()
				.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
			{
				var found = lst.FirstOrDefault(x => x.Name == field.Name);
				if (found != null)
				{
					var value = field.GetValue(this)?.ToString();
					found.Value = value?.Substring(0, Math.Min(value.Length, 7));
				}
			}
		}

		private void FillCollection(ObservableCollection<CollectionInfo> lst)
		{
			string ddFile = "";

			var fields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
			foreach (var field in fields)
			{
				string description = "";
				if (field.GetCustomAttribute<DescriptionAttribute>() != null &&
				    field.GetCustomAttribute<DescriptionAttribute>().Description != null)
					description = field.GetCustomAttribute<DescriptionAttribute>().Description;
				var value = field.GetValue(this)?.ToString();
				lst.Add(new CollectionInfo()
					{Name = field.Name, Value = value, Description = description});

			}
		}
	}
}