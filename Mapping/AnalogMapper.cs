using DotLToExcel.DotL;
using System;
using System.Collections.Generic;

namespace DotLToExcel.Mapping
{
    public class AnalogMapper
    {
        public List<Analog> MapAnalog(IList<string> data, HashSet<string> groups)
        {
            var FieldLength = AnalogFields.Fields.Length;
            var analogs = new List<Analog>();

            try
            {
                for (int i = 0; i < data.Count; i += FieldLength)
                {
                    if (groups.Contains(data[i + 2]))
                    {
                        var analog = new Analog
                        {
                            LegacyName = data[i + 37],
                            NewName = data[i],
                            Remote = data[i + 1],
                            Group = data[i + 2],
                            dataset = data[i + 3],
                            Station = data[i + 4],
                            Message = data[i + 5],
                            SafetyPoint = data[i + 6],
                            HasInput = data[i + 7],
                            HasOutput = data[i + 8],
                            OutputDataType = data[i + 9],
                            MinRaw = Convert.ToInt32(data[i + 10]),
                            MaxRaw = data[i + 11],
                            MinEGU = Convert.ToInt32(data[i + 12]),
                            MaxEGU = data[i + 13],
                            ConvertRawToEGU = data[i + 14],
                            EngineeringUnits = data[i + 15],
                            InstrumentFailCheck = data[i + 16],
                            LoLimit = Convert.ToDouble(data[i + 17]),
                            HiLimit = Convert.ToDouble(data[i + 18]),
                            LoLoLimit = Convert.ToDouble(data[i + 19]),
                            HiHiLimit = Convert.ToDouble(data[i + 20]),
                            HiCheck = data[i + 21],
                            HiHiCheck = data[i + 22],
                            LoCheck = data[i + 23],
                            LoLoCheck = data[i + 24],
                            InputCoordinates = data[i + 25],
                            InputDataType = data[i + 26],
                            MinRawOutput = Convert.ToInt32(data[i + 27]),
                            MaxRawOutput = data[i + 28],
                            MinEGUOutput = Convert.ToInt32(data[i + 29]),
                            MaxEGUOutput = data[i + 30],
                            ConvertRawToEGUOutput = data[i + 31],
                            OutputCoordinates = data[i + 32],
                            Description = data[i + 33],
                            ScanBlock = Convert.ToInt16(data[i + 34]),
                            CIP = data[i + 35],
                            ABCIPDataType = data[i + 36],
                            ShortDescription = data[i + 38],
                            DisplayOrder = Convert.ToInt32(data[i + 39])
                        };
                        analogs.Add(analog);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return analogs;
        }
    }
}
