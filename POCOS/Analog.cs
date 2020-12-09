using System;

namespace DotLToExcel
{
    public class Analog
    {
        public string LegacyName { get; set; }
        public string NewName { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Remote { get; set; }
        public string Station { get; set; }
        public string Message { get; set; }
        //public string PointClass { get; set; }
        //public string PointSubClass { get; set; }
        public int DisplayOrder { get; set; }
        public string dataset { get; set; }
        public string EngineeringUnits { get; set; }
        public string HasInput { get; set; }
        public string InputDataType { get; set; }
        public string InputCoordinates { get; set; }
        public int MinEGU { get; set; }
        public string MaxEGU { get; set; }
        public string ConvertRawToEGU { get; set; }
        public int MinRaw { get; set; }
        public string MaxRaw { get; set; }
        public string ProcessingDeadband { get; set; }
        public string HasOutput { get; set; }
        public string OutputDataType { get; set; }
        public string OutputCoordinates { get; set; }
        public int MinEGUOutput { get; set; }
        public string MaxEGUOutput { get; set; }
        public string ConvertRawToEGUOutput { get; set; }
        public int MinRawOutput { get; set; }
        public string MaxRawOutput { get; set; }
        public string LoLoCheck { get; set; }
        public string LoCheck { get; set; }
        public string HiCheck { get; set; }
        public string HiHiCheck { get; set; }
        public double LoLoLimit { get; set; }
        public double LoLimit { get; set; }
        public double HiLimit { get; set; }
        public double HiHiLimit { get; set; }
        public string InstrumentFailCheck { get; set; }
        public string SafetyPoint { get; set; }
        public string CIP { get; set; }
        public int ScanBlock { get; set; }
        public string ABCIPDataType { get; set; }
        public string Group { get; set; }
    }
}
