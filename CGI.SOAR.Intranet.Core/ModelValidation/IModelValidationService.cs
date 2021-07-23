using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CGI.SOAR.Intranet.Core.ModelValidation
{
   public interface IModelValidationService
   {
      bool TryValidateModel(object model, out IList<ValidationResult> validationErrors);
   }
}