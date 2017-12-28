using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbfahrtSkill.Models
{

    public class MonitorResult
    {
        public Data data { get; set; }
        public Message message { get; set; }
    }

    public class Data
    {
        public Monitor[] monitors { get; set; }
    }

    public class Monitor
    {
        public Locationstop locationStop { get; set; }
        public Line[] lines { get; set; }
        public Attributes1 attributes { get; set; }
    }

    public class Locationstop
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public float[] coordinates { get; set; }
    }

    public class Properties
    {
        public string name { get; set; }
        public string title { get; set; }
        public string municipality { get; set; }
        public int municipalityId { get; set; }
        public string type { get; set; }
        public string coordName { get; set; }
        public Attributes attributes { get; set; }
    }

    public class Attributes
    {
        public int rbl { get; set; }
    }

    public class Attributes1
    {
    }

    public class Line
    {
        public string name { get; set; }
        public string towards { get; set; }
        public string direction { get; set; }
        public string richtungsId { get; set; }
        public bool barrierFree { get; set; }
        public bool realtimeSupported { get; set; }
        public bool trafficjam { get; set; }
        public Departures departures { get; set; }
        public string type { get; set; }
        public int lineId { get; set; }
    }

    public class Departures
    {
        public Departure[] departure { get; set; }
    }

    public class Departure
    {
        public Departuretime departureTime { get; set; }
        public Vehicle vehicle { get; set; }
    }

    public class Departuretime
    {
        public DateTime timePlanned { get; set; }
        public DateTime timeReal { get; set; }
        public int countdown { get; set; }
    }

    public class Vehicle
    {
        public string name { get; set; }
        public string towards { get; set; }
        public string direction { get; set; }
        public string richtungsId { get; set; }
        public bool barrierFree { get; set; }
        public bool realtimeSupported { get; set; }
        public bool trafficjam { get; set; }
        public string type { get; set; }
        public Attributes2 attributes { get; set; }
        public int linienId { get; set; }
    }

    public class Attributes2
    {
    }

    public class Message
    {
        public string value { get; set; }
        public int messageCode { get; set; }
        public DateTime serverTime { get; set; }
    }

}
