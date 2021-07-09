using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Infrastructure.Helpers
{
	public static class ExtensionMethods
	{
		public static void ToBigEndianUnicode16(this char[] arr) 
		{
			Array.Copy(Encoding.Unicode.GetBytes(arr), arr, arr.Length);
			//for (int i = 0; i < arr.Length; i = i + 8)
			//	Array.Reverse(arr,i,8);
		}

		public static void ToBigEndianUnicode(this char[] arr)
		{
			Array.Copy(Encoding.BigEndianUnicode.GetBytes(arr), arr, arr.Length);
			for (int i = 0; i < arr.Length; i = i + 8)
			Array.Reverse(arr,i,8);
		}


		public static void ToBigEndianUnicode40(this char[] arr)
		{
			Array.Copy(Encoding.BigEndianUnicode.GetBytes(arr), arr, arr.Length);
			for (int i = 0; i < arr.Length; i = i + 8)
				Array.Reverse(arr, i, 8);
			//Array.Reverse(arr);
		}

		public static void ToLittleEndianUnicode(this char[] arr)
		{
			for (int i = 0; i < arr.Length; i = i + 8)
				Array.Reverse(arr, i, 8);

			byte[] bytes = Encoding.UTF8.GetBytes(arr);
			string str = Encoding.BigEndianUnicode.GetString(bytes);
			Array.Clear(arr,0, arr.Length);
			Array.Copy(str.ToCharArray(), arr, str.Length);
		}
	}
}
