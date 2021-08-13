﻿using System.Collections.Generic;
using System.IO;

namespace DotLToExcel
{
    public static class Helper
    {
        public static string ReturnFilePath(string argument1)
        {
            if (argument1 != null)
            {
                return argument1;
            }

            return Directory.GetCurrentDirectory();
        }

        public static bool CheckIfANROption(string argument2)
        {
            if(argument2.ToLower().Equals("-a"))
            {
                return true;
            }

            return false;
        }

        public static bool CheckForDotLFiles(string path)
        {
            bool connectionDotLExists = File.Exists(path + @"\connection.l");
            bool remoteDotLExists = File.Exists(path + @"\remote.l");
            bool remConnJoinDotLExists = File.Exists(path + @"\remconnjoin.l");
            bool analogDotLExists = File.Exists(path + @"\analog.l");
            bool rateDotLExists = File.Exists(path + @"\rate.l");
            bool statusDotLExists = File.Exists(path + @"\status.l");
            bool stationDotLExists = File.Exists(path + @"\station.l");
            bool multistateDotLExists = File.Exists(path + @"\multistate.l");
            bool AnalogNames = true;//File.Exists(path + @"\AnalogNames.csv");
            bool RateNames = true;//File.Exists(path + @"\RateNames.csv");
            bool StatusNames = true;//File.Exists(path + @"\StatusNames.csv");
            bool messageDotLExists = File.Exists(path + @"\message.l");

            if (connectionDotLExists && remoteDotLExists && remConnJoinDotLExists && analogDotLExists && rateDotLExists && statusDotLExists && stationDotLExists
                && multistateDotLExists && AnalogNames && RateNames && StatusNames && messageDotLExists)
                return true;

            return false;
        }

        public static string CleanFieldString(string line, string field)
        {
            return RemoveWhiteSpace(line.Replace(field, ""));
        }

        public static bool CheckFields(string line, string field)
        {
            if (line.StartsWith(field))
                return true;

            return false;
        }

        public static string RemoveWhiteSpace(string input)
        {
            return input.Trim();
        }

        public static string ReturnValFromDictionary(string key, Dictionary<string, string> dictionary)
        {
            if (ReturnBoolKeyExistsDictionary(key, dictionary))
            {
                return dictionary[key];
            }

            return "";
        }

        public static bool ReturnBoolKeyExistsDictionary(string remote, Dictionary<string, string> remoConJoin)
        {
            if (remoConJoin.ContainsKey(remote))
            {
                return true;
            }

            return false;
        }
    }
}
