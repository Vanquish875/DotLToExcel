using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotLToExcel.DotL;
using DotLToExcel.Excel;
using DotLToExcel.POCOS;

namespace DotLToExcel.Classes
{
    public class Worker
    {
        readonly string filePath;
        private Mapper _mapper;

        List<Analog> analogs = new List<Analog>();
        List<Connection> connections = new List<Connection>();
        List<Remote> remotes = new List<Remote>();
        List<Rate> rates = new List<Rate>();
        List<Digital> status = new List<Digital>();
        List<Multistate> multistates = new List<Multistate>();
        List<Station> stations = new List<Station>();
        List<Message> messages = new List<Message>();

        public Worker(Mapper mapper, string filePath)
        {
            _mapper = mapper;
            this.filePath = filePath;
        }

        public void parseRemConnJoin()
        {
            Parser parser = new Parser();

            //Call this to populate the remoteConnections dictionary to be used for mapping remotes.
            _mapper.mapRemConnJoin(parser.processFile(filePath + @"\remconnjoin.l", RemConnFields.Fields));
        }

        public void parseMessages()
        {
            Parser parser = new Parser();

            //Call this to map the messages
            messages = _mapper.mapMessages(parser.processFile(filePath + @"\message.l", MessageFields.Fields));
        }

        public void mapLegacyNames()
        {
            //Call this to populate the dictionaries to be used for mapping legacyNames.
            _mapper.mapLegacyNames(filePath);
        }

        public void mapStations()
        {
            Parser parser = new Parser();

            stations = _mapper.mapStation(parser.processFile(filePath + @"\station.l", StationFields.Fields));
        }

        public void mapConnections()
        {
            Parser parser = new Parser();

            connections = _mapper.mapConnection(parser.processFile(filePath + @"\connection.l", ConnectionFields.Fields));
        }

        public void mapRemotes()
        {
            Parser parser = new Parser();

            remotes = _mapper.mapRemote(parser.processFile(filePath + @"\remote.l", RemoteFields.Fields));
        }

        public void mapAnalogs()
        {
            Parser parser = new Parser();

            analogs = _mapper.mapAnalog(parser.processFile(filePath + @"\analog.l", AnalogFields.Fields));
        }

        public void mapRates()
        {
            Parser parser = new Parser();

            rates = _mapper.mapRate(parser.processFile(filePath + @"\rate.l", RateFields.Fields));
        }
        public void mapStatus()
        {
            Parser parser = new Parser();

            status = _mapper.mapStatus(parser.processFile(filePath + @"\status.l", StatusFields.Fields));
        }
        public void mapMultistate()
        {
            Parser parser = new Parser();

            multistates = _mapper.mapMultistate(parser.processFile(filePath + @"\multistate.l", MultistateFields.Fields));
        }

        public void callExcel()
        {
            ExcelManager excel = new ExcelManager();
            excel.writeToExcel(stations, remotes, connections, analogs, rates, status, multistates, messages);
        }
    }
}
