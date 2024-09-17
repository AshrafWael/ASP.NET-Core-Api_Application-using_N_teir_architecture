using HospitalManagmentSystem.BLL.Dtos;
using HospitalManagmentSystem.DAL.Reposatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.BLL.Manager
{
    public class PatientManager : IPatientManager
    {
        private readonly IPatiebtRepo _patiebtRepo;

        public PatientManager(IPatiebtRepo patiebtRepo)
        {
            _patiebtRepo = patiebtRepo;
        }

        public void Add(PatientAddDto patientAddDto)
        {

        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PatientReadDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public PatientReadDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(PatientUpdateDto patientUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
