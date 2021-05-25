using System;
using System.Runtime.InteropServices;

namespace DataTransfer.Infrastructure.Helpers
{
	class ConvertHelper
	{
		public static void ByteToObject<T>(byte[] receiveBytes, T obj)
		{
			int len = Marshal.SizeOf(obj);
			IntPtr i = Marshal.AllocHGlobal(len);
			Marshal.Copy(receiveBytes, 0, i, len);
			Marshal.PtrToStructure(i, obj);
			Marshal.FreeHGlobal(i);
		}
    }
}
