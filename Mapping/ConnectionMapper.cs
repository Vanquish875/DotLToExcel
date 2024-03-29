﻿using DotLToExcel.DotL;
using DotLToExcel.POCOS;
using System;
using System.Collections.Generic;

namespace DotLToExcel.Mapping
{
    public class ConnectionMapper
    {
        public List<Connection> MapConnection(IList<string> data, HashSet<string> groups)
        {
            var FieldLength = ConnectionFields.Fields.Length;
            var connections = new List<Connection>();

            try
            {
                for (int i = 0; i < data.Count; i += FieldLength)
                {
                    if (groups.Contains(data[i + 2]))
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return connections;
        }
    }
}
