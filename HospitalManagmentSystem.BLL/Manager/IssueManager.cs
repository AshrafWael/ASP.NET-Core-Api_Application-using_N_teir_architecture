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
    public class IssueManager : IIssueManager
    {
        private readonly IIssueRepo _issueRepo;
        private readonly IMapper _mapper;

        public IssueManager(IIssueRepo issueRepo,IMapper mapper)
        {
            _issueRepo = issueRepo;
         _mapper = mapper;
        }

        public IEnumerable<IssueReadDto> GetAll()
        {
      
           return _mapper.Map<List<IssueReadDto>>(_issueRepo.GetAll());

        }

        public IssueReadDto GetById(int id)
        {
            return _mapper.Map<IssueReadDto>(_issueRepo.GetById(id));
        }

        public void Add(IssueReadDto issueReadDto)
        {
            var isue = _mapper.Map<Issue>(issueReadDto);
            _issueRepo.Add(isue);
            _issueRepo.SaveChanges();
        }

        public void Update(IssueUpdateDto issueUpdateDto)
        {
            var IssueModel = _issueRepo.GetById(issueUpdateDto.Id);
            _mapper.Map<IssueUpdateDto>(IssueModel);
            _issueRepo.SaveChanges();
        }
        public void Delete(int Id)
        {
          var isue =_issueRepo.GetById(Id);
            _issueRepo.Delete(isue);
            _issueRepo.SaveChanges();
        }

        public void SaveChanges()
        {
            _issueRepo.SaveChanges();
        }
    }
}
