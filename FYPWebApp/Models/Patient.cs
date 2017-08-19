using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYPWebApp.Models
{
    public class Patient
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string CNIC { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string FamilyNumber { get; set; }
        [BsonElement("Patient_History")]
        public List<PatientHistory> ph { get; set; }
    }
}