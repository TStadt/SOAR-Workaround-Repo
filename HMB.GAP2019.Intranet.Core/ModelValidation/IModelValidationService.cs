using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HMB.GAP2019.Intranet.Core.ModelValidation
{
   public interface IModelValidationService
   {
      bool TryValidateModel(object model, out IList<ValidationResult> validationErrors);
   }
}