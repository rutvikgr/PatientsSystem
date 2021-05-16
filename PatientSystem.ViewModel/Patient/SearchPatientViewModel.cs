using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientSystem.ViewModel.Patient
{
    /// <summary>
    /// Search patient view model
    /// </summary>
    public class SearchPatientViewModel
    {
        /// <summary>
        /// Patient Id (Primary key)
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Patient id")]
        public long? PatientId { get; set; }
    }
}
