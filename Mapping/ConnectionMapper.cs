using DotLToExcel.DotL;
using DotLToExcel.POCOS;
using System;
using System.Collections.Generic;

namespace DotLToExcel.Mapping
{
    public class ConnectionMapper
    {
        public IEnumerable<Connection> MapConnection(List<string> data)
        {
            int FieldLength = ConnectionFields.Fields.Length;
            var connections = new List<Connection>();

            try
            {
                for (int i = 0; i < data.Count; i += FieldLength)
                {
                    CreateConnection(data, connections, i);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return connections;
        }

        public IEnumerable<Connection> MapConnection(List<string> data, HashSet<string> anrData)
        {
            int FieldLength = ConnectionFields.Fields.Length;
            var connections = new List<Connection>();

            try
            {
                for (int i = 0; i < data.Count; i += FieldLength)
                {
                    if (anrData.Contains(data[i + 2]))
                    {
                        CreateConnection(data, connections, i);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return connections;
        }

        private static void CreateConnection(List<string> data, List<Connection> connections, int i)
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
}
