using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientSystem.DB.Entities
{
    /// <summary>
    /// PropertyItems table entity
    /// </summary>
    public class PropertyItems : BaseEntity
    {
        /// <summary>
        /// Property Id (Primary key)
        /// </summary>
        [Required]
        [Key]
        public long PropertyId { get; set; }

        /// <summary>
        /// Patient Id (Foreign key)
        /// </summary>
        [Required]
        public long PatientId { get; set; }

        /// <summary>
        /// Item name
        /// </summary>
        [Required]
        [StringLength(100)]
        public string ItemName { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [StringLength(100)]
        public string Description { get; set; }

        /// <summary>
        /// Qty
        /// </summary>
        [Required]
        public int Qty { get; set; }

        /// <summary>
        /// Collected by
        /// </summary>
        [StringLength(100)]
        public string CollectedBy { get; set; }

        /// <summary>
        /// Collected on date and time
        /// </summary>
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? CollectedOn { get; set; }

        /// <summary>
        /// Navigation property for PatientId foreign key
        /// </summary>
        [ForeignKey("PatientId")]
        public virtual Patients Patient { get; set; }
    }
}
