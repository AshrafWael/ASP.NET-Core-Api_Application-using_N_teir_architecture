using HospitalManagmentSystem.BLL.Dtos;
using HospitalManagmentSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.BLL.Manager
{
    public interface IDoctorManager
    {
        IEnumerable<DoctorReadDto> GetAll();
        DoctorReadDto GetById(int id);
        void Add(DoctorAddDto doctorAddDto);
        void Update(DoctorUpdateDto doctorUpdateDto);
        void Delete(int Id);
        void SaveChanges();
    }
}
