using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientSystem.DB.Entities
{
    /// <summary>
    /// NOKDetails table entity
    /// </summary>
    public class NOKDetails : BaseEntity
    {
        /// <summary>
        /// NOK Id (Primary key)
        /// </summary>
        [Required]
        [Key]
        public long NOKId { get; set; }

        /// <summary>
        /// Patient Id (Foreign key)
        /// </summary>
        [Required]
        public long PatientId { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        [Required]
        [StringLength(30)]
        public string NOKName { get; set; }

        /// <summary>
        /// Relationship Id
        /// </summary>
        [Required]
        public int RelationshipId { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [Required]
        [MaxLength(13)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Mobile number
        /// </summary>
        [Required]
        [MaxLength(13)]
        public string MobileNumber { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [Required]
        [StringLength(30)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Is primary contact of patient?
        /// </summary>
        [Required]
        public bool PrimaryContact { get; set; }

        /// <summary>
        /// Navigation property for PatientId foreign key
        /// </summary>
        [ForeignKey("PatientId")]
        public virtual Patients Patient { get; set; }

        /// <summary>
        /// Navigation property for RelationshipId foreign key
        /// </summary>
        [ForeignKey("RelationshipId")]
        public virtual RelationShips Relationship { get; set; }
    }
}
