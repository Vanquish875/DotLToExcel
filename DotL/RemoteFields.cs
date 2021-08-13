namespace DotLToExcel.DotL
{
    public static class RemoteFields
    {
        public static string[] Fields =
        {
            "name",
            "group ",
            "station",
            "description",
            "flag.bmsg",
            "proto",
            "adrs",
            "fastscanint",
            "im_timeout",               //<--Timeout(Invalid Msg)
            "nr_timeout",               //<--Timeout(No Reply)
            "offline_delay.high",       //<--No Response Delay
            "rtu_poll_delay.high ",     //<--Poll Delay
            "cmd_xtime",                //<--Overhead Processing Time
            "delay",                    //<--RTU Turnaround Time
            "lf_timeout",                //<--Timeout(Line Failure)
            "assetId.assetIdLoc ",
            "assetId.assetIdComment "
        };
    }
}
