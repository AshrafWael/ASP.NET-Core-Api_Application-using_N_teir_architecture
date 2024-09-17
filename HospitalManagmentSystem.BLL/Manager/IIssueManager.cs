using HospitalManagmentSystem.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.BLL.Manager
{
    public interface IIssueManager
    {
        IEnumerable<IssueReadDto> GetAll();
        IssueReadDto GetById(int id);
        void Add(IssueReadDto issueReadDto);
        void Update(IssueUpdateDto issueUpdateDto );
        void Delete(int Id);
        void SaveChanges();


    }
}
