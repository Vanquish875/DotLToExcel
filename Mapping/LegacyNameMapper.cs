using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DotLToExcel.Mapping
{
    public class LegacyNameMapper
    {
        public Dictionary<string, string> MapLegacyNames(string filePath, string fileName)
        {
            return File.ReadLines(filePath + @"\" + fileName)
            .Select(line => line.Split(','))
            .ToDictionary(line => line[0], line => line[1]);
        }
    }
}
