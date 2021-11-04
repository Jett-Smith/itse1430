// ITSE 1420
// Movie Library

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class ObjectValidator
    {
        public IEnumerable<ValidationResult> TryValidate (IValidatableObject instance)
        {
            var errors = new List<ValidationResult>();
            var context = new ValidationContext(instance);

            Validator.TryValidateObject(instance, context, errors);

            return errors;
        }

        public bool TryValidate (IValidatableObject instacne, out string error )
        {
            var errors = TryValidate(instacne);
            error = errors.FirstOrDefault()?.ErrorMessage;

            return String.IsNullOrEmpty(error);
        }
    }
}
