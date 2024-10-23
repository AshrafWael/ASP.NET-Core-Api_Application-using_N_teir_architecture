using HospitalManagmentSystem.BLL.Dtos;
using HospitalManagmentSystem.BLL.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {


        private readonly IPatientManager _patientManager;

        public PatientsController(IPatientManager patientManager)
        {
            _patientManager = patientManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PatientReadDto>> GetAll()
        {
            return Ok(_patientManager.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var patient = _patientManager.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public ActionResult Add(PatientAddDto patientDto)
        {
            _patientManager.Add(patientDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, PatientUpdateDto patientDto)
        {
            if (id != patientDto.Id)
            {
                return BadRequest();
            }

            _patientManager.Update(patientDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var patient = _patientManager.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }

            _patientManager.Delete(id);
            return NoContent();
        }


    }
}
