using HxModel.FdmManager;
using HxModel.Models.Config.Base;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace HxModel
{
	class Program
	{
		FdmManager.FdmManager _fdmManager;
		static void Main(string[] args)
		{
	

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


			FdmManager.FdmManager _fdmManager = new FdmManager.FdmManager();

			string lastCommand = "Модель готова к работе!";
			while (true)
			{

				PrintManual(lastCommand);
				string command = Console.ReadLine();
				switch (command)
				{

					case "1":

						Console.WriteLine("Запись началась...");
						_fdmManager.StartRecord();
						lastCommand = "Идет запись полета!";

						break;

					case "2":

						Console.WriteLine("Запись остановлена.");
						_fdmManager.StopRecord();
						lastCommand = "Запись полета остановлена!";
						break;


					case "3":

						Console.WriteLine("Проиграть записанный файл.");
						_fdmManager.StopAll();
						Thread.Sleep(10);
						new PlaybackFlight();
						Thread.Sleep(10);
						_fdmManager = new FdmManager.FdmManager();

						lastCommand = "Модель готова к работе!";

						break;

					case "4":

						Console.WriteLine("Перезапустить модель.");

						_fdmManager.StopAll();
						Thread.Sleep(10);
						_fdmManager = new FdmManager.FdmManager();

						lastCommand = "Выполнен полный сброс до заводских!";

						break;

					default:
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Команда не найдена!!!");

						break;
				}


			}


			Console.WriteLine("Модель готова к работе!");
			Console.ReadKey();
		}
		 

		static void PrintManual(string lastCommand)
		{
	
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("Текущий процесс - " + lastCommand);
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine("");
			Console.WriteLine("1. Начать запись");
			Console.WriteLine("2. Остановить запись");
			Console.WriteLine("3. Проиграть записанный файл");
			Console.WriteLine("4. Перезапустить модель");
			Console.Write("Введите номер команды: ");
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			


		}
	}
}
