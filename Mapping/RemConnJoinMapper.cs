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
        public void mapRemConnJoin(IList<string> data, IDictionary<string, string> ConnectionRemote)
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
    }
}
