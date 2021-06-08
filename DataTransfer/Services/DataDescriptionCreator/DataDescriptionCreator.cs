using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

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
			object Obj;
			string @namespace = "DataTransfer.Model.Structs";
			var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && t.Namespace == @namespace)
				.ToList();
			foreach (var item in types)
			{

				//Obj = Activator.CreateInstance(item);
				//ObjectToByte(Obj);
			}
		}


		public List<Type> SearchTypes()
		{
			return Assembly.GetExecutingAssembly().GetTypes()
				.Where(t => t.IsClass && t.Namespace == "DataTransfer.Model.Structs")
				.ToList();
		}

		public void CreateDataDescription(Type typeObject)
		{
			string ddFile = "";
			var obj = Activator.CreateInstance(typeObject);
			var fields = obj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
			foreach (var field in fields)
			{
				int length = 1;
				string description = "";
				if (field.GetCustomAttribute<DescriptionAttribute>() != null &&
				    field.GetCustomAttribute<DescriptionAttribute>().Description != null)
					description = field.GetCustomAttribute<DescriptionAttribute>().Description;
				if (field.FieldType.IsArray)
					length = GetLengthArray(obj, field);
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

		private int GetLengthArray<T>(T obj, FieldInfo field)
		{
			var length = 0;
			
			if (field.FieldType == typeof(Single[]))
				length = ((Single[]) field.GetValue(obj)).Length;
			if (field.FieldType == typeof(int[]))
				length = ((int[])field.GetValue(obj)).Length;
			if (field.FieldType == typeof(double[]))
				length = ((double[])field.GetValue(obj)).Length;
			if (field.FieldType == typeof(char[]))
				length = ((char[])field.GetValue(obj)).Length;

			return length;
		}

		private string GetType(FieldInfo field)
		{
			string type = field.FieldType.Name;
			if (field.FieldType == typeof(Single[]) || field.FieldType == typeof(Single))
				type = "float";
			if (field.FieldType == typeof(int[])|| field.FieldType == typeof(Int32))
				type = "int";
			if (field.FieldType == typeof(double[]))
				type = "double";
			if (field.FieldType == typeof(char[]))
				type = "char";
			return type;
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