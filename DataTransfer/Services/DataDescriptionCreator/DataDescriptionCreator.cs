using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DataTransfer.Services.DataDescriptionCreator
{
	class DataDescriptionCreator
	{

		private static DataDescriptionCreator _instance;
		public static DataDescriptionCreator GetInstance()
		{
			if (_instance == null)
			{
				_instance = new DataDescriptionCreator();
			}
			return _instance;
		}

		private DataDescriptionCreator()
		{
			
		}


		public List<Type> SearchTypes()
		{
			List<Type> types = new List<Type>();
			types.AddRange(Assembly.GetExecutingAssembly().GetTypes()
				.Where(t => t.Namespace == "DataTransfer.Model.Structs")
				.ToList());
			types.AddRange(Assembly.GetExecutingAssembly().GetTypes()
				.Where(t => t.Namespace == "DataTransfer.Model.Structs.AerodromeStruct")
				.ToList());
			types.AddRange(Assembly.GetExecutingAssembly().GetTypes()
				.Where(t => t.Namespace == "DataTransfer.Model.Structs.NavigationPointStruct")
				.ToList());
			return types;
		}

		public void CreateDataDescription(Type typeObject)
		{
			string ddFile = "";
			var obj = Activator.CreateInstance(typeObject);
			var fields = obj.GetType().GetFields(BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance| BindingFlags.Public);

			foreach (var field in fields)
			{
				int length = 1;
				string description = "";
				if (field.GetCustomAttribute<DescriptionAttribute>() != null &&
				    field.GetCustomAttribute<DescriptionAttribute>().Description != null)
					description = field.GetCustomAttribute<DescriptionAttribute>().Description;

				
				if (field.FieldType.IsArray)
					length = GetLengthArray(field);
				var name = GetName(field);
				var type = GetType(field);
				var curType = field.FieldType.Name;


				ddFile += "<field>\r\n" +
				          "<!-- " + curType + " : " + description + "-->\r\n" +
				          "<name>" + name + "</name>\r\n" +
				          "<type>" + type + "</type>\r\n" +
				          "<cardinality>" + length + "</cardinality>\r\n" +
				          "</field>\r\n";
			}

			WriteDataDescription(typeObject.Name, ddFile);
		}

		private void WriteDataDescription(string dataDescriptionName, string dataDescription)
		{
			StreamWriter sw = new StreamWriter(new FileStream(dataDescriptionName + ".dd", FileMode.Create, FileAccess.Write));

			string doc = "<?xml version = \"1.0\" encoding = \"UTF-8\"?>\r\n" +
			             "<!DOCTYPE dataDescription>\r\n" +
			             "<dataDescription name=\"" + dataDescriptionName + "\">\r\n" +
			             dataDescription +
			             "</dataDescription>";

			sw.Write(doc);
			sw.Close();
		}

		private int GetLengthArray(FieldInfo field)
		{
			var length = 0;
			if (field.GetCustomAttribute<MarshalAsAttribute>() != null)
				length = field.GetCustomAttribute<MarshalAsAttribute>().SizeConst;
			if (field.FieldType == typeof(char[]))
				length = length / 2;
			return length;
		}

		private string GetType(FieldInfo field)
		{
			string type = field.FieldType.Name;
			
			if (field.FieldType == typeof(Single[]) || field.FieldType == typeof(Single))
				type = "float";
			if (field.FieldType == typeof(int[])|| field.FieldType == typeof(Int32))
				type = "int";
			if (field.FieldType == typeof(double[]) || field.FieldType == typeof(Double))
				type = "double";
			if (field.FieldType == typeof(char[]))
				type = "utf16string";
			
			return type.Replace("[]","");
		}

		private string GetName(FieldInfo field)
		{
			return ToUpperAndReplace(field.Name);
		}

		private string ToUpperAndReplace(string str)
		{
			var replace = str.Replace(";", "");
			replace = replace.Replace("-", "");
			return FirstLetterToUpper(replace.Replace("_", ""));
		}

		private string FirstLetterToUpper(string str)
		{
			return Char.ToUpper(str[0]) + str.Substring(1);
		}
	}
}