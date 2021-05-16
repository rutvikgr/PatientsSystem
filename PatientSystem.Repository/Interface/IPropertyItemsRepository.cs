using PatientSystem.ViewModel.PropertyItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientSystem.Repository.Interface
{
    /// <summary>
    /// Interface for PropertyItemsRepository
    /// </summary>
    public interface IPropertyItemsRepository
    {
        /// <summary>
        /// Get property items
        /// </summary>
        /// <returns>View model</returns>
        IEnumerable<PropertyItemsViewModel> GetPropertyItems();

        /// <summary>
        /// Get property items by patient id
        /// </summary>
        /// <param name="patientId">Patient id</param>
        /// <returns>View model</returns>
        List<PropertyItemsViewModel> GetPropertyItemsForPatient(long patientId);

        /// <summary>
        /// property item by id
        /// </summary>
        /// <param name="propertyItemId">Proeprty item id</param>
        /// <returns>View model</returns>
        PropertyItemsViewModel GetPropertyItem(long propertyItemId);

        /// <summary>
        /// Create property item
        /// </summary>
        /// <param name="viewModel">View model</param>
        /// <returns>Result</returns>
        bool CreatePropertyItem(PropertyItemsViewModel viewModel);

        /// <summary>
        /// Edit property item
        /// </summary>
        /// <param name="viewModel">View model</param>
        /// <returns>Result</returns>
        bool EditPropertyItem(PropertyItemsViewModel viewModel);

        /// <summary>
        /// Delete property item
        /// </summary>
        /// <returns>Result</returns>
        bool DeletePropertyItem(long propertyItemId);
    }
}
