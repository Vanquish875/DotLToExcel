using DotLToExcel.DotL;
using DotLToExcel.POCOS;
using System;
using System.Collections.Generic;

namespace DotLToExcel.Mapping
{
    public class RemoteMapper
    {
        public List<Remote> MapRemote(IList<string> data, Dictionary<string, string> ConnectionRemote)
        {
            int FieldLength = RemoteFields.Fields.Length;
            var remotes = new List<Remote>();

            try
            {
                for (int i = 0; i < data.Count; i += FieldLength)
                {
                    var remote = new Remote
                    {
                        Name = data[i],
                        Group = data[i + 1],
                        Station = data[i + 2],
                        Description = data[i + 3],
                        Message = data[i + 4],
                        Protocol = data[i + 5],
                        Address = data[i + 6],
                        FastScanDuration = Convert.ToInt32(data[i + 7]),
                        TimeoutInvalidMsg = Convert.ToInt32(data[i + 8]),
                        TimeoutNoReply = Convert.ToInt32(data[i + 9]),
                        NoResponseDelay = data[i + 10],
                        PollDelay = data[i + 11],
                        OverheadProcessing = Convert.ToInt32(data[i + 12]),
                        RTUTurnaround = Convert.ToInt32(data[i + 13]),
                        TimeoutLineFailure = Convert.ToInt32(data[i + 14]),
                        PrimaryConnection = Helper.ReturnValFromDictionary(data[i], ConnectionRemote)
                    };
                    remotes.Add(remote);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return remotes;
        }
    }
}
