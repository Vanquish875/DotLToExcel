using System.Collections.Generic;
using System.IO;

namespace DotLToExcel.Classes
{
    public class Parser
    {
        public IEnumerable<string> ProcessFile(string filePath, string[] fields)
        {
            var data = new List<string>();
            string line = "";

            using (StreamReader readFile = new StreamReader(filePath))
            {
                while ((line = readFile.ReadLine()) != null)
                {
                    foreach (var field in fields)
                    {
                        if (Helper.CheckFields(line, field))
                        {
                            data.Add(Helper.CleanFieldString(line, field));
                        }
                    }
                }
            }
            return data;
        }
    }
}
