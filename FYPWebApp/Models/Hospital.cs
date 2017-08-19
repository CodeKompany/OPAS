using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYPWebApp.Models
{
    public class Hospital
    {
        [BsonId]
        public string Id { get; set; }
        public string HospitalName { get; set; }
        public string HospitalId { get; set; }
        public string HospitalAddress { get; set; }
        public string HospitalTimings { get; set; }
        public Doctor doctor { get; set; }
    }
}