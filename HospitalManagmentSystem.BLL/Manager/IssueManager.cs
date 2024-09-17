using HospitalManagmentSystem.BLL.Dtos;
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

        public IssueManager(IIssueRepo issueRepo)
        {
            _issueRepo = issueRepo;
        }

        public IEnumerable<IssueReadDto> GetAll()
        {
            throw new NotImplementedException();

        }

        public IssueReadDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(IssueReadDto issueReadDto)
        {
            throw new NotImplementedException();
        }

        public void Update(IssueUpdateDto issueUpdateDto)
        {
            throw new NotImplementedException();
        }
        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
