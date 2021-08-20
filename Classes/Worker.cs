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
        HashSet<string> ANRGroups = new HashSet<string>();

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

        public void ParseAllTables()
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
            AnalogNames = _legacyNameMapper.MapLegacyNames(filePath, "AnalogNames.csv");
            StatusNames = _legacyNameMapper.MapLegacyNames(filePath, "StatusNames.csv");
            stations = _stationMapper.MapStation(stationList);
            connections = _connectionMapper.MapConnection(connectionList);
            remotes = _remoteMapper.MapRemote(remoteList, ConnectionRemote);
            analogs = _analogMapper.MapAnalog(analogList, AnalogNames);
            rates = _rateMapper.MapRate(rateList, AnalogNames);
            status = _statusMapper.MapStatus(statusList, StatusNames, OutputMessages);
            multistates = _multistateMapper.MapMultistate(multistateList);
            var templates = _templateMapper.MapTemplateDef(cglTemplatesList);
            cgls = _CGLMapper.MapCGLTemplate(templates);
        }

        public void ParseANRTables()
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

            LoadANRGroups();

            ConnectionRemote = _remConnJoinMapper.MapRemConnJoin(remConnJoinList);
            messages = _messageMapper.MapMessages(messageList);
            OutputMessages = _messageMapper.OutputMessages;
            stations = _stationMapper.MapStation(stationList, ANRGroups);
            connections = _connectionMapper.MapConnection(connectionList, ANRGroups);
            remotes = _remoteMapper.MapRemote(remoteList, ConnectionRemote, ANRGroups);
            analogs = _analogMapper.MapAnalog(analogList, ANRGroups);
            rates = _rateMapper.MapRate(rateList, ANRGroups);
            status = _statusMapper.MapStatus(statusList, OutputMessages, ANRGroups);
            multistates = _multistateMapper.MapMultistate(multistateList, ANRGroups);
            var templates = _templateMapper.MapTemplateDef(cglTemplatesList);
            cgls = _CGLMapper.MapCGLTemplate(templates);
        }

        public void CallExcel()
        {
            ExcelManager excel = new ExcelManager();
            excel.WriteToExcel(stations, remotes, connections, analogs, rates, status, multistates, messages, cgls);
        }

        public void LoadANRGroups()
        {
            ANRGroups.Add("EACAD");
            ANRGroups.Add("EALEX");
            ANRGroups.Add("ECELE");
            ANRGroups.Add("EDEFN");
            ANRGroups.Add("EDEFS");
            ANRGroups.Add("EDELH");
            ANRGroups.Add("EDELT");
            ANRGroups.Add("ESARD");
            ANRGroups.Add("EWETL");
            ANRGroups.Add("NBADN");
            ANRGroups.Add("NBADS");
            ANRGroups.Add("NBLUE");
            ANRGroups.Add("NCALW");
            ANRGroups.Add("NGAYL");
            ANRGroups.Add("NMACK");
            ANRGroups.Add("NPINE");
            ANRGroups.Add("NREED");
            ANRGroups.Add("NSTCL");
            ANRGroups.Add("NWOOL");
            ANRGroups.Add("WBIRM");
            ANRGroups.Add("WCALC");
            ANRGroups.Add("WCALW");
            ANRGroups.Add("WFLNT");
            ANRGroups.Add("WMICH");
            ANRGroups.Add("WMOOR");
        }
    }
}
