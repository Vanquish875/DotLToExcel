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
            var digital = new List<Multistate>();

            try
            {
                for (int i = 0; i < data.Count; i += FieldLength)
                {
                    var multistate = new Multistate
                    {
                        NewName = data[i],
                        Remote = data[i + 1],
                        dataset = data[i + 2],
                        Group = data[i + 3],
                        Station = data[i + 4],
                        Message = data[i + 5],
                        PriorityDisplay = data[i + 6],
                        SafetyRelatedPoint = data[i + 7],
                        Description = data[i + 8],
                        NumberOfInputBits = Convert.ToInt32(data[i + 21]),
                        CoordinatesBit1 = data[i + 9];
                        BitNumberBit1 = Convert.ToInt32(data[i + 22]),
                        CoordinatesBit2 = data[i + 10],
                        BitNumberBit2 = Convert.ToInt32(data[i + 23]),
                        CoordinatesBit3 = data[i + 11],
                        BitNumberBit3 = Convert.ToInt32(data[i + 24]),
                        CoordinatesBit4 = data[i + 12],
                        BitNumberBit4 = Convert.ToInt32(data[i + 25]),
                        CoordinatesBit5 = data[i + 13],
                        BitNumberBit5 = Convert.ToInt32(data[i + 26]),
                        CoordinatesBit6 = data[i + 14],
                        BitNumberBit6 = Convert.ToInt32(data[i + 27]),
                        CoordinatesBit7 = data[i + 15],
                        BitNumberBit7 = Convert.ToInt32(data[i + 28]),
                        CoordinatesBit8 = data[i + 16],
                        BitNumberBit8 = Convert.ToInt32(data[i + 29]),
                        HasOutput = data[i + 20],
                        HasInput = data[i + 19],
                        OutputCoordinates1 = data[i + 17],
                        Timeout1 = Convert.ToInt32(data[i + 30]),
                        OutputCoordinates2 = data[i + 18],
                        Timeout2 = Convert.ToInt32(data[i + 31]),
                        ScanBlock = Convert.ToInt16(data[i + 32]),
                        CIP = data[i + 33],
                        ABCIPDataType = data[i + 34],
                        DisplayOrder = Convert.ToInt32(data[i + 35]),
                        ShortDescription = data[i + 36],
                    };
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
