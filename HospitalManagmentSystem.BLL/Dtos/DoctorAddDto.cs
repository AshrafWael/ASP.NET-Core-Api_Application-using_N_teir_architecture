using HospitalManagmentSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.BLL.Dtos
{
    public class DoctorAddDto
    {
        //validation Filter
        [StringLength(10,MinimumLength =5,ErrorMessage ="name must be between  10 and 5")]
        public string Name { get; set; }
      //  [AgeValidate]
        public int Age { get; set; }
       // [Range(10000,30000,ErrorMessage ="{0} must be between {1} and {2}")]
        public int Salary { get; set; }

    }
}
