using HospitalManagmentSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.DAL.Reposatories
{
    public interface IIssueRepo
    {
        IEnumerable<Issue> GetAll();
        Issue GetById(int id);
        void Add(Issue issue);
        void Delete(Issue issue);
        void Update(Issue issue);
        void SaveChanges();
    }
}
