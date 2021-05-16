using PatientSystem.ViewModel.NOKDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientSystem.Repository.Interface
{
    /// <summary>
    /// Interface for NOKDetailsRepository
    /// </summary>
    public interface INOKDetailsRepository
    {
        /// <summary>
        /// Get NOK details
        /// </summary>
        /// <returns></returns>
        IEnumerable<NOKDetailsViewModel> GetNOKDetails();

        /// <summary>
        /// Get NOK details for patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        IEnumerable<NOKDetailsViewModel> GetNOKDetailsForPatient(long patientId);

        /// <summary>
        /// Get NOK details by Id
        /// </summary>
        /// <param name="nokId">NOK Id</param>
        /// <returns>View model</returns>
        NOKDetailsViewModel GetNOKDetail(long nokId);

        /// <summary>
        /// Create NOK detail
        /// </summary>
        /// <param name="viewModel">view model</param>
        /// <returns>result</returns>
        bool CreateNOKDetail(NOKDetailsViewModel viewModel);

        /// <summary>
        /// Edit NOK detail
        /// </summary>
        /// <param name="viewModel">view model</param>
        /// <returns>result</returns>
        bool EditNOKDetail(NOKDetailsViewModel viewModel);

        /// <summary>
        /// Delete NOK detail
        /// </summary>
        /// <param name="nokId">NOK Id</param>
        /// <returns>Result</returns>
        bool DeleteNOKDetail(long nokId);
    }
}
