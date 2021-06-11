using DotLToExcel.DotL;
using DotLToExcel.Excel;
using DotLToExcel.Mapping;
using DotLToExcel.POCOS;
using System.Collections.Generic;

namespace DotLToExcel.Classes
{
    public class Worker
    {
        private readonly string filePath;
        private readonly string group;
        private readonly Parser _parser;
        private readonly AnalogMapper _analogMapper;
        private readonly ConnectionMapper _connectionMapper;
        private readonly LegacyNameMapper _legacyNameMapper;
        private readonly MessageMapper _messageMapper;
        private readonly MultistateMapper _multistateMapper;
        private readonly RateMapper _rateMapper;
        private readonly RemConnJoinMapper _remConnJoinMapper;
        private readonly RemoteMapper _remoteMapper;
        private readonly StationMapper _stationMapper;
        private readonly StatusMapper _statusMapper;

        List<Analog> analogs = new List<Analog>();
        List<Connection> connections = new List<Connection>();
        List<Remote> remotes = new List<Remote>();
        List<Rate> rates = new List<Rate>();
        List<Digital> status = new List<Digital>();
        List<Multistate> multistates = new List<Multistate>();
        List<Station> stations = new List<Station>();
        List<Message> messages = new List<Message>();
        Dictionary<string, string> ConnectionRemote = new Dictionary<string, string>();
        Dictionary<string, string> AnalogNames = new Dictionary<string, string>();
        Dictionary<string, string> StatusNames = new Dictionary<string, string>();
        Dictionary<string, string> OutputMessages = new Dictionary<string, string>();

        public Worker(string filePath)
        {
            this.filePath = filePath;
            _parser = new Parser();
            _analogMapper = new AnalogMapper();
            _connectionMapper = new ConnectionMapper();
            _legacyNameMapper = new LegacyNameMapper();
            _messageMapper = new MessageMapper();
            _multistateMapper = new MultistateMapper();
            _rateMapper = new RateMapper();
            _remConnJoinMapper = new RemConnJoinMapper();
            _remoteMapper = new RemoteMapper();
            _stationMapper = new StationMapper();
            _statusMapper = new StatusMapper();
        }

        public void ParseRemConnJoin()
        {
            var remConnJoinList = new List<string>();
            remConnJoinList = _parser.ProcessFile(filePath + @"\remconnjoin.l", RemConnFields.Fields);

            ConnectionRemote = _remConnJoinMapper.MapRemConnJoin(remConnJoinList);
        }

        public void ParseMessages()
        {
            var messageList = new List<string>();
            messageList = _parser.ProcessFile(filePath + @"\message.l", MessageFields.Fields);

            messages = _messageMapper.MapMessages(messageList);
            OutputMessages = _messageMapper.OutputMessages;
        }

        public void MapLegacyNames()
        {
            AnalogNames = _legacyNameMapper.MapLegacyNames(filePath, "AnalogNames.csv");
            StatusNames = _legacyNameMapper.MapLegacyNames(filePath, "StatusNames.csv");
        }

        public void MapStations()
        {
            var stationList = new List<string>();
            stationList = _parser.ProcessFile(filePath + @"\station.l", StationFields.Fields);
            stations = _stationMapper.MapStation(stationList);
        }

        public void MapConnections()
        {
            var connectionList = new List<string>();
            connectionList = _parser.ProcessFile(filePath + @"\connection.l", ConnectionFields.Fields);
            connections = _connectionMapper.MapConnection(connectionList);
        }

        public void MapRemotes()
        {
            var remoteList = new List<string>();
            remoteList = _parser.ProcessFile(filePath + @"\remote.l", RemoteFields.Fields);
            remotes = _remoteMapper.MapRemote(remoteList, ConnectionRemote);
        }

        public void MapAnalogs()
        {
            var analogList = new List<string>();
            analogList = _parser.ProcessFile(filePath + @"\analog.l", AnalogFields.Fields);
            analogs = _analogMapper.MapAnalog(analogList, AnalogNames);
        }

        public void MapRates()
        {
            var rateList = new List<string>();
            rateList = _parser.ProcessFile(filePath + @"\rate.l", RateFields.Fields);
            rates = _rateMapper.MapRate(rateList, AnalogNames);
        }
        public void MapStatus()
        {
            var statusList = new List<string>();
            statusList = _parser.ProcessFile(filePath + @"\status.l", StatusFields.Fields);
            status = _statusMapper.MapStatus(statusList, StatusNames, OutputMessages);
        }
        public void MapMultistate()
        {
            var multistateList = new List<string>();
            multistateList = _parser.ProcessFile(filePath + @"\multistate.l", MultistateFields.Fields);
            multistates = _multistateMapper.MapMultistate(multistateList);
        }

        public void CallExcel()
        {
            ExcelManager excel = new ExcelManager();
            excel.WriteToExcel(stations, remotes, connections, analogs, rates, status, multistates, messages);
        }
    }
}
