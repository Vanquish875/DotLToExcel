using System;
using System.Collections.Generic;
using DotLToExcel.POCOS;
using DotLToExcel.DotL;
using System.IO;
using System.Linq;
using System.Windows.Media.Animation;

namespace DotLToExcel.Mapping
{
    public class MultistateMapper
    {
        public List<Multistate> MapMultistate(IList<string> data)
        {
            int FieldLength = MultistateFields.Fields.Length;
            List<Multistate> digital = new List<Multistate>();

            try
            {
                for (int i = 0; i < data.Count; i += FieldLength)
                {
                    Multistate multistate = new Multistate();
                    multistate.NewName = data[i];
                    multistate.Remote = data[i + 1];
                    multistate.dataset = data[i + 2];
                    multistate.Group = data[i + 3];
                    multistate.Station = data[i + 4];
                    multistate.Message = data[i + 5];
                    multistate.PriorityDisplay = data[i + 6];
                    multistate.SafetyRelatedPoint = data[i + 7];
                    multistate.Description = data[i + 8];
                    multistate.NumberOfInputBits = Convert.ToInt32(data[i + 21]);
                    multistate.CoordinatesBit1 = data[i + 9];
                    multistate.BitNumberBit1 = Convert.ToInt32(data[i + 22]);
                    multistate.CoordinatesBit2 = data[i + 10];
                    multistate.BitNumberBit2 = Convert.ToInt32(data[i + 23]);
                    multistate.CoordinatesBit3 = data[i + 11];
                    multistate.BitNumberBit3 = Convert.ToInt32(data[i + 24]);
                    multistate.CoordinatesBit4 = data[i + 12];
                    multistate.BitNumberBit4 = Convert.ToInt32(data[i + 25]);
                    multistate.CoordinatesBit5 = data[i + 13];
                    multistate.BitNumberBit5 = Convert.ToInt32(data[i + 26]);
                    multistate.CoordinatesBit6 = data[i + 14];
                    multistate.BitNumberBit6 = Convert.ToInt32(data[i + 27]);
                    multistate.CoordinatesBit7 = data[i + 15];
                    multistate.BitNumberBit7 = Convert.ToInt32(data[i + 28]);
                    multistate.CoordinatesBit8 = data[i + 16];
                    multistate.BitNumberBit8 = Convert.ToInt32(data[i + 29]);
                    multistate.HasOutput = data[i + 20];
                    multistate.HasInput = data[i + 19];
                    multistate.OutputCoordinates1 = data[i + 17];
                    multistate.Timeout1 = Convert.ToInt32(data[i + 30]);
                    multistate.OutputCoordinates2 = data[i + 18];
                    multistate.Timeout2 = Convert.ToInt32(data[i + 31]);
                    multistate.ScanBlock = Convert.ToInt16(data[i + 32]);
                    multistate.CIP = data[i + 33];
                    multistate.ABCIPDataType = data[i + 34];
                    multistate.DisplayOrder = Convert.ToInt32(data[i + 35]);
                    multistate.ShortDescription = data[i + 36];

                    digital.Add(multistate);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return digital;
        }
    }
}
