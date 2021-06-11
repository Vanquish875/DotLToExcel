using System.Collections.Generic;
using System.IO;

namespace DotLToExcel.Classes
{
    public class Parser
    {
        public List<string> ProcessFile(string filePath, string[] fields)
        {
            var data = new List<string>();

            using (StreamReader readFile = new StreamReader(filePath))
            {
                string s = string.Empty;
                while ((s = readFile.ReadLine()) != null)
                {
                    foreach (var field in fields)
                    {
                        if (Helper.CheckFields(s, field))
                        {
                            data.Add(Helper.CleanFieldString(s, field));
                        }
                    }
                }
            }
            return data;
        }
    }
}
