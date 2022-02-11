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
        private readonly CGLTemplateMapper _templateMapper;
        private readonly CGLMapper _CGLMapper;

        List<Analog> analogs = new List<Analog>();
        List<Connection> connections = new List<Connection>();
        List<Remote> remotes = new List<Remote>();
        List<Rate> rates = new List<Rate>();
        List<Digital> status = new List<Digital>();
        List<Multistate> multistates = new List<Multistate>();
        List<Station> stations = new List<Station>();
        List<Message> messages = new List<Message>();
        List<CGLTemplateDef> cgls = new List<CGLTemplateDef>();
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
            _templateMapper = new CGLTemplateMapper();
            _CGLMapper = new CGLMapper();
        }

        public void ParseTablesByGroup()
        {
            var remConnJoinList = _parser.ProcessFile(filePath + @"\remconnjoin.l", RemConnFields.Fields);
            var messageList = _parser.ProcessFile(filePath + @"\message.l", MessageFields.Fields);
            var stationList = _parser.ProcessFile(filePath + @"\station.l", StationFields.Fields);
            var connectionList = _parser.ProcessFile(filePath + @"\connection.l", ConnectionFields.Fields);
            var remoteList = _parser.ProcessFile(filePath + @"\remote.l", RemoteFields.Fields);
            var analogList = _parser.ProcessFile(filePath + @"\analog.l", AnalogFields.Fields);
            var rateList = _parser.ProcessFile(filePath + @"\rate.l", RateFields.Fields);
            var statusList = _parser.ProcessFile(filePath + @"\status.l", StatusFields.Fields);
            var multistateList = _parser.ProcessFile(filePath + @"\multistate.l", MultistateFields.Fields);
            var cglTemplatesList = _parser.ProcessFile(filePath + @"\cgltemplatedef.l", CGLTemplateFields.Fields);


            ConnectionRemote = _remConnJoinMapper.MapRemConnJoin(remConnJoinList);
            messages = _messageMapper.MapMessages(messageList);
            OutputMessages = _messageMapper.OutputMessages;
            stations = _stationMapper.MapStation(stationList, Helper.LoadGroups());
            connections = _connectionMapper.MapConnection(connectionList, Helper.LoadGroups());
            remotes = _remoteMapper.MapRemote(remoteList, ConnectionRemote, Helper.LoadGroups());
            analogs = _analogMapper.MapAnalog(analogList, Helper.LoadGroups());
            rates = _rateMapper.MapRate(rateList, Helper.LoadGroups());
            status = _statusMapper.MapStatus(statusList, OutputMessages, Helper.LoadGroups());
            multistates = _multistateMapper.MapMultistate(multistateList, Helper.LoadGroups());
            var templates = _templateMapper.MapTemplateDef(cglTemplatesList);
            cgls = _CGLMapper.MapCGLTemplate(templates);
        }

        public void CallExcel()
        {
            ExcelManager excel = new ExcelManager();
            excel.WriteToExcel(stations, remotes, connections, analogs, rates, status, multistates, messages, cgls);
        }
    }
}
