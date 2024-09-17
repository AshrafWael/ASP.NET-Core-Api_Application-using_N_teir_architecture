using HospitalManagmentSystem.DAL.Data.DbHelper;
using HospitalManagmentSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.DAL.Reposatories
{
    public class PatientRepo : IPatiebtRepo
    {
        private readonly HospitalSystemContext _hospitalSystemContext;

        public PatientRepo(HospitalSystemContext  hospitalSystemContext) 
        {
            _hospitalSystemContext = hospitalSystemContext;
        }
        public void Add(Patient patient)
        {
            _hospitalSystemContext.Add(patient);   
        }

        public void Delete(Patient patient)
        {
            _hospitalSystemContext.Remove(patient);
        }

        public IEnumerable<Patient> GetAll()
        {
              return _hospitalSystemContext.Patients.AsNoTracking().ToList();
        }

        public Patient GetById(int id)
        {
            return _hospitalSystemContext.Patients.Find(id);
        }

        public void Update(Patient patient)
        {
          
        }
        public void SaveChanges()
        { 
           _hospitalSystemContext.SaveChanges();
        }
    }
}
