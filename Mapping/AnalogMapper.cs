using System;
using System.Collections.Generic;
using DotLToExcel.POCOS;
using DotLToExcel.DotL;
using System.IO;
using System.Linq;
using System.Windows.Media.Animation;

namespace DotLToExcel.Mapping
{
    public class AnalogMapper
    {

        public List<Analog> mapAnalog(IList<string> data, Dictionary<string, string> AnalogNames)
        {
            int FieldLength = AnalogFields.Fields.Length;
            List<Analog> analogs = new List<Analog>();

            try
            {
                for (int i = 0; i < data.Count; i += FieldLength)
                {
                    Analog analog = new Analog();
                    analog.LegacyName = Helper.returnValFromDictionary(data[i], AnalogNames);
                    analog.NewName = data[i];
                    analog.Remote = data[i + 1];
                    analog.Group = data[i + 2];
                    analog.dataset = data[i + 3];
                    analog.Station = data[i + 4];
                    analog.Message = data[i + 5];
                    analog.SafetyPoint = data[i + 6];
                    analog.HasInput = data[i + 7];
                    analog.HasOutput = data[i + 8];
                    analog.OutputDataType = data[i + 9];
                    analog.MinRaw = Convert.ToInt32(data[i + 10]);
                    analog.MaxRaw = data[i + 11];
                    analog.MinEGU = Convert.ToInt32(data[i + 12]);
                    analog.MaxEGU = data[i + 13];
                    analog.ConvertRawToEGU = data[i + 14];
                    analog.EngineeringUnits = data[i + 15];
                    analog.InstrumentFailCheck = data[i + 16];
                    analog.LoLimit = Convert.ToDouble(data[i + 17]);
                    analog.HiLimit = Convert.ToDouble(data[i + 18]);
                    analog.LoLoLimit = Convert.ToDouble(data[i + 19]);
                    analog.HiHiLimit = Convert.ToDouble(data[i + 20]);
                    analog.HiCheck = data[i + 21];
                    analog.HiHiCheck = data[i + 22];
                    analog.LoCheck = data[i + 23];
                    analog.LoLoCheck = data[i + 24];
                    analog.InputCoordinates = data[i + 25];
                    analog.InputDataType = data[i + 26];
                    analog.MinRawOutput = Convert.ToInt32(data[i + 27]);
                    analog.MaxRawOutput = data[i + 28];
                    analog.MinEGUOutput = Convert.ToInt32(data[i + 29]);
                    analog.MaxEGUOutput = data[i + 30];
                    analog.ConvertRawToEGUOutput = data[i + 31];
                    analog.OutputCoordinates = data[i + 32];
                    analog.Description = data[i + 33];
                    analog.ScanBlock = Convert.ToInt16(data[i + 34]);
                    analog.CIP = data[i + 35];
                    analog.ABCIPDataType = data[i + 36];
                    analog.ShortDescription = data[i + 37];
                    analog.DisplayOrder = Convert.ToInt32(data[i + 38]);

                    analogs.Add(analog);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return analogs;
        }
    }
}
