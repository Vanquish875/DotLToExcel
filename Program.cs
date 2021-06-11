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
                var filePath = Helper.VerifyArgumentsProvided(args);
                if (Helper.CheckForDotLFiles(filePath))
                {
                    var parseFiles = new Worker(filePath);

                    Console.WriteLine("Parsing Remote Connection table.");
                    parseFiles.ParseRemConnJoin();

                    Console.WriteLine("Parsing Message table.");
                    parseFiles.ParseMessages();

                    Console.WriteLine("Mapping legacy names.");
                    parseFiles.MapLegacyNames();

                    Console.WriteLine("Mapping Stations.");
                    parseFiles.MapStations();

                    Console.WriteLine("Mapping Connections.");
                    parseFiles.MapConnections();

                    Console.WriteLine("Mapping Remotes.");
                    parseFiles.MapRemotes();

                    Console.WriteLine("Mapping Analogs.");
                    parseFiles.MapAnalogs();

                    Console.WriteLine("Mapping Rates.");
                    parseFiles.MapRates();

                    Console.WriteLine("Mapping Status.");
                    parseFiles.MapStatus();

                    Console.WriteLine("Mapping Multistate.");
                    parseFiles.MapMultistate();


                    Console.WriteLine("Creating Excel file.");
                    parseFiles.CallExcel();
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
