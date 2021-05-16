using AutoMapper;
using PatientSystem.DB.Context;
using PatientSystem.ViewModel.Patient;
using PatientSystem.ViewModel.Relationship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientSystem.Repository.Interface
{
    /// <summary>
    /// Interface for PatientRepository
    /// </summary>
    public interface IPatientRepository
    {
        /// <summary>
        /// Get patients
        /// </summary>
        /// <returns></returns>
        IEnumerable<PatientViewModel> GetPatients();

        /// <summary>
        /// Get patient by id
        /// </summary>
        /// <param name="patientId">Patient id</param>
        /// <returns>View model</returns>
        PatientViewModel GetPatient(long patientId);

        /// <summary>
        /// Create patient
        /// </summary>
        /// <param name="viewModel">View model</param>
        /// <returns>Result</returns>
        bool CreatePatient(PatientViewModel viewModel);

        /// <summary>
        /// Edit patient
        /// </summary>
        /// <param name="viewModel">View model</param>
        /// <returns>Result</returns>
        bool EditPatient(PatientViewModel viewModel);

        /// <summary>
        /// Delete patient
        /// </summary>
        /// <returns>Result</returns>
        bool DeletePatient(long patientId);
    }
}
