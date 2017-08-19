using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYPWebApp.Models
{
    public class Medicine
    {
        [BsonId]
        public string Id { get; set; }
        public string MedicineName { get; set; }
        public string MedicineDosage { get; set; }
        public string MedicineWeight { get; set; }
        public string NoOfDays { get; set; }
        public string MedicineType { get; set; }
    }
}