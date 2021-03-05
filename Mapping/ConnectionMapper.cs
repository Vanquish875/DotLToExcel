using System;
using System.Collections.Generic;
using DotLToExcel.POCOS;
using DotLToExcel.DotL;
using System.IO;
using System.Linq;
using System.Windows.Media.Animation;

namespace DotLToExcel.Mapping
{
    public class ConnectionMapper
    {
        public IEnumerable<Connection> MapConnection(IList<string> data)
        {
            int FieldLength = ConnectionFields.Fields.Length;
            var connections = new List<Connection>();

            try
            {
                for(int i = 0; i < data.Count; i += FieldLength)
                {
                    var connection = new Connection
                    {
                        Name = data[i],
                        Omnicomm = data[i + 1],
                        Group = data[i + 2],
                        Description = data[i + 3],
                        Message = data[i + 4],
                        IP = data[i + 5],
                        Port = Convert.ToInt32(data[i + 6])
                    };
                    connections.Add(connection);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return connections;
        }
    }
}
