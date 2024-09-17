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
    public class DoctorManager : IDoctorManager
    {
        private readonly IDoctorRepo _doctorRepo;
        private readonly IMemoryCache _memoryCache;
        private const string CashKey = "Doctor_Cashkey";
        public DoctorManager(IDoctorRepo doctorRepo,IMemoryCache memoryCache)
        {
           _doctorRepo = doctorRepo;
            _memoryCache = memoryCache;
        }
        public IEnumerable<DoctorReadDto> GetAll()
        {
            if (!_memoryCache.TryGetValue($"{CashKey}", out IEnumerable<DoctorReadDto> ListdoctorDto))
            { 
            var DoctorModelList = _doctorRepo.GetAll();
            var DoctorDtoList = DoctorModelList.Select(ModelList => new DoctorReadDto() 
            {
                Name = ModelList.Name,
                Age = ModelList.Age,
                PerformanceRate = ModelList.PerformanceRate
            });
                var option = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
                };
                _memoryCache.Set($"{CashKey}", DoctorDtoList, option);
                return DoctorDtoList;
            }
            return ListdoctorDto;
        }

        public DoctorReadDto GetById(int id)
        {
            if (!_memoryCache.TryGetValue($"{CashKey}_{id}", out DoctorReadDto doctorDto))
            {
                var DoctorModel = _doctorRepo.GetById(id);
                var DoctorDto = new DoctorReadDto()
                {
                    Name = DoctorModel.Name,
                    Age = DoctorModel.Age,
                    PerformanceRate = DoctorModel.PerformanceRate
                };

                var option = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
                };
                _memoryCache.Set($"{CashKey}_{id}", DoctorDto,option);
                return DoctorDto;
            }
            else 
            {
                return doctorDto;
            }

        }
        public void Add(DoctorAddDto doctorAddDto)
        {
            //convert from dto to model and send to repo
            var DoctorModel = new Doctor
            {
                Name= doctorAddDto.Name,
                Age= doctorAddDto.Age,
                Salary = doctorAddDto.Salary,
            };
            _doctorRepo.Add(DoctorModel);
            _doctorRepo.SaveChanges();
        }

        public void Update(DoctorUpdateDto doctorUpdateDto)
        {
            var DoctorModel = _doctorRepo.GetById(doctorUpdateDto.Id);
            DoctorModel.Age = doctorUpdateDto.Age;
            DoctorModel.Salary = doctorUpdateDto.Salary;
            DoctorModel.Age= doctorUpdateDto.Age;
            DoctorModel.PerformanceRate = doctorUpdateDto.PerformanceRate;
            _doctorRepo.Update(DoctorModel);
            _memoryCache.Remove($"{CashKey}_{doctorUpdateDto.Id}");
            //_memoryCache.Remove($"{CashKey}");nessesry object on list remove all list

            _doctorRepo.SaveChanges();
        }

        public void Delete(int Id)
        {
            var DoctorModel = _doctorRepo.GetById(Id);
            _doctorRepo.Delete(DoctorModel);
            _memoryCache.Remove($"{CashKey}_{Id}");
            //_memoryCache.Remove($"{CashKey}");
            _doctorRepo.SaveChanges();
        }
        public void SaveChanges()
        {
            _doctorRepo.SaveChanges();
        }
    }
}
