using System;

namespace DotLToExcel.POCOS
{
    public class Remote
    {
        public string Group { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Station { get; set; }
        public string Message { get; set; }
        public string Protocol { get; set; }
        public string Address { get; set; }
        public int FastScanDuration { get; set; }
        public int TimeoutNoReply { get; set; }
        public int TimeoutInvalidMsg { get; set; }
        public int TimeoutLineFailure { get; set; }
        public string PollDelay { get; set; }
        public string NoResponseDelay { get; set; }
        public string RTNCycles { get; set; }
        public int RTUTurnaround { get; set; }
        public int OverheadProcessing { get; set; }
        public string ProtocolRetries { get; set; }
        public string HistoryDevicesOnly { get; set; }
        public string UseDSTLockout { get; set; }
        public string LockOutHours { get; set; }
        public string LockOutExpiry { get; set; }
        public string AllowableTimeSkew { get; set; }
        public string ClockSyncTolerance { get; set; }
        public string DriftTolerance { get; set; }
        public string Timezone { get; set; }
        public string UseDST { get; set; }
        public string RTUAppliesDSTAuto { get; set; }
        public string PrimaryConnection { get; set; }
        public string InhibitAutoPoll { get; set; }
    }
}
