using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Ka50Model
{
	class Program
	{

		static void Main(string[] args)
		{
			FdmManager.FdmManager _fdmManager = new FdmManager.FdmManager();
			if (File.Exists("Logo.txt"))
			{
				var lines = File.ReadAllLines("Logo.txt");
				foreach (var line in lines)
					Console.WriteLine(line);
				Console.WriteLine("");
				Console.WriteLine("");

			}

			Console.WriteLine("Модель готова к работе!");

			Console.ReadKey();
		}

	}
}
