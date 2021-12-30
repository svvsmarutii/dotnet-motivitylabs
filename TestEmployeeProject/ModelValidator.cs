using EmployeeProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestEmployeeProject
{
  public  class ModelValidator
    {
        public IList<ValidationResult> Validations(object model)
        {           
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);
            Validator.TryValidateObject(model, validationContext, result);
            if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);
            return result;
        }  
    }
}
