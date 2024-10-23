using AutoMapper;
using HospitalManagmentSystem.BLL.Dtos;
using HospitalManagmentSystem.DAL.Data.Models;
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
        private readonly IMapper _mapper;

        public PatientManager(IPatiebtRepo patiebtRepo,IMapper mapper )
        {
            _patiebtRepo = patiebtRepo;
           _mapper = mapper;
        }

        public void Add(PatientAddDto patientAddDto)
        {
            _patiebtRepo.Add(_mapper.Map<Patient>(patientAddDto));
            _patiebtRepo.SaveChanges();
        }

        public void Delete(int Id)
        {
            var Patient = _patiebtRepo.GetById(Id);
            _patiebtRepo.Delete(Patient);
            _patiebtRepo.SaveChanges();
        }

        public IEnumerable<PatientReadDto> GetAll()
        {
            return _mapper.Map<List<PatientReadDto>>(_patiebtRepo.GetAll());
           
        }

        public PatientReadDto GetById(int id)
        {
            return _mapper.Map<PatientReadDto>(_patiebtRepo.GetById(id));
        }

        public void SaveChanges()
        {
            _patiebtRepo.SaveChanges();
        }

        public void Update(PatientUpdateDto patientUpdateDto)
        {
            var patientModel = _patiebtRepo.GetById(patientUpdateDto.Id);
            _mapper.Map<PatientUpdateDto>(patientModel);
            _patiebtRepo.SaveChanges();
        }
    }
}
