using HospitalManagmentSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.DAL.Reposatories
{
    public interface IDoctorRepo
    {
        IEnumerable<Doctor> GetAll();
        Doctor GetById(int id);
        void Add(Doctor doctor);
        void Delete(Doctor doctor);
        void Update(Doctor doctor);
        void SaveChanges();


    }
}
