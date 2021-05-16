using PatientSystem.ViewModel.NOKDetails;
using PatientSystem.ViewModel.PropertyItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientSystem.ViewModel.Patient
{
    /// <summary>
    /// Patient view model
    /// </summary>
    public class PatientViewModel
    {
        /// <summary>
        /// Patient Id (Primary key)
        /// </summary>
        public long PatientId { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Surname
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Surname")]
        public string SurName { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Address line 1
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Address line 1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Address line 2
        /// </summary>
        [Display(Name = "Address line 2")]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "City")]
        public string City { get; set; }

        /// <summary>
        /// Postal
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Postal")]
        public string Postal { get; set; }

        /// <summary>
        /// County
        /// </summary>
        [Display(Name = "County")]
        public string County { get; set; }

        /// <summary>
        /// Referred
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Referred")]
        public bool Referred { get; set; }

        /// <summary>
        /// Consent given
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Consent given")]
        public bool ConsentGiven { get; set; }

        /// <summary>
        /// Release date
        /// </summary>
        [Display(Name = "Released date")]
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Navigation property for NOKDetails and Patient
        /// </summary>
        public ICollection<NOKDetailsViewModel> PropertyPatientNOKDetails { get; set; }

        /// <summary>
        /// Navigation property for PropertyItems and Patient
        /// </summary>
        public ICollection<PropertyItemsViewModel> PropertyItemsDetails { get; set; }

        /// <summary>
        /// Patient's nok detail view model
        /// </summary>
        public NOKDetailsViewModel PropertyPatientNOKDetail { get; set; }

        /// <summary>
        /// Patient's property item view model
        /// </summary>
        public PropertyItemsViewModel PropertyItemsDetail { get; set; }

    }
}
