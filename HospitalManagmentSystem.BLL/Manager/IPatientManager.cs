using HospitalManagmentSystem.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.BLL.Manager
{
    public interface IPatientManager
    {

        IEnumerable<PatientReadDto> GetAll();
        PatientReadDto GetById(int id);
        void Add(PatientAddDto patientAddDto);
        void Update(PatientUpdateDto patientUpdateDto);
        void Delete(int Id);
        void SaveChanges();
    }
}
