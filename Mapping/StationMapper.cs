using System;
using System.Collections.Generic;
using DotLToExcel.POCOS;
using DotLToExcel.DotL;
using System.IO;
using System.Linq;
using System.Windows.Media.Animation;

namespace DotLToExcel.Mapping
{
    public class StationMapper
    { 
        public List<Station> MapStation(IList<string> data)
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
