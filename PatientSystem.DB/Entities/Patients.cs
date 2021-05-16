using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientSystem.DB.Entities
{
    /// <summary>
    /// Patients table entity
    /// </summary>
    public class Patients : BaseEntity
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Patients()
        {
            this.PatientNOKDetails = new HashSet<NOKDetails>();
            this.PatientPropertyItems = new HashSet<PropertyItems>();
        }

        /// <summary>
        /// Patient Id (Primary key)
        /// </summary>
        [Required]
        [Key]
        public long PatientId { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        /// <summary>
        /// Surname
        /// </summary>
        [Required]
        [StringLength(30)]
        public string SurName { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Address line 1
        /// </summary>
        [Required]
        [StringLength(100)]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Address line 2
        /// </summary>
        [StringLength(100)]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [Required]
        [StringLength(100)]
        public string City { get; set; }

        /// <summary>
        /// Postal
        /// </summary>
        [Required]
        [StringLength(10)]
        public string Postal { get; set; }

        /// <summary>
        /// County
        /// </summary>
        [StringLength(50)]
        public string County { get; set; }

        /// <summary>
        /// Referred
        /// </summary>
        [Required]
        public bool Referred { get; set; }

        /// <summary>
        /// Consent given
        /// </summary>
        [Required]
        public bool ConsentGiven { get; set; }

        /// <summary>
        /// Release date
        /// </summary>
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Navigation property for NOKDetails and Patient
        /// </summary>
        public virtual ICollection<NOKDetails> PatientNOKDetails { get; set; }

        /// <summary>
        /// Navigation property for PropertyItems and Patient
        /// </summary>
        public virtual ICollection<PropertyItems> PatientPropertyItems { get; set; }
    }
}
