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

        public void ParseAllTables(bool parseANRTables)
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

            if(parseANRTables)
            {
                var ANRGroups = Helper.LoadANRGroups();
                var ConnectionRemote = _remConnJoinMapper.MapRemConnJoin(remConnJoinList);
                var (messages, outputMessages) = _messageMapper.MapMessages(messageList);
                
                var stations = _stationMapper.MapStation(stationList, ANRGroups);
                var connections = _connectionMapper.MapConnection(connectionList, ANRGroups);
                var remotes = _remoteMapper.MapRemote(remoteList, ConnectionRemote, ANRGroups);
                var analogs = _analogMapper.MapAnalog(analogList, ANRGroups);
                var rates = _rateMapper.MapRate(rateList, ANRGroups);
                var status = _statusMapper.MapStatus(statusList, outputMessages, ANRGroups);
                var multistates = _multistateMapper.MapMultistate(multistateList, ANRGroups);
                var templates = _templateMapper.MapTemplateDef(cglTemplatesList);
                
                var cgls = _CGLMapper.MapCGLTemplate(templates);

                CallExcel(stations, remotes, connections, analogs, rates, status, multistates, messages, cgls);
            }
            else
            {
                var ConnectionRemote = _remConnJoinMapper.MapRemConnJoin(remConnJoinList);
                var (messages, outputMessages) = _messageMapper.MapMessages(messageList);
                
                var stations = _stationMapper.MapStation(stationList);
                var connections = _connectionMapper.MapConnection(connectionList);
                var remotes = _remoteMapper.MapRemote(remoteList, ConnectionRemote);
                var analogs = _analogMapper.MapAnalog(analogList);
                var rates = _rateMapper.MapRate(rateList);
                var status = _statusMapper.MapStatus(statusList, outputMessages);
                var multistates = _multistateMapper.MapMultistate(multistateList);
                var templates = _templateMapper.MapTemplateDef(cglTemplatesList);
                
                var cgls = _CGLMapper.MapCGLTemplate(templates);

                CallExcel(stations, remotes, connections, analogs, rates, status, multistates, messages, cgls);
            }
        }

        public void CallExcel(IEnumerable<Station> stations, IEnumerable<Remote> remotes, 
            IEnumerable<Connection> connections, IEnumerable<Analog> analogs, 
            IEnumerable<Rate> rates, IEnumerable<Digital> status, IEnumerable<Multistate> multistates,
            IEnumerable<Message> messages, IEnumerable<CGLTemplateDef> cgls)
        {
            ExcelManager excel = new ExcelManager();
            excel.WriteToExcel(stations, remotes, connections, analogs, rates, status, multistates, messages, cgls);
        }
    }
}
