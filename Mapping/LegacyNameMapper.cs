using System;
using System.Collections.Generic;
using DotLToExcel.POCOS;
using DotLToExcel.DotL;
using System.IO;
using System.Linq;
using System.Windows.Media.Animation;

namespace DotLToExcel.Mapping
{
    public class LegacyNameMapper
    {
        public IDictionary<string, string> mapLegacyNames(string filePath, string fileName)
        {
            try
            {
                //Map legacy names.
                return File.ReadLines(filePath + @"\" + fileName)
                .Select(line => line.Split(','))
                .ToDictionary(line => line[0], line => line[1]);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            } 
        }
    }
}
