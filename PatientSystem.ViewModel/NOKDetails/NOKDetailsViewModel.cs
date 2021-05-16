using PatientSystem.ViewModel.Patient;
using PatientSystem.ViewModel.Relationship;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PatientSystem.ViewModel.NOKDetails
{
    /// <summary>
    /// NOK Details view model
    /// </summary>
    public class NOKDetailsViewModel
    {
        /// <summary>
        /// NOK Id
        /// </summary>
        public long NOKId { get; set; }

        /// <summary>
        /// Patient Id (Foreign key)
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Patient")]
        public long PatientId { get; set; }

        /// <summary>
        /// Patients list
        /// </summary>
        public SelectList PatientsList { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "NOK Name")]
        public string NOKName { get; set; }

        /// <summary>
        /// Relationship Id
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Relationship")]
        public int RelationshipId { get; set; }

        /// <summary>
        /// Relationship list
        /// </summary>
        public SelectList RelationshipList { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Mobile number
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Mobile number")]
        public string MobileNumber { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Is primary contact of patient?
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Primary contact")]
        public bool PrimaryContact { get; set; }

        /// <summary>
        /// Navigation property for PatientId foreign key
        /// </summary>
        public virtual PatientViewModel Patient { get; set; }

        /// <summary>
        /// Navigation property for RelationshipId foreign key
        /// </summary>
        public virtual RelationshipsViewModel Relationship { get; set; }
    }
}
