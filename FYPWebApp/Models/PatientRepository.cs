using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace FYPWebApp.Models
{
    public class PatientRepository
    {
        
        public MongoDatabase _database;
        public MongoCollection _patient;
        public bool ServerIsDown = false;
        AESEncryptDecrypt EncryptAlgo;
        private string password;

        public PatientRepository(string Connection)
        {

            if (string.IsNullOrWhiteSpace(Connection))
            {
                Connection = "mongodb://localhost:27017";
            }

            EncryptAlgo = new AESEncryptDecrypt();
            password = "IBA/FYP1/OPAS";
            var client = new MongoClient(Connection);
           var server = client.GetServer();
            _database = server.GetDatabase("MedicalDatabase");
            _patient = _database.GetCollection("Patients_info");

            try
            {
                _database.Server.Ping();
            }
            catch(Exception ex)
            {
                ServerIsDown = true;
            }
        }

        public IEnumerable<Patient> GetAllPatient() 
        {
            List<Patient> _patientlist = new List<Patient>();
            var patients = _patient.FindAs(typeof(Patient), Query.NE("Name", "null"));
            if (patients.Count() > 0)
            {
                foreach (Patient patient in patients)
                {
                    patient.Name = EncryptAlgo.Decrypt(patient.Name, password);
                    patient.Address = EncryptAlgo.Decrypt(patient.Address, password);
                    patient.CNIC = EncryptAlgo.Decrypt(patient.CNIC, password);
                    patient.ContactNo = EncryptAlgo.Decrypt(patient.ContactNo, password);
                    patient.DOB = EncryptAlgo.Decrypt(patient.DOB, password);
                    patient.Gender = EncryptAlgo.Decrypt(patient.Gender, password);
                    patient.FamilyNumber = EncryptAlgo.Decrypt(patient.FamilyNumber, password);
                    _patientlist.Add(patient);
                }
            }
            else
            {
                _patientlist = null;
            }
            var result = _patientlist.AsQueryable();
            return result;
        }

        public Patient GetPatientById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id", "patient Id is empty!");
            }

            var patient = (Patient)_patient.FindOneAs(typeof(Patient), Query.EQ("_id", id));
            patient.Name = EncryptAlgo.Decrypt(patient.Name, password);
            patient.Address = EncryptAlgo.Decrypt(patient.Address, password);
            patient.CNIC = EncryptAlgo.Decrypt(patient.CNIC, password);
            patient.ContactNo = EncryptAlgo.Decrypt(patient.ContactNo, password);
            patient.DOB = EncryptAlgo.Decrypt(patient.DOB, password);
            patient.Gender = EncryptAlgo.Decrypt(patient.Gender, password);
            patient.FamilyNumber = EncryptAlgo.Decrypt(patient.FamilyNumber, password);

            return patient;
        }
        public Patient GetPatientByCNIC(string CNIC)
        {
            if (string.IsNullOrEmpty(CNIC))
            {
                throw new ArgumentNullException("id", "patient CNIC is empty!");
            }

            var patient = (Patient)_patient.FindOneAs(typeof(Patient), Query.EQ("CNIC", CNIC));
            patient.Name = EncryptAlgo.Decrypt(patient.Name, password);
            patient.Address = EncryptAlgo.Decrypt(patient.Address, password);
            patient.CNIC = EncryptAlgo.Decrypt(patient.CNIC, password);
            patient.ContactNo = EncryptAlgo.Decrypt(patient.ContactNo, password);
            patient.DOB = EncryptAlgo.Decrypt(patient.DOB, password);
            patient.Gender = EncryptAlgo.Decrypt(patient.Gender, password);
            patient.FamilyNumber = EncryptAlgo.Decrypt(patient.FamilyNumber, password);

            return patient;
        }
        public Patient GetPatientByContactNo(string ContactNo)
        {
            if (string.IsNullOrEmpty(ContactNo))
            {
                throw new ArgumentNullException("id", "patient ContactNo is empty!");
            }

            var patient = (Patient)_patient.FindOneAs(typeof(Patient), Query.EQ("ContactNo", ContactNo));
            patient.Name = EncryptAlgo.Decrypt(patient.Name, password);
            patient.Address = EncryptAlgo.Decrypt(patient.Address, password);
            patient.CNIC = EncryptAlgo.Decrypt(patient.CNIC, password);
            patient.ContactNo = EncryptAlgo.Decrypt(patient.ContactNo, password);
            patient.DOB = EncryptAlgo.Decrypt(patient.DOB, password);
            patient.Gender = EncryptAlgo.Decrypt(patient.Gender, password);
            patient.FamilyNumber = EncryptAlgo.Decrypt(patient.FamilyNumber, password);

            return patient;
        }

        public Patient Add(Patient patient)
        {
            if (string.IsNullOrEmpty(patient.Id))
            {
                patient.Id = Guid.NewGuid().ToString();
            }
            patient.Name = EncryptAlgo.Encrypt(patient.Name,password);
            patient.Address = EncryptAlgo.Encrypt(patient.Address, password);
            patient.CNIC = EncryptAlgo.Encrypt(patient.CNIC, password);
            patient.ContactNo = EncryptAlgo.Encrypt(patient.ContactNo, password);
            patient.DOB = EncryptAlgo.Encrypt(patient.DOB, password);
            patient.Gender = EncryptAlgo.Encrypt(patient.Gender, password);
            patient.FamilyNumber = EncryptAlgo.Encrypt(patient.FamilyNumber, password);
            _patient.Save(patient);
            return patient;
        }
        public void AddMedicalHistory(PatientHistory _patienthistory,Patient patient)
        {
            if (string.IsNullOrEmpty(_patienthistory.Id))
            {
                _patienthistory.Id = Guid.NewGuid().ToString();
            }
            var pbyid = (Patient)_patient.FindOneAs(typeof(Patient),Query.EQ("_id", patient.Id));
            pbyid.ph.Add(_patienthistory);
            _patient.Save(pbyid);
        }
        public void encryptdiagnosis(Diagnosis diagnosis)
        {

        }
    }
}