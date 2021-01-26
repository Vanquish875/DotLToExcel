using System;
using System.Collections.Generic;
using DotLToExcel.POCOS;
using DotLToExcel.DotL;
using System.IO;
using System.Linq;
using System.Windows.Media.Animation;

namespace DotLToExcel.Mapping
{
    public class RemConnJoinMapper
    {
        public Dictionary<string,string> mapRemConnJoin(IList<string> data)
        {
            int FieldLength = RemConnFields.Fields.Length;
            Dictionary<string, string> ConnectionRemote = new Dictionary<string, string>();
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
            return ConnectionRemote;
        }
    }
}
