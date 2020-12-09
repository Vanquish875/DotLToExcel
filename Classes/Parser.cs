using System.Collections.Generic;
using System.IO;

namespace DotLToExcel.Classes
{
    public class Parser
    {
        public List<string> processFile(string filePath, string[] fields)
        {
            List<string> data = new List<string>();
            string line = "";

            using (StreamReader readFile = new StreamReader(filePath))
            {
                while ((line = readFile.ReadLine()) != null)
                {
                    foreach (var field in fields)
                    {
                        if (Helper.checkFields(line, field))
                        {
                            data.Add(Helper.cleanFieldString(line, field));
                        }
                    }
                }
            }
            return data;
        }
    }
}
