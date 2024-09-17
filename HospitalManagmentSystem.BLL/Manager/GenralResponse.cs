using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.BLL.Manager
{
    public class GenralResponse
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
