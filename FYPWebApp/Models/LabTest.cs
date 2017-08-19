using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYPWebApp.Models
{
    public class LabTest
    {
        [BsonId]
        public string Id { get; set; }
        public string TestName { get; set; }
        public string LabName { get; set; }
        public string TestType { get; set; }
        public string LabTestDate { get; set; }
        public string LabResults { get; set; }
    }
}