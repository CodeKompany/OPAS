using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYPWebApp.Models
{
    public class PatientHistory
    {
        [BsonId]
        public string Id { get; set; }
        public string dov { get; set; }
        public string HospitalId { get; set; }
        public string DoctorId { get; set; }
        public Diagnosis diag { get; set; }
        public Prescription prescrip { get; set; }
        public List<LabTest> labtest { get; set; }
        public Surgery surgery { get; set; }
    }
}