using HospitalManagmentSystem.BLL.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Web.Http.ModelBinding;

namespace HospitalManagmentSystem.API.Filters
{
    public class ValidateSalaryAttribute:ActionFilterAttribute
    {
        public ValidateSalaryAttribute()
        {
            
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //context have object
            //convert from DoctorDto Object to DoctorupdateDto model
            DoctorUpdateDto DoctorDto = context.ActionArguments["DoctorDto"] as DoctorUpdateDto;
            if (!(DoctorDto.Salary >= 1000 && DoctorDto.Salary >= 3000))
            {
                context.ModelState.AddModelError("Salary", "out of range");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }


    }
}
