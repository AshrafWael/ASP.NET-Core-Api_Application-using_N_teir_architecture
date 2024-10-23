using HospitalManagmentSystem.BLL.Dtos;
using HospitalManagmentSystem.BLL.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly IIssueManager _issueManager;

        public IssuesController(IIssueManager issueManager)
        {
            _issueManager = issueManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<IssueReadDto>> GetAll()
        {
            return Ok(_issueManager.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var issue = _issueManager.GetById(id);
            if (issue == null)
            {
                return NotFound();
            }
            return Ok(issue);
        }

        [HttpPost]
        public ActionResult Add(IssueReadDto issueDto)
        {
            _issueManager.Add(issueDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, IssueUpdateDto issueDto)
        {
            if (id != issueDto.Id)
            {
                return BadRequest();
            }

            _issueManager.Update(issueDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var issue = _issueManager.GetById(id);
            if (issue == null)
            {
                return NotFound();
            }

            _issueManager.Delete(id);
            return NoContent();
        }


    }
}
