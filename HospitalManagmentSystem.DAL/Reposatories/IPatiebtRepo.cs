using HospitalManagmentSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.DAL.Reposatories
{
    public interface IPatiebtRepo
    {
        IEnumerable<Patient> GetAll();
        Patient GetById(int id);
        void Add(Patient patient);
        void Delete(Patient patient);
        void Update(Patient patient);
        void SaveChanges();
    }
}
