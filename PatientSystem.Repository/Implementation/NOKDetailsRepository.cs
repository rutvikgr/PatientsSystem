using AutoMapper;
using PatientSystem.DB.Context;
using PatientSystem.DB.Entities;
using PatientSystem.Repository.Interface;
using PatientSystem.ViewModel.NOKDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientSystem.Repository.Implementation
{
    /// <summary>
    /// NOKDetailsRepository: DB logic
    /// </summary>
    public class NOKDetailsRepository : INOKDetailsRepository
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="mapper">Mapper</param>
        /// <param name="context">Database context</param>
        public NOKDetailsRepository(IMapper mapper, DatabaseContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }
        
        /// <summary>
        /// Get NOK details
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NOKDetailsViewModel> GetNOKDetails()
        {
            var nokDetails = _context.NOKDetails.ToList();
            var response = _mapper.Map<List<NOKDetailsViewModel>>(nokDetails);
            return response;
        }

        /// <summary>
        /// Get NOK details for patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public IEnumerable<NOKDetailsViewModel> GetNOKDetailsForPatient(long patientId)
        {
            var nokDetails = _context.NOKDetails.Where(x => x.PatientId == patientId).ToList();
            var response = _mapper.Map<List<NOKDetailsViewModel>>(nokDetails);
            return response;
        }

        /// <summary>
        /// Get NOK details by Id
        /// </summary>
        /// <param name="nokId">NOK Id</param>
        /// <returns>View model</returns>
        public NOKDetailsViewModel GetNOKDetail(long nokId)
        {
            var response = new NOKDetailsViewModel();
            var nokDetails = _context.NOKDetails.FirstOrDefault(x => x.NOKId == nokId);
            response = _mapper.Map<NOKDetailsViewModel>(nokDetails);
            return response;
        }

        /// <summary>
        /// Create NOK detail
        /// </summary>
        /// <param name="viewModel">view model</param>
        /// <returns>result</returns>
        public bool CreateNOKDetail(NOKDetailsViewModel viewModel)
        {
            var result = false;
            try
            {
                var entity = _mapper.Map<NOKDetails>(viewModel);

                if (entity == null)
                    return result;

                _context.NOKDetails.Add(entity);
                _context.SaveChanges();

                if (entity.NOKId > 0)
                {
                    if (entity.PrimaryContact)
                    {
                        var entities = _context.NOKDetails.Where(x => x.PatientId == entity.PatientId && x.NOKId != entity.NOKId).ToList();
                        entities.ForEach(x =>
                        {
                            x.PrimaryContact = false;
                        });

                        _context.SaveChanges();
                    }
                    return true;
                }
            }
            catch
            {
                return result;
            }

            return result;
        }

        /// <summary>
        /// Edit NOK detail
        /// </summary>
        /// <param name="viewModel">view model</param>
        /// <returns>result</returns>
        public bool EditNOKDetail(NOKDetailsViewModel viewModel)
        {
            var result = false;
            try
            {
                var entity = _context.NOKDetails.FirstOrDefault(x => x.NOKId == viewModel.NOKId);

                if (entity == null)
                    return result;

                _mapper.Map(viewModel, entity);
                _context.SaveChanges();

                if (entity.PatientId > 0)
                {
                    if (entity.PrimaryContact)
                    {
                        var entities = _context.NOKDetails.Where(x => x.PatientId == entity.PatientId && x.NOKId != entity.NOKId).ToList();
                        entities.ForEach(x =>
                        {
                            x.PrimaryContact = false;
                        });

                        _context.SaveChanges();
                    }

                    return true;
                }
            }
            catch
            {
                return result;
            }

            return result;
        }

        /// <summary>
        /// Delete NOK detail
        /// </summary>
        /// <param name="nokId">NOK Id</param>
        /// <returns>Result</returns>
        public bool DeleteNOKDetail(long nokId)
        {
            try
            {
                var entity = _context.NOKDetails.FirstOrDefault(x => x.NOKId == nokId);

                if (entity == null)
                    return false;

                _context.NOKDetails.Remove(entity);
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
