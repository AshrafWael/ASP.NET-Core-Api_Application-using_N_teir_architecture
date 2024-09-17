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
    public class DoctorRepo : IDoctorRepo
    {
        private readonly HospitalSystemContext _hospitalSystemContext;

        public DoctorRepo(HospitalSystemContext hospitalSystemContext) 
        {
            _hospitalSystemContext = hospitalSystemContext;
        }
        public IEnumerable<Doctor> GetAll()
        {
            return _hospitalSystemContext.Doctors.AsNoTracking().ToList();
        }
        public Doctor GetById(int id)
        {
            return _hospitalSystemContext.Doctors.Find(id);
        }
        public void Add(Doctor doctor)
        {
            _hospitalSystemContext.Add(doctor);
        }
        public void Delete(Doctor doctor)
        {
            _hospitalSystemContext.Remove(doctor);
        }
        public void Update(Doctor doctor)
        {
            
        }
        public void SaveChanges()
        {
            _hospitalSystemContext.SaveChanges();
        }
    }
}
