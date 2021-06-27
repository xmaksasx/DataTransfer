using System;
using System.IO;
using System.Reflection;


namespace HxModel
{
	class Program
	{

		static void Main(string[] args)
		{
			FdmManager.FdmManager _fdmManager = new FdmManager.FdmManager();

			var assembly = Assembly.GetExecutingAssembly();
			var resourceName = "HxModel.Logo.txt";

			Console.ForegroundColor = ConsoleColor.DarkCyan;

			using (Stream stream = assembly.GetManifestResourceStream(resourceName))
			{
				using (StreamReader reader = new StreamReader(stream))
					while (!reader.EndOfStream)
					{
						string line = reader.ReadLine();
						Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
						Console.WriteLine(line);
					}

				Console.WriteLine("");
				Console.WriteLine("");
				Console.ForegroundColor = ConsoleColor.Gray;
			}


			Console.WriteLine("Модель готова к работе!");
			Console.ReadKey();
		}
	}
}
