using PatientSystem.Repository.Interface;
using PatientSystem.ViewModel;
using PatientSystem.ViewModel.Relationship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientSystem.Controllers
{
    /// <summary>
    /// Relationship controller
    /// </summary>
    public class RelationshipsController : Controller
    {
        private readonly IRelationshipRepository _relationshipRepository;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="relationshipRepository">Relationship repository for DB logic</param>
        public RelationshipsController(IRelationshipRepository relationshipRepository)
        {
            this._relationshipRepository = relationshipRepository;
        }

        /// <summary>
        /// List action
        /// </summary>
        /// <returns>List view</returns>
        public ActionResult List()
        {
            return View();
        }

        /// <summary>
        /// Load datatable for relationships
        /// </summary>
        /// <param name="param">Datatable.net parameters</param>
        /// <returns>Datatable list</returns>

        [HttpGet]
        public ActionResult LoadRelationships(IJqueryDatatableParam param)
        {
            List<Tuple<int, string>> sort = new List<Tuple<int, string>>();
            if (!string.IsNullOrEmpty(param.sSortDir_0)) sort.Add(new Tuple<int, string>(param.iSortCol_0, param.sSortDir_0));
            if (!string.IsNullOrEmpty(param.sSortDir_1)) sort.Add(new Tuple<int, string>(param.iSortCol_1, param.sSortDir_1));
            if (!string.IsNullOrEmpty(param.sSortDir_2)) sort.Add(new Tuple<int, string>(param.iSortCol_2, param.sSortDir_2));

            var items = _relationshipRepository.GetRelationships();
            if (sort.Any())
            {
                var sortItem = sort.First();
                var sortColumn = sortItem.Item1;
                var sortDirection = sortItem.Item2;
                switch (sortColumn)
                {
                    case 0:
                        items = sortDirection == "asc" ? items.OrderBy(c => c.RelationshipId) : items.OrderByDescending(c => c.RelationshipId);
                        break;
                    case 1:
                        items = sortDirection == "asc" ? items.OrderBy(c => c.Description) : items.OrderByDescending(c => c.Description);
                        break;
                }
            }

            var totalRelationships = items.ToList().Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();
            var totalCount = totalRelationships.Count();
            return Json(new
            {
                param.sEcho,
                iTotalRecords = totalCount,
                iTotalDisplayRecords = totalCount,
                aaData = totalRelationships
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Create relationship
        /// </summary>
        /// <param name="viewModel">Relationship view model</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult CreateRelationship(RelationshipsViewModel viewModel)
        {
            if (viewModel == null)
            {
                TempData["errorMessage"] = "Invalid request.";
                return RedirectToAction("List");
            }

            _relationshipRepository.AddRelationship(viewModel);
            return RedirectToAction("List");
        }

        /// <summary>
        /// Delete relationship
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult DeleteRelationship(int id)
        {
            if (id <= 0)
            {
                TempData["errorMessage"] = "Invalid request.";
                return RedirectToAction("List");
            }

            var result = _relationshipRepository.DeleteRelationship(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}