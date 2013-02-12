using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Extensionista
{
    /// <summary>
    /// Extensions for validating objects using System.ComponentModel.DataAnnotations.
    /// </summary>
    public static class ValidationExtensions
    {
        /// <summary>
        /// Checks to see if a given object passes validation.
        /// </summary>
        /// <param name="obj">The object to validate.</param>
        /// <param name="validateAllProperties">Optional. Indicates whether to check 
        /// all properties on the object (defaults to true).</param>
        /// <returns>True if the object passes validation; false if it does not.</returns>
        public static bool TryValidate(this object obj, bool validateAllProperties = true)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            Validator.TryValidateObject(obj, new ValidationContext(obj, null, null), results, validateAllProperties);
            return results.Count <= 0;
        }
        /// <summary>
        /// Validates a given object and returns any associated validation errors.
        /// </summary>
        /// <param name="obj">The object to validate.</param>
        /// <param name="validateAllProperties">Optional. Indicates whether to check 
        /// all properties on the object (defaults to true).</param>
        /// <returns>An empty list of ValidationResult objects if no errors are found;
        /// a populated list if errors are found.</returns>
        public static List<ValidationResult> Validate(this object obj, bool validateAllProperties = true)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            Validator.TryValidateObject(obj, new ValidationContext(obj, null, null), results, validateAllProperties);
            return results;
        }
    }
}
