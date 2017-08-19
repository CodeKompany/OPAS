using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYPWebApp.Models
{
    public class Doctor
    {
        [BsonId]
        public string Id { get; set; }
        public string DoctorName { get; set; }
        public string DoctorId { get; set; }
        public string DoctorSpeciality { get; set; }
        public Hospital hospitals { get; set; }
    }
}