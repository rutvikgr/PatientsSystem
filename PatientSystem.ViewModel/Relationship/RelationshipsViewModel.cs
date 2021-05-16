using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientSystem.ViewModel.Relationship
{
    /// <summary>
    /// Relationship view model
    /// </summary>
    public class RelationshipsViewModel
    {
        /// <summary>
        /// Relationship id
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Relationship id")]
        public int RelationshipId { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Is inactive?
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Is InActive")]
        public bool InActive { get; set; }
    }
}
