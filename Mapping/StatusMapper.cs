using DotLToExcel.DotL;
using DotLToExcel.POCOS;
using System;
using System.Collections.Generic;

namespace DotLToExcel.Mapping
{
    public class StatusMapper
    {
        public List<Digital> MapStatus(IList<string> data, Dictionary<string, string> StatusNames, Dictionary<string, string> Messages)
        {
            int FieldLength = StatusFields.Fields.Length;
            List<Digital> digital = new List<Digital>();

            try
            {
                for (int i = 0; i < data.Count; i += FieldLength)
                {
                    Digital status = new Digital();
                    status.LegacyName = Helper.ReturnValFromDictionary(data[i], StatusNames);
                    status.NewName = data[i];
                    status.Remote = data[i + 1];
                    status.dataset = data[i + 2];
                    status.Group = data[i + 3];
                    status.Station = data[i + 4];
                    status.Message = data[i + 5];
                    status.PriorityDisplay = data[i + 6];
                    status.SafetyRelatedPoint = data[i + 7];
                    status.NumberOfInputBits = Convert.ToInt32(data[i + 8]);
                    status.CoordinatesBit1 = data[i + 9];
                    status.BitNumberBit1 = Convert.ToInt32(data[i + 10]);
                    status.NormallyOpenBit1 = data[i + 11];
                    status.CoordinatesBit2 = data[i + 12];
                    status.BitNumberBit2 = Convert.ToInt32(data[i + 13]);
                    status.NormallyOpenBit2 = data[i + 14];
                    status.HasOutput = data[i + 15];
                    status.HasInput = data[i + 16];
                    status.OutputCoordinates1 = data[i + 17];
                    if (data[i + 15].Equals("yes"))
                    {
                        if (data[i + 29].Equals(""))
                        {
                            status.CommandType1 = Helper.ReturnValFromDictionary(data[i + 5] + "1", Messages);
                            status.CommandType2 = Helper.ReturnValFromDictionary(data[i + 5] + "2", Messages);
                        }
                        else
                        {
                            status.CommandType1 = Helper.ReturnValFromDictionary(data[i + 29] + "1", Messages);
                            status.CommandType2 = Helper.ReturnValFromDictionary(data[i + 29] + "2", Messages);
                        }
                    }
                    status.OutputType1 = data[i + 18];
                    status.Command1 = data[i + 19];
                    status.Timeout1 = Convert.ToInt32(data[i + 20]);
                    status.OutputCoordinates2 = data[i + 21];
                    status.OutputType2 = data[i + 22];
                    status.Command2 = data[i + 23];
                    status.Timeout2 = Convert.ToInt32(data[i + 24]);
                    status.Description = data[i + 25];
                    status.ScanBlock = Convert.ToInt16(data[i + 26]);
                    status.CIP = data[i + 27];
                    status.ABCIPDataType = data[i + 28];
                    status.OutputMessage = data[i + 29];
                    status.DisplayOrder = Convert.ToInt32(data[i + 30]);
                    status.ShortDescription = data[i + 31];

                    digital.Add(status);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return digital;
        }

        public List<Digital> MapStatus(IList<string> data, Dictionary<string, string> Messages, HashSet<string> anrData)
        {
            int FieldLength = StatusFields.Fields.Length;
            List<Digital> digital = new List<Digital>();

            try
            {
                for (int i = 0; i < data.Count; i += FieldLength)
                {
                    if(anrData.Contains(data[i + 3]))
                    {
                        Digital status = new Digital();
                        status.LegacyName = data[i + 30];
                        status.NewName = data[i];
                        status.Remote = data[i + 1];
                        status.dataset = data[i + 2];
                        status.Group = data[i + 3];
                        status.Station = data[i + 4];
                        status.Message = data[i + 5];
                        status.PriorityDisplay = data[i + 6];
                        status.SafetyRelatedPoint = data[i + 7];
                        status.NumberOfInputBits = Convert.ToInt32(data[i + 8]);
                        status.CoordinatesBit1 = data[i + 9];
                        status.BitNumberBit1 = Convert.ToInt32(data[i + 10]);
                        status.NormallyOpenBit1 = data[i + 11];
                        status.CoordinatesBit2 = data[i + 12];
                        status.BitNumberBit2 = Convert.ToInt32(data[i + 13]);
                        status.NormallyOpenBit2 = data[i + 14];
                        status.HasOutput = data[i + 15];
                        status.HasInput = data[i + 16];
                        status.OutputCoordinates1 = data[i + 17];
                        if (data[i + 15].Equals("yes"))
                        {
                            if (data[i + 29].Equals(""))
                            {
                                status.CommandType1 = Helper.ReturnValFromDictionary(data[i + 5] + "1", Messages);
                                status.CommandType2 = Helper.ReturnValFromDictionary(data[i + 5] + "2", Messages);
                            }
                            else
                            {
                                status.CommandType1 = Helper.ReturnValFromDictionary(data[i + 29] + "1", Messages);
                                status.CommandType2 = Helper.ReturnValFromDictionary(data[i + 29] + "2", Messages);
                            }
                        }
                        status.OutputType1 = data[i + 18];
                        status.Command1 = data[i + 19];
                        status.Timeout1 = Convert.ToInt32(data[i + 20]);
                        status.OutputCoordinates2 = data[i + 21];
                        status.OutputType2 = data[i + 22];
                        status.Command2 = data[i + 23];
                        status.Timeout2 = Convert.ToInt32(data[i + 24]);
                        status.Description = data[i + 25];
                        status.ScanBlock = Convert.ToInt16(data[i + 26]);
                        status.CIP = data[i + 27];
                        status.ABCIPDataType = data[i + 28];
                        status.OutputMessage = data[i + 29];
                        status.DisplayOrder = Convert.ToInt32(data[i + 31]);
                        status.ShortDescription = data[i + 32];

                        digital.Add(status);
                    }
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
