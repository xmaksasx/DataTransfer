using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using DataTransfer.Model.Component;
using DataTransfer.Model.Component.BaseComponent;

namespace DataTransfer.Model.Structs.DynamicModelStruct.Ka50
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	class ModelKa50 : DynamicModel
	{
		protected override void SetHead()
		{
			GetHeadDouble("DynamicModelKa52");
		}

		public override void Reverse(ref byte[] dgram)
		{
			for (int i = 68; i < dgram.Length; i = i + 8)
				Array.Reverse(dgram, i, 8);
		}

		public override void Update(ObservableCollection<CollectionInfo> lst)
		{
			if (lst.Count == 0)
				FillCollection(lst);

			OutPutObject1(this, this.GetType(), true, lst);
		}

		public override void FillCollection(ObservableCollection<CollectionInfo> lst)
		{

	
			OutPutObject(this, this.GetType(), true, lst);
			
		}


		static void OutPutObject1(object obj, Type pType, bool isFirst, ObservableCollection<CollectionInfo> lst)
		{

			// Get the FieldInfo of MyClass.
			FieldInfo[] myFields = pType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			// Display the values of the fields.
			for (int i = 0; i < myFields.Length; i++)
			{
				if (myFields[i].FieldType.IsPrimitive || myFields[i].FieldType == typeof(Decimal) || myFields[i].FieldType == typeof(String))
				{

					if (!isFirst)
					{

						var found = lst.FirstOrDefault(x => x.Name == myFields[i].Name);
						if (found != null)
						{
							object temp = Activator.CreateInstance(pType);
							obj = temp;
							var value = myFields[i].GetValue(obj)?.ToString();
							found.Value = value?.Substring(0, Math.Min(value.Length, 7));
						}
						
					}

					//Console.WriteLine(string.Format("{0}: {1}", myFields[i].Name, myFields[i].GetValue(obj)));
				}
				else if (myFields[i].FieldType.IsClass)
				{
					Type tType = myFields[i].FieldType;
					OutPutObject1(myFields[i], tType, false, lst);
				}

			}
		}



		static void OutPutObject(object obj, Type pType, bool isFirst, ObservableCollection<CollectionInfo> lst)
		{

			// Get the FieldInfo of MyClass.
			FieldInfo[] myFields = pType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			// Display the values of the fields.
			for (int i = 0; i < myFields.Length; i++)
			{
				if (myFields[i].FieldType.IsPrimitive || myFields[i].FieldType == typeof(Decimal) || myFields[i].FieldType == typeof(String))
				{

					if (!isFirst)
					{
						object temp = Activator.CreateInstance(pType);
						obj = temp;

						string description = "";
						if (myFields[i].GetCustomAttribute<DescriptionAttribute>() != null &&
						    myFields[i].GetCustomAttribute<DescriptionAttribute>().Description != null)
							description = myFields[i].GetCustomAttribute<DescriptionAttribute>().Description;
					
						lst.Add(new CollectionInfo()
							{ Name = myFields[i].Name, Value = myFields[i].GetValue(obj).ToString(), Description = description });
					}

					//Console.WriteLine(string.Format("{0}: {1}", myFields[i].Name, myFields[i].GetValue(obj)));
				}
				else if (myFields[i].FieldType.IsClass)
				{
					Type tType = myFields[i].FieldType;
					OutPutObject(myFields[i], tType, false,lst);
				}

			}
		}

		private KinematicsState KinematicsState;
		private VhclOutp VhclOutp;
	}
}
