using AutoMapper;
using PatientSystem.DB.Context;
using PatientSystem.DB.Entities;
using PatientSystem.ViewModel.Relationship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientSystem.Repository.Interface
{ 
    /// <summary>
    /// RelationshipRepository
    /// </summary>
    public class RelationshipRepository : IRelationshipRepository
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="mapper">Mapper</param>
        /// <param name="context">Database context</param>
        public RelationshipRepository(IMapper mapper, DatabaseContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }

        /// <summary>
        /// Get all relationships
        /// </summary>
        /// <returns>View model</returns>
        public IEnumerable<RelationshipsViewModel> GetRelationships()
        {
            var response = new List<RelationshipsViewModel>();
            var relationships = _context.RelationShips.Where(x => x.InActive == false).ToList();
            response = _mapper.Map<List<RelationshipsViewModel>>(relationships);
            return response;
        }

        /// <summary>
        /// Add relationship
        /// </summary>
        /// <param name="viewModel">View model</param>
        /// <returns>result</returns>
        public bool AddRelationship(RelationshipsViewModel viewModel)
        {
            var result = false;
            try
            {
                var entity = _mapper.Map<RelationShips>(viewModel);

                if (entity == null)
                    return result;

                _context.RelationShips.Add(entity);
                _context.SaveChanges();

                if (entity.RelationshipId > 0)
                    return true;
            }
            catch
            {
                return result;
            }

            return result;
        }

        /// <summary>
        /// Delete relationship
        /// </summary>
        /// <param name="id">Relationship id</param>
        /// <returns>Result</returns>
        public bool DeleteRelationship(int id)
        {
            try
            {
                var entity = _context.RelationShips.FirstOrDefault(x => x.RelationshipId == id);

                if (entity == null)
                    return false;

                entity.InActive = true;
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
