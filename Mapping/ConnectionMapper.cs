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
    }
}
