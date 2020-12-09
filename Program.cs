using System;
using DotLToExcel.Classes;

namespace DotLToExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (Helper.checkForDotLFiles(Helper.verifyArgumentsProvided(args)))
                {
                    //Start the application.
                    Mapper mapper = new Mapper();
                    Worker parseFiles = new Worker(mapper, Helper.filePath);

                    //Parse Remote Connection record.
                    Console.WriteLine("Parsing Remote Connection table.");
                    parseFiles.parseRemConnJoin();
                    //Parse Messages.
                    Console.WriteLine("Parsing Message table.");
                    parseFiles.parseMessages();
                    //Map legacy names.
                    Console.WriteLine("Mapping legacy names.");
                    parseFiles.mapLegacyNames();
                    //Map Stations.
                    Console.WriteLine("Mapping Stations.");
                    parseFiles.mapStations();
                    //Map Connections.
                    Console.WriteLine("Mapping Connections.");
                    parseFiles.mapConnections();
                    //Map Remotes.
                    Console.WriteLine("Mapping Remotes.");
                    parseFiles.mapRemotes();
                    //Map Analogs
                    Console.WriteLine("Mapping Analogs.");
                    parseFiles.mapAnalogs();
                    //Map Rates.
                    Console.WriteLine("Mapping Rates.");
                    parseFiles.mapRates();
                    //Map Status.
                    Console.WriteLine("Mapping Status.");
                    parseFiles.mapStatus();
                    //Map Multistate.
                    Console.WriteLine("Mapping Multistate.");
                    parseFiles.mapMultistate();

                    //Call Data Excel.
                    Console.WriteLine("Creating Excel file.");
                    parseFiles.callExcel();
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
