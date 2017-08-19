using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYPWebApp.Models
{
    public class Prescription
    {
        [BsonId]
        public string Id { get; set; }
        public List<Medicine> medicine { get; set; }
        public string Recommendations { get; set; }
    }
}