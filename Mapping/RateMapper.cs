using DotLToExcel.DotL;
using DotLToExcel.POCOS;
using System;
using System.Collections.Generic;

namespace DotLToExcel.Mapping
{
    public class RateMapper
    {
        public IEnumerable<Rate> MapRate(List<string> data)
        {
            int FieldLength = RateFields.Fields.Length;
            var rates = new List<Rate>();

            try
            {
                for (int i = 0; i < data.Count; i += FieldLength)
                {
                    CreateRate(data, rates, i);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return rates;
        }

        public IEnumerable<Rate> MapRate(List<string> data, HashSet<string> anrData)
        {
            int FieldLength = RateFields.Fields.Length;
            var rates = new List<Rate>();

            try
            {
                for (int i = 0; i < data.Count; i += FieldLength)
                {
                    if (anrData.Contains(data[i + 2]))
                    {
                        CreateRate(data, rates, i);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return rates;
        }

        private static void CreateRate(List<string> data, List<Rate> rates, int i)
        {
            var rate = new Rate
            {
                LegacyName = data[i + 28],
                NewName = data[i],
                Remote = data[i + 1],
                Group = data[i + 2],
                dataset = data[i + 3],
                Station = data[i + 4],
                Message = data[i + 5],
                SafetyPoint = data[i + 6],
                InstrumentFailCheck = data[i + 7],
                LoLimit = Convert.ToDouble(data[i + 8]),
                HiLimit = Convert.ToDouble(data[i + 9]),
                LoLoLimit = Convert.ToDouble(data[i + 10]),
                HiHiLimit = Convert.ToDouble(data[i + 11]),
                HiCheck = data[i + 12],
                HiHiCheck = data[i + 13],
                LoCheck = data[i + 14],
                LoLoCheck = data[i + 15],
                InputCoordinates = data[i + 16],
                InputDataType = data[i + 17],
                MinRaw = Convert.ToInt32(data[i + 18]),
                MaxRaw = data[i + 19],
                MinEGU = Convert.ToInt32(data[i + 20]),
                MaxEGU = data[i + 21],
                ConvertRawToEGU = data[i + 22],
                EngineeringUnits = data[i + 23],
                Description = data[i + 24],
                ScanBlock = Convert.ToInt16(data[i + 25]),
                CIP = data[i + 26],
                ABCIPDataType = data[i + 27],
                ShortDescription = data[i + 29],
                DisplayOrder = Convert.ToInt32(data[i + 30])
            };
            rates.Add(rate);
        }
    }
}
