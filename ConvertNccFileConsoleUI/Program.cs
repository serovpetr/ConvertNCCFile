using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using ConvertNCCFile;

namespace ConvertNccFileConsoleUI
{
    class Program
    {
        private static readonly IExportBehavior ExportBehavior = new XmlExportBehavior();
        private static readonly IExtractBehavior ExtractBehavior = new HtmlFileExtract();

        static void Main(string[] args)
        {
            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;

            var inputDir = Path.Combine(currentDirectory, "html");
            var outputDir = Path.Combine(currentDirectory, "xls");

            if (!Directory.Exists(inputDir))
            {
                Console.WriteLine("Нет папки с html файлами, в {0}", inputDir);
                Console.ReadLine();
                return;
            }

            var htmls = Directory.GetFiles(inputDir, "*.html");
            Console.WriteLine("Найдено {0} html файлов", htmls.Count());

            if (!htmls.Any())
            {
                Console.WriteLine("Для выхода нажмите любую клавишу...");
                Console.ReadKey();
                return;
            }

            var bills = new List<Bill>();

            foreach (var html in htmls)
            {
                var temp = ExtractBehavior.GetBills(html);
                bills.AddRange(temp);

                Console.WriteLine("Файл {0}. Найдено {1} записей", Path.GetFileName(html), temp.Count);
            }

            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            var filePath = Path.Combine(outputDir, string.Format("Convert_{0}.xls", DateTime.Now.ToShortDateString()));
            ExportBehavior.Export(filePath, bills);

            Console.WriteLine("Успешно сконвертировано в {0}", Path.GetFileName(filePath));
            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
