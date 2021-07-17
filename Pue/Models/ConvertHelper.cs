using System;
using System.Runtime.InteropServices;

namespace Pue.Models
{
	class ConvertHelper
	{
		public static bool ByteToObject<T>(byte[] receiveBytes, T obj)
		{
			int len = Marshal.SizeOf(obj);
			if (len != receiveBytes.Length) return false;
			IntPtr i = Marshal.AllocHGlobal(len);
			Marshal.Copy(receiveBytes, 0, i, len);
			Marshal.PtrToStructure(i, obj);
			Marshal.FreeHGlobal(i);
			return true;
		}


		public static byte[] ObjectToByte<T>(T obj)
		{
			var size = Marshal.SizeOf(obj);
			var bytes = new byte[size];
			var ptr = Marshal.AllocHGlobal(size);
			Marshal.StructureToPtr(obj, ptr, false);
			Marshal.Copy(ptr, bytes, 0, size);
			Marshal.FreeHGlobal(ptr);
			return bytes;
		}
	}
}
