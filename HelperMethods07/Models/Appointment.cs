using HelperMethods07.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelperMethods07.Models
{
    public class Appointment : IValidatableObject // Self-Validating Model
    {
        [Required]      // Model Binder Validation, this does not stop the validation in controller, both work
        [StringLength(10, MinimumLength =3)] // Client side
        public string ClientName { get; set; }
        [DataType(DataType.Date)]
        //[Required(ErrorMessage = "Please enter a date")]
        //[FutureDateAttribute(ErrorMessage = "Please enter a date in the future. Message from custom validation attribute")]
        [Remote("ValidateDate", "Appointment")]
        public DateTime Date { get; set; }
        // [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms. Message from model binder validation attribute")]
        [MustBeTrue(ErrorMessage ="You must accept the terms. Message from custom validation attribute")]
        public bool TermsAccepted { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(ClientName))
            {
                errors.Add(new ValidationResult("Please enter your name"));
            }
            if (DateTime.Now > Date)
            {
                errors.Add(new ValidationResult("Please enter a date in the future"));
            }
            if (errors.Count == 0 && ClientName == "Joe" && Date.DayOfWeek == DayOfWeek.Monday)
            {
                errors.Add( new ValidationResult("Joe cannot book appointments on Mondays"));
            }
            if (!TermsAccepted)
            {
                errors.Add(new ValidationResult("You must accept the terms"));
            }
            return errors;
        }
    }
}