using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotLToExcel.DotL;
using DotLToExcel.Excel;
using DotLToExcel.POCOS;
using DotLToExcel.Mapping;

namespace DotLToExcel.Classes
{
    public class Worker
    {
        readonly string filePath;

        List<Analog> analogs = new List<Analog>();
        List<Connection> connections = new List<Connection>();
        List<Remote> remotes = new List<Remote>();
        List<Rate> rates = new List<Rate>();
        List<Digital> status = new List<Digital>();
        List<Multistate> multistates = new List<Multistate>();
        List<Station> stations = new List<Station>();
        List<Message> messages = new List<Message>();
        IDictionary<string, string> ConnectionRemote = new Dictionary<string, string>();
        IDictionary<string, string> AnalogNames = new Dictionary<string, string>();
        IDictionary<string, string> StatusNames = new Dictionary<string, string>();
        Dictionary<string, string> OutputMessages = new Dictionary<string, string>();

        public Worker(string filePath)
        {
            this.filePath = filePath;
        }

        public void parseRemConnJoin()
        {
            Parser parser = new Parser();
            RemConnJoinMapper mapper = new RemConnJoinMapper(); 

            //Call this to populate the remoteConnections dictionary to be used for mapping remotes.
            ConnectionRemote = mapper.mapRemConnJoin(parser.processFile(filePath + @"\remconnjoin.l", RemConnFields.Fields));
        }

        public void parseMessages()
        {
            Parser parser = new Parser();
            MessageMapper mapper = new MessageMapper();

            //Call this to map the messages
            messages = mapper.mapMessages(parser.processFile(filePath + @"\message.l", MessageFields.Fields));
            OutputMessages = mapper.OutputMessages;
        }

        public void mapLegacyNames()
        {
            LegacyNameMapper mapper = new LegacyNameMapper();

            //Call this to populate the Analog Names dictionary.
            AnalogNames = mapper.mapLegacyNames(filePath, "AnalogNames.csv");

            //Call this to populate the Status Names dictionary.
            StatusNames = mapper.mapLegacyNames(filePath, "StatusNames.csv");
        }

        public void mapStations()
        {
            Parser parser = new Parser();
            StationMapper mapper = new StationMapper();

            stations = mapper.mapStation(parser.processFile(filePath + @"\station.l", StationFields.Fields));
        }

        public void mapConnections()
        {
            Parser parser = new Parser();
            ConnectionMapper mapper = new ConnectionMapper();

            connections = mapper.mapConnection(parser.processFile(filePath + @"\connection.l", ConnectionFields.Fields));
        }

        public void mapRemotes()
        {
            Parser parser = new Parser();
            RemoteMapper mapper = new RemoteMapper();

            remotes = mapper.mapRemote(parser.processFile(filePath + @"\remote.l", RemoteFields.Fields), ConnectionRemote);
        }

        public void mapAnalogs()
        {
            Parser parser = new Parser();
            AnalogMapper mapper = new AnalogMapper();

            analogs = mapper.mapAnalog(parser.processFile(filePath + @"\analog.l", AnalogFields.Fields), AnalogNames);
        }

        public void mapRates()
        {
            Parser parser = new Parser();
            RateMapper mapper = new RateMapper();

            rates = mapper.mapRate(parser.processFile(filePath + @"\rate.l", RateFields.Fields), AnalogNames);
        }
        public void mapStatus()
        {
            Parser parser = new Parser();
            StatusMapper mapper = new StatusMapper();

            status = mapper.mapStatus(parser.processFile(filePath + @"\status.l", StatusFields.Fields), StatusNames, OutputMessages);
        }
        public void mapMultistate()
        {
            Parser parser = new Parser();
            MultistateMapper mapper = new MultistateMapper();

            multistates = mapper.mapMultistate(parser.processFile(filePath + @"\multistate.l", MultistateFields.Fields));
        }

        public void callExcel()
        {
            ExcelManager excel = new ExcelManager();
            excel.writeToExcel(stations, remotes, connections, analogs, rates, status, multistates, messages);
        }
    }
}
