namespace DotLToExcel.POCOS
{
    public class Digital
    {
        public string Group { get; set; }
        public string LegacyName { get; set; }
        public string NewName { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Remote { get; set; }
        public string dataset { get; set; }
        public string Station { get; set; }
        public string Message { get; set; }
        public string PriorityDisplay { get; set; }
        public int DisplayOrder { get; set; }
        public string SubRemoteStatusIndicator { get; set; }
        public string HasInput { get; set; }
        public int NumberOfInputBits { get; set; }
        public string CoordinatesBit1 { get; set; }
        public string PollGroup1 { get; set; }
        public int BitNumberBit1 { get; set; }
        public string NormallyOpenBit1 { get; set; }
        public string CoordinatesBit2 { get; set; }
        public string PollGroup2 { get; set; }
        public int BitNumberBit2 { get; set; }
        public string NormallyOpenBit2 { get; set; }
        public string HasOutput { get; set; }
        public string OutputMessage { get; set; }
        public string CommandType1 { get; set; }
        public string OutputType1 { get; set; }
        public string OutputCoordinates1 { get; set; }
        public string Command1 { get; set; }
        public int Timeout1 { get; set; }
        public string CommandType2 { get; set; }
        public string OutputType2 { get; set; }
        public string OutputCoordinates2 { get; set; }
        public string Command2 { get; set; }
        public int Timeout2 { get; set; }
        public string AbnormalState { get; set; }
        public string CIP { get; set; }
        public int ScanBlock { get; set; }
        public string ABCIPDataType { get; set; }
        public string SafetyRelatedPoint { get; set; }
    }
}
