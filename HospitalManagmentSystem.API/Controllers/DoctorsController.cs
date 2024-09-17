using HospitalManagmentSystem.API.Filters;
using HospitalManagmentSystem.BLL.Dtos;
using HospitalManagmentSystem.BLL.Manager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorManager _doctorManager;
        public DoctorsController(IDoctorManager doctorManager) 
        {
          _doctorManager = doctorManager;
        }

       // [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<DoctorReadDto>> GetAll() 
        {
            return Ok(_doctorManager.GetAll());
        }
        [HttpGet]
        [Route("Id")]
        public ActionResult GetById(int id) 
        {
            return Ok(_doctorManager.GetById(id));
        }
        [HttpPost]
        public ActionResult Add(DoctorAddDto DoctorDto)
        {
            _doctorManager.Add(DoctorDto);
               return NoContent();
        }
        [HttpPut]
        [Route("Id")]
        [ValidateSalary] //Action Filter
        public ActionResult Update(int Id,DoctorUpdateDto DoctorDto)
        {
            //======>onActionExcuting
            if (Id != DoctorDto.Id)
            {
                return BadRequest();
            }
            else 
            {
                _doctorManager.Update(DoctorDto);
                return NoContent();
            }
            //======>onActionExcuted
        }
        [HttpDelete]
        [Route("Id")]
        public ActionResult Delete(int id) 
        {
             _doctorManager.Delete(id);
             return NoContent();
        }

    }
}
