using System;
using System.Collections.Generic;
using DotLToExcel.POCOS;
using DotLToExcel.DotL;
using System.IO;
using System.Linq;
using System.Windows.Media.Animation;

namespace DotLToExcel.Mapping
{
    public class RateMapper
    {

        public List<Rate> MapRate(IList<string> data, Dictionary<string, string> RateNames)
        {
            int FieldLength = RateFields.Fields.Length;
            List<Rate> rates = new List<Rate>();

            try
            {
                for(int i = 0; i < data.Count; i += FieldLength)
                {
                    Rate rate = new Rate();
                    rate.LegacyName = Helper.returnValFromDictionary(data[i], RateNames);
                    rate.NewName = data[i];
                    rate.Remote = data[i + 1];
                    rate.Group = data[i + 2];
                    rate.dataset = data[i + 3];
                    rate.Station = data[i + 4];
                    rate.Message = data[i + 5];
                    rate.SafetyPoint = data[i + 6];
                    rate.InstrumentFailCheck = data[i + 7];
                    rate.LoLimit = Convert.ToInt32(data[i + 8]);
                    rate.HiLimit = Convert.ToInt32(data[i + 9]);
                    rate.LoLoLimit = Convert.ToInt32(data[i + 10]);
                    rate.HiHiLimit = Convert.ToInt32(data[i + 11]);
                    rate.HiCheck = data[i + 12];
                    rate.HiHiCheck = data[i + 13];
                    rate.LoCheck = data[i + 14];
                    rate.LoLoCheck = data[i + 15];
                    rate.InputCoordinates = data[i + 16];
                    rate.InputDataType = data[i + 17];
                    rate.MinRaw = Convert.ToInt32(data[i + 18]);
                    rate.MaxRaw = data[i + 19];
                    rate.MinEGU = Convert.ToInt32(data[i + 20]);
                    rate.MaxEGU = data[i + 21];
                    rate.ConvertRawToEGU = data[i + 22];
                    rate.EngineeringUnits = data[i + 23];
                    rate.Description = data[i + 24];
                    rate.ScanBlock = Convert.ToInt16(data[i + 25]);
                    rate.CIP = data[i + 26];
                    rate.ABCIPDataType = data[i + 27];
                    rate.ShortDescription = data[i + 28];
                    rate.DisplayOrder = Convert.ToInt32(data[i + 29]);

                    rates.Add(rate);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return rates;
        }
    }
}
