using System;
using System.Collections.Generic;
using DotLToExcel.POCOS;
using DotLToExcel.DotL;
using System.IO;
using System.Linq;
using System.Windows.Media.Animation;

namespace DotLToExcel.Mapping
{
    public class RemoteMapper
    {
        public List<Remote> mapRemote(IList<string> data, IDictionary<string, string> ConnectionRemote)
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
    }
}
