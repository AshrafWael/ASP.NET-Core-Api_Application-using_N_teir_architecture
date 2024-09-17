using System.ComponentModel.DataAnnotations;

namespace HospitalManagmentSystem.API.Validation
{
    public class AgeValidateAttribute :ValidationAttribute
    {
        public AgeValidateAttribute() { }
        public override bool IsValid(object? value)
        {
            var age = Convert.ToInt32(value);
            return age > 0;
        }
    }
}
