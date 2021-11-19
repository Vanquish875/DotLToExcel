using DotLToExcel.Classes;
using System;

namespace DotLToExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var filePath = Helper.ReturnFilePath(args[0]);
                var IANR = Helper.CheckIfANROption(args[1]);

                if (Helper.CheckForDotLFiles(filePath))
                {
                    var parseFiles = new Worker(filePath);

                    if (IANR)
                    {
                        parseFiles.ParseAllTables(true);
                    }
                    else
                    {
                        parseFiles.ParseAllTables(false);
                    }

                    Console.WriteLine("Finished!");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Please place all .l files in working directory.");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
