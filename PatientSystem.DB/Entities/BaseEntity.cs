using System;

namespace PatientSystem.DB.Entities
{
    /// <summary>
    /// Base entity
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Created date for record
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Modified date for record
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}
