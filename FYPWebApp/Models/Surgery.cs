using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYPWebApp.Models
{
    public class Surgery
    {
        [BsonId]
        public string Id { get; set; }
        public string SurgeryName { get; set; }
        public string SurgeryType { get; set; }
        public string SurgeryDescription { get; set; }
    }
}