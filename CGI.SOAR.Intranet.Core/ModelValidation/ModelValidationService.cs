using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CGI.SOAR.Intranet.Core.ModelValidation
{
   public class ModelValidationService : IModelValidationService
   {
      public bool TryValidateModel(object model, out IList<ValidationResult> validationErrors)
      {
         var context = new ValidationContext(model);
         validationErrors = new List<ValidationResult>();
         return Validator.TryValidateObject(model, context, validationErrors);
      }
   }
}
