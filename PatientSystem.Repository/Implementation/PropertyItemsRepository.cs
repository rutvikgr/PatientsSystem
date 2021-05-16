using AutoMapper;
using PatientSystem.DB.Context;
using PatientSystem.DB.Entities;
using PatientSystem.Repository.Interface;
using PatientSystem.ViewModel.PropertyItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientSystem.Repository.Implementation
{
    /// <summary>
    /// PropertyItemsRepository
    /// </summary>
    public class PropertyItemsRepository : IPropertyItemsRepository
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="mapper">Mapper</param>
        /// <param name="context">Database context</param>
        public PropertyItemsRepository(IMapper mapper, DatabaseContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }

        /// <summary>
        /// Get property items
        /// </summary>
        /// <returns>View model</returns>
        public IEnumerable<PropertyItemsViewModel> GetPropertyItems()
        {
            var PropertyItems = _context.PropertyItems.ToList();
            var response = _mapper.Map<List<PropertyItemsViewModel>>(PropertyItems);
            return response;
        }

        /// <summary>
        /// Get property items by patient id
        /// </summary>
        /// <param name="patientId">Patient id</param>
        /// <returns>View model</returns>
        public List<PropertyItemsViewModel> GetPropertyItemsForPatient(long patientId)
        {
            var PropertyItems = _context.PropertyItems.Where(x => x.PatientId == patientId).ToList();
            var response = _mapper.Map<List<PropertyItemsViewModel>>(PropertyItems);
            return response;
        }

        /// <summary>
        /// property item by id
        /// </summary>
        /// <param name="propertyItemId">Proeprty item id</param>
        /// <returns>View model</returns>
        public PropertyItemsViewModel GetPropertyItem(long propertyItemId)
        {
            var response = new PropertyItemsViewModel();
            var PropertyItems = _context.PropertyItems.FirstOrDefault(x => x.PropertyId == propertyItemId);
            response = _mapper.Map<PropertyItemsViewModel>(PropertyItems);
            return response;
        }

        /// <summary>
        /// Create property item
        /// </summary>
        /// <param name="viewModel">View model</param>
        /// <returns>Result</returns>
        public bool CreatePropertyItem(PropertyItemsViewModel viewModel)
        {
            var result = false;
            try
            {
                var entity = _mapper.Map<PropertyItems>(viewModel);

                if (entity == null)
                    return result;

                _context.PropertyItems.Add(entity);
                _context.SaveChanges();

                if (entity.PropertyId > 0)
                    return true;
            }
            catch
            {
                return result;
            }

            return result;
        }

        /// <summary>
        /// Edit property item
        /// </summary>
        /// <param name="viewModel">View model</param>
        /// <returns>Result</returns>
        public bool EditPropertyItem(PropertyItemsViewModel viewModel)
        {
            var result = false;
            try
            {
                var entity = _context.PropertyItems.FirstOrDefault(x => x.PropertyId == viewModel.PropertyId);

                if (entity == null)
                    return result;

                entity = _mapper.Map(viewModel, entity);
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
        /// Delete property item
        /// </summary>
        /// <returns>Result</returns>
        public bool DeletePropertyItem(long propertyItemId)
        {
            try
            {
                var entity = _context.PropertyItems.FirstOrDefault(x => x.PropertyId == propertyItemId);

                if (entity == null)
                    return false;

                _context.PropertyItems.Remove(entity);
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
