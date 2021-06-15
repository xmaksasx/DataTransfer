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
				SearchFields(this, this.GetType(), true, lst,"");
			OutPutObject1(this, this.GetType(), true, lst);
		}

		public void SearchFields(object obj, Type pType, bool isFirst, ObservableCollection<CollectionInfo> lst, string description)
		{
			//OutPutObject(this, this.GetType(), true, lst);
			FieldInfo[] myFields = pType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < myFields.Length; i++)
			{
				if (myFields[i].FieldType.IsPrimitive ||  myFields[i].FieldType == typeof(String))
				{
					if (!isFirst)
					{											
						object temp = Activator.CreateInstance(pType);
						obj = temp;
						AddToCollection(myFields[i], obj, lst, description);
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
		private void AddToCollection(FieldInfo fieldInfo, object obj, ObservableCollection<CollectionInfo> lst, string description)
		{
			string curdescription = "";
			if (fieldInfo.GetCustomAttribute<DescriptionAttribute>() != null &&
				fieldInfo.GetCustomAttribute<DescriptionAttribute>().Description != null)
				curdescription = fieldInfo.GetCustomAttribute<DescriptionAttribute>().Description;
			if (string.IsNullOrEmpty(curdescription))
				curdescription = description;
			
			lst.Add(new CollectionInfo()
			{ Name = fieldInfo.Name, Value = fieldInfo.GetValue(obj).ToString(), Description = curdescription });
		}



		void OutPutObject1(object obj, Type pType, bool isFirst, ObservableCollection<CollectionInfo> lst)
		{
			FieldInfo[] myFields = pType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < myFields.Length; i++)
			{
				if (myFields[i].FieldType.IsPrimitive || myFields[i].FieldType == typeof(String))
				{
					if (!isFirst)
					{
						var found = lst.FirstOrDefault(x => x.Name == myFields[i].Name);
						if (found != null)
						{
							if (obj != null)
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
					OutPutObject1(myFields[i].GetValue(obj), tType, false, lst);
				}

			}
		}
	


		 void OutPutObject(object obj, Type pType, bool isFirst, ObservableCollection<CollectionInfo> lst)
		{
			FieldInfo[] myFields = pType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
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
		public ModelKa50()
		{
			KinematicsState = new KinematicsState();
			VhclOutp = new VhclOutp();
		}

		private KinematicsState KinematicsState;
		private VhclOutp VhclOutp;
	}
}
