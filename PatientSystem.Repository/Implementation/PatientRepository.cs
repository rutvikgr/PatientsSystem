using AutoMapper;
using PatientSystem.DB.Context;
using PatientSystem.DB.Entities;
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
    /// PatientRepository
    /// </summary>
    public class PatientRepository : IPatientRepository
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="mapper">Mapper</param>
        /// <param name="context">Database context</param>
        public PatientRepository(IMapper mapper, DatabaseContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }

        /// <summary>
        /// Get patients
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PatientViewModel> GetPatients()
        {
            var patients = _context.Patients.ToList();
            var response = _mapper.Map<List<PatientViewModel>>(patients);
            return response;
        }

        /// <summary>
        /// Get patient by id
        /// </summary>
        /// <param name="patientId">Patient id</param>
        /// <returns>View model</returns>
        public PatientViewModel GetPatient(long patientId)
        {
            var response = new PatientViewModel();
            var patient = _context.Patients.FirstOrDefault(x => x.PatientId == patientId);
            response = _mapper.Map<PatientViewModel>(patient);
            return response;
        }

        /// <summary>
        /// Create patient
        /// </summary>
        /// <param name="viewModel">View model</param>
        /// <returns>Result</returns>
        public bool CreatePatient(PatientViewModel viewModel)
        {
            var result = false;
            try
            {
                var entity = _mapper.Map<Patients>(viewModel);

                if (entity == null)
                    return result;

                _context.Patients.Add(entity);
                _context.SaveChanges();

                if (entity.PatientId > 0)
                    return true;
            }
            catch
            {
                return result;
            }

            return result;
        }

        /// <summary>
        /// Edit patient
        /// </summary>
        /// <param name="viewModel">View model</param>
        /// <returns>Result</returns>
        public bool EditPatient(PatientViewModel viewModel)
        {
            var result = false;
            try
            {
                var entity = _context.Patients.FirstOrDefault(x => x.PatientId == viewModel.PatientId);

                if (entity == null)
                    return result;

                _mapper.Map(viewModel, entity);
                _context.SaveChanges();

                if (entity.PatientId > 0)
                    return true;
            }
            catch
            {
                return result;
            }

            return result;
        }

        /// <summary>
        /// Delete patient
        /// </summary>
        /// <returns>Result</returns>
        public bool DeletePatient(long patientId)
        {
            try
            {
                var entity = _context.Patients.FirstOrDefault(x => x.PatientId == patientId);

                if (entity == null)
                    return false;

                _context.Patients.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
