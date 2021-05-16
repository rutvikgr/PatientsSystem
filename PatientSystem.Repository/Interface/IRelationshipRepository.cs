using PatientSystem.ViewModel.Relationship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientSystem.Repository.Interface
{
    /// <summary>
    /// Interface for RelationshipRepository
    /// </summary>
    public interface IRelationshipRepository
    {
        /// <summary>
        /// Get all relationships
        /// </summary>
        /// <returns>View model</returns>
        IEnumerable<RelationshipsViewModel> GetRelationships();

        /// <summary>
        /// Add relationship
        /// </summary>
        /// <param name="viewModel">View model</param>
        /// <returns>result</returns>
        bool AddRelationship(RelationshipsViewModel viewModel);

        /// <summary>
        /// Delete relationship
        /// </summary>
        /// <param name="id">Relationship id</param>
        /// <returns>Result</returns>
        bool DeleteRelationship(int id);
    }
}
