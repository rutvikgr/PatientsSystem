using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientSystem.DB.Entities
{
    /// <summary>
    /// Relationships table entity
    /// </summary>
    public class RelationShips : BaseEntity
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RelationShips()
        {
            this.NOKDetails = new HashSet<NOKDetails>();
        }

        /// <summary>
        /// Relation Id (Primary key)
        /// </summary>
        [Required]
        [Key]
        public int RelationshipId { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Required]
        [StringLength(30)]
        public string Description { get; set; }

        /// <summary>
        /// Is Inactive?
        /// </summary>
        [Required]
        public bool InActive { get; set; }

        /// <summary>
        /// Navigation property for NOKDetails and Relationship
        /// </summary>
        public virtual ICollection<NOKDetails> NOKDetails { get; set; }
    }
}
