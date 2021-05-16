using PatientSystem.ViewModel.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PatientSystem.ViewModel.PropertyItems
{
    /// <summary>
    /// Property items view model
    /// </summary>
    public class PropertyItemsViewModel
    {
        /// <summary>
        /// Property Id (Primary key)
        /// </summary>
        public long PropertyId { get; set; }

        /// <summary>
        /// Patient Id (Foreign key)
        /// </summary>

        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Patient")]
        public long PatientId { get; set; }

        /// <summary>
        /// Patient list
        /// </summary>
        public SelectList PatientsList { get; set; }

        /// <summary>
        /// Item name
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Item name")]
        public string ItemName { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Display(Name = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Qty
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Qty")]
        public int Qty { get; set; }

        /// <summary>
        /// Collected by
        /// </summary>
        [Display(Name = "Collected by")]
        public string CollectedBy { get; set; }

        /// <summary>
        /// Collected on date and time
        /// </summary>
        [Display(Name = "Collected on")]
        public DateTime? CollectedOn { get; set; }

        /// <summary>
        /// Navigation property for PatientId foreign key
        /// </summary>
        public virtual PatientViewModel Patient { get; set; }
    }
}
