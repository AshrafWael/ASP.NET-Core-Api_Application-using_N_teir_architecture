using HospitalManagmentSystem.DAL.Data.DbHelper;
using HospitalManagmentSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.DAL.Reposatories
{
    public class IssueRepo : IIssueRepo
    {
        private readonly HospitalSystemContext _hospitalSystemContext;

        public IssueRepo(HospitalSystemContext hospitalSystemContext)
        {
            _hospitalSystemContext = hospitalSystemContext;
        }
        public void Add(Issue issue)
        {
            _hospitalSystemContext.Issues.Add(issue);
        }

        public void Delete(Issue issue)
        {
            _hospitalSystemContext.Remove(issue);
        }

        public IEnumerable<Issue> GetAll()
        {
            return _hospitalSystemContext.Issues.AsNoTracking().ToList();
        }

        public Issue GetById(int id)
        {
            return _hospitalSystemContext.Issues.Find(id);
        }


        public void Update(Issue issue)
        {
            
        }
        public void SaveChanges()
        {
            _hospitalSystemContext.SaveChanges();
        }
    }
}
