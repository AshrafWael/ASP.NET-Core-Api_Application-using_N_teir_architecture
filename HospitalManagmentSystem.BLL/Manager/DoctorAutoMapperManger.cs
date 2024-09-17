using AutoMapper;
using HospitalManagmentSystem.BLL.Dtos;
using HospitalManagmentSystem.DAL.Data.Models;
using HospitalManagmentSystem.DAL.Reposatories;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.BLL.Manager
{
    public class DoctorAutoMapperManger :IDoctorManager
    {
        private readonly IDoctorRepo _doctorRepo;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private const string CashKey = "Doctor_Cashkey";

        public DoctorAutoMapperManger(IDoctorRepo doctorRepo ,IMapper mapper ,IMemoryCache memoryCache)
        {
            _doctorRepo = doctorRepo;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public IEnumerable<DoctorReadDto> GetAll()
        {
            //                    Distination           Sourse
            return _mapper.Map<List<DoctorReadDto>>(_doctorRepo.GetAll());
        }

        public DoctorReadDto GetById(int id)
        {
            if (!_memoryCache.TryGetValue($"{CashKey}_{id}", out DoctorReadDto doctorDto))
            {
              var DoctorDto= _mapper.Map<DoctorReadDto>(_doctorRepo.GetById(id));
                var option = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
                };
                _memoryCache.Set($"{CashKey}_{id}", DoctorDto, option);
                return DoctorDto;
            }
            return doctorDto;
         //   return _mapper.Map<DoctorReadDto>(_doctorRepo.GetById(id));
        }
        public void Add(DoctorAddDto doctorAddDto)
        {
            _doctorRepo.Add(_mapper.Map<Doctor>(doctorAddDto));
            _doctorRepo.SaveChanges();
        }

        public void Update(DoctorUpdateDto doctorUpdateDto) //sourse
        {
            var DoctorModel = _doctorRepo.GetById(doctorUpdateDto.Id); //ditenation
            _doctorRepo.Update(_mapper.Map<DoctorUpdateDto, Doctor>(doctorUpdateDto, DoctorModel));
            _doctorRepo.SaveChanges();
        }

        public void Delete(int Id)
        {
            _doctorRepo.Delete(_doctorRepo.GetById(Id));
            _doctorRepo.SaveChanges();
        }
        public void SaveChanges()
        {
            _doctorRepo.SaveChanges();
        }

    }
}
