using System;
using System.Collections.Generic;
using DotLToExcel.POCOS;
using DotLToExcel.DotL;
using System.IO;
using System.Linq;
using System.Windows.Media.Animation;

namespace DotLToExcel.Classes
{
    public class Mapper
    {
        Dictionary<string, string> ConnectionRemote = new Dictionary<string, string>();
        Dictionary<string, string> AnalogNames = new Dictionary<string, string>();
        Dictionary<string, string> RateNames = new Dictionary<string, string>();
        Dictionary<string, string> StatusNames = new Dictionary<string, string>();
        Dictionary<string, string> Messages = new Dictionary<string, string>();

        public void mapLegacyNames(string filePath)
        {
            try
            {
                //Map analog legacy names.
                AnalogNames = File.ReadLines(filePath + @"\AnalogNames.csv")
                .Select(line => line.Split(','))
                .ToDictionary(line => line[0], line => line[1]);

                //Map rate legacy names.
                RateNames = File.ReadLines(filePath + @"\RateNames.csv")
                    .Select(line => line.Split(','))
                    .ToDictionary(line => line[0], line => line[1]);

                //Map status legacy names.
                StatusNames = File.ReadLines(filePath + @"\StatusNames.csv")
                    .Select(line => line.Split(','))
                    .ToDictionary(line => line[0], line => line[1]);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            } 
        }


        public void mapRemConnJoin(IList<string> data)
        {
            int FieldLength = RemConnFields.Fields.Length;
            try
            {
                for(int i = 0; i < data.Count; i += FieldLength)
                {
                    if(!Helper.returnBoolKeyExistsDictionary(data[i + 1], ConnectionRemote))
                    {
                        ConnectionRemote.Add(data[i + 1], data[i]);
                    }   
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public List<Message> mapMessages(IList<string> data)
        {
            int FieldLength = MessageFields.Fields.Length;
            List<Message> messages = new List<Message>();

            try
            {
                for(int i = 0; i < data.Count; i += FieldLength)
                {
                    Message message = new Message();
                    message.name = data[i];
                    message.setName = data[i + 1];
                    message.fg = data[i + 2];
                    message.severity = data[i + 3];
                    message.txt = data[i + 4];
                    message.image = data[i + 5];
                    message.rawValue = data[i + 6];
                    if(data[i+6].Equals("1") || data[i+6].Equals("2"))
                    {
                        Messages.Add(data[i], data[i + 4]);
                    }
                    messages.Add(message);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return messages;
        }

        public List<Connection> mapConnection(IList<string> data)
        {
            int FieldLength = ConnectionFields.Fields.Length;
            List<Connection> connections = new List<Connection>();

            try
            {
                for(int i = 0; i < data.Count; i += FieldLength)
                {
                    Connection connection = new Connection();
                    connection.Name = data[i];
                    connection.Omnicomm = data[i + 1];
                    connection.Group = data[i + 2];
                    connection.Description = data[i + 3];
                    connection.Message = data[i + 4];
                    connection.IP = data[i + 5];
                    connection.Port = Convert.ToInt32(data[i + 6]);
                    connections.Add(connection);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return connections;
        }

        public List<Remote> mapRemote(IList<string> data)
        {
            int FieldLength = RemoteFields.Fields.Length;
            List<Remote> remotes = new List<Remote>();

            try
            {
                for(int i = 0; i < data.Count; i += FieldLength)
                {
                    Remote remote = new Remote();
                    remote.Name = data[i];
                    remote.Group = data[i + 1];
                    remote.Station = data[i + 2];
                    remote.Description = data[i + 3];
                    remote.Message = data[i + 4];
                    remote.Protocol = data[i + 5];
                    remote.Address = data[i + 6];
                    remote.FastScanDuration = Convert.ToInt32(data[i + 7]);
                    remote.TimeoutInvalidMsg = Convert.ToInt32(data[i + 8]);
                    remote.TimeoutNoReply = Convert.ToInt32(data[i + 9]);
                    remote.NoResponseDelay = data[i + 10];
                    remote.PollDelay = data[i + 11];
                    remote.OverheadProcessing = Convert.ToInt32(data[i + 12]);
                    remote.RTUTurnaround = Convert.ToInt32(data[i + 13]);
                    remote.TimeoutLineFailure = Convert.ToInt32(data[i + 14]);
                    remote.PrimaryConnection = Helper.returnValFromDictionary(data[i], ConnectionRemote);
                    remotes.Add(remote);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return remotes;
        }

        public List<Analog> mapAnalog(IList<string> data)
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

        public List<Rate> mapRate(IList<string> data)
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

        public List<Digital> mapStatus(IList<string> data)
        {
            int FieldLength = StatusFields.Fields.Length;
            List<Digital> digital = new List<Digital>();

            try
            {
                for(int i = 0; i < data.Count; i += FieldLength)
                {
                    Digital status = new Digital();
                    status.LegacyName = Helper.returnValFromDictionary(data[i], StatusNames);
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
                    if(data[i + 15].Equals("yes"))
                    {
                        if(data[i + 29].Equals(""))
                        {
                            status.CommandType1 = Helper.returnValFromDictionary(data[i + 5] + "1", Messages);
                            status.CommandType2 = Helper.returnValFromDictionary(data[i + 5] + "2", Messages);
                        }
                        else
                        {
                            status.CommandType1 = Helper.returnValFromDictionary(data[i + 29] + "1", Messages);
                            status.CommandType2 = Helper.returnValFromDictionary(data[i + 29] + "2", Messages);
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return digital;
        }

        public List<Multistate> mapMultistate(IList<string> data)
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

        public List<Station> mapStation(IList<string> data)
        {
            int FieldLength = StationFields.Fields.Length;
            List<Station> stations = new List<Station>();

            try
            {
                for (int i = 0; i < data.Count; i += FieldLength)
                {
                    Station station = new Station();
                    station.Name = data[i];
                    station.Group = data[i + 1];
                    station.Dataset = data[i + 2];
                    station.Description = data[i + 3];
                    station.Message = data[i + 4];
                    station.Address1 = data[i + 5];
                    station.Address2 = data[i + 6];
                    station.City = data[i + 7];
                    station.DownStreamStation = data[i + 8];
                    station.Fax = data[i + 9];
					station.MilePost = data[i + 10];
                    station.MeterName = data[i + 11];
                    station.MeterNumber = data[i + 12];
                    station.StationNumber = Convert.ToInt32(data[i + 13]);
                    station.Phone1 = data[i + 14];
                    station.Phone2 = data[i + 15];
                    station.SchematicDisplayName = data[i + 16];
                    station.State = data[i + 17];
                    station.StationType = data[i + 18];
                    station.Templatename = data[i + 19];
					station.UpstreamStation = data[i + 20];
                    station.Zip = data[i + 21];

                    stations.Add(station);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return stations;
        }
    }
}
