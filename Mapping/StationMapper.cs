using DotLToExcel.DotL;
using DotLToExcel.POCOS;
using System;
using System.Collections.Generic;

namespace DotLToExcel.Mapping
{
    public class StationMapper
    {
        public IEnumerable<Station> MapStation(List<string> data)
        {
            int FieldLength = StationFields.Fields.Length;
            var stations = new List<Station>();

            try
            {
                for (int i = 0; i < data.Count; i += FieldLength)
                {
                    CreateStation(data, stations, i);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return stations;
        }

        public IEnumerable<Station> MapStation(List<string> data, HashSet<string> anrData)
        {
            int FieldLength = StationFields.Fields.Length;
            var stations = new List<Station>();

            try
            {
                for (int i = 0; i < data.Count; i += FieldLength)
                {
                    if (anrData.Contains(data[i + 1]))
                    {
                        CreateStation(data, stations, i);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return stations;
        }

        private static void CreateStation(List<string> data, List<Station> stations, int i)
        {
            var station = new Station
            {
                Name = data[i],
                Group = data[i + 1],
                Dataset = data[i + 2],
                Description = data[i + 3],
                Message = data[i + 4],
                Address1 = data[i + 5],
                Address2 = data[i + 6],
                City = data[i + 7],
                DownStreamStation = data[i + 8],
                Fax = data[i + 9],
                MilePost = data[i + 10],
                MeterName = data[i + 11],
                MeterNumber = data[i + 12],
                StationNumber = Convert.ToInt32(data[i + 13]),
                Phone1 = data[i + 14],
                Phone2 = data[i + 15],
                SchematicDisplayName = data[i + 16],
                State = data[i + 17],
                StationType = data[i + 18],
                Templatename = data[i + 19],
                UpstreamStation = data[i + 20],
                Zip = data[i + 21]
            };
            stations.Add(station);
        }
    }
}
