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
	    public virtual void UpdateData(byte[] dgram)
	    {
			Reverse(ref dgram);
			Assign(dgram);
		}
		
	    public virtual void Reverse(ref byte[] dgram)
		{

		}

		public virtual void Assign(byte[] dgram)
		{
			ConvertHelper.ByteToObject(dgram,this);
		}

		public virtual byte[] GetBytes()
		{
			return ConvertHelper.ObjectToByte(this);
		}

		public void Update(ObservableCollection<CollectionInfo> lst)
		{
			if (lst.Count == 0)
				FillCollection(lst);

			foreach (var field in this.GetType().GetFields(BindingFlags.NonPublic |BindingFlags.Instance))
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
			var fields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
			foreach (var field in fields)
			{
				string description = "";
				if (field.GetCustomAttribute<DescriptionAttribute>() != null &&
				    field.GetCustomAttribute<DescriptionAttribute>().Description != null)
					description = field.GetCustomAttribute<DescriptionAttribute>().Description;
				var value = field.GetValue(this)?.ToString();
				lst.Add(new CollectionInfo()
					{ Name = field.Name, Value = value, Description = description });
			}
		}
	}
}