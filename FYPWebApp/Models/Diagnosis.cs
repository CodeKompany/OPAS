using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYPWebApp.Models
{
    public class Diagnosis
    {
        [BsonId]
        public string Id { get; set; }
        public string Description { get; set; }
        public string BodyTemprature { get; set; }
        public string BloodPressure { get; set; }
        public string HeartBeat { get; set; }
        public string SugarLevel { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string DiseaseName { get; set; }
    }
}