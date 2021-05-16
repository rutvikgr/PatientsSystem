using PatientSystem.Repository.Interface;
using PatientSystem.ViewModel;
using PatientSystem.ViewModel.PropertyItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientSystem.Controllers
{
    /// <summary>
    /// Proeprty items controller
    /// </summary>
    public class PropertyItemsController : Controller
    {
        private readonly IPropertyItemsRepository _propertyItemsRepository;
        private readonly IPatientRepository _patientRepository;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="patientRepository">Patient repository with DB logic</param>
        /// <param name="propertyItemsRepository">Property items repository with DB logic</param>
        public PropertyItemsController(IPatientRepository patientRepository, IPropertyItemsRepository propertyItemsRepository)
        {
            this._patientRepository = patientRepository;
            this._propertyItemsRepository = propertyItemsRepository;
        }

        /// <summary>
        /// List action
        /// </summary>
        /// <returns>List view</returns>
        public ActionResult List()
        {
            var viewModel = new PropertyItemsViewModel();
            var patients = _patientRepository.GetPatients();
            if (patients != null)
            {
                viewModel.PatientsList = new SelectList(patients.Select(x => new SelectListItem { Text = "Id: " + x.PatientId + ", Name: " + x.FirstName + " " + x.SurName, Value = x.PatientId.ToString() }), "Value", "Text");
            }

            return View(viewModel);
        }

        /// <summary>
        /// Load datatable for property items
        /// </summary>
        /// <param name="param">Datatable.net parameters</param>
        /// <returns>Datatable list</returns>
        [HttpGet]
        public ActionResult LoadPropertyItems(IJqueryDatatableParam param)
        {
            return LoadDatatable(param);
        }

        /// <summary>
        /// Load datatable for property items
        /// </summary>
        /// <param name="param">Datatable.net parameters</param>
        /// <returns>Datatable list</returns>
        [HttpGet]
        public ActionResult LoadPropertyItemsForPatient(PropertyItemsJqueryDatatableParam param)
        {
            return LoadDatatable(param, param.PatientId);
        }

        /// <summary>
        /// Load property item
        /// </summary>
        /// <param name="propertyItemId">Property item id</param>
        /// <returns>Json result</returns>
        [HttpGet]
        public JsonResult LoadPropertyItem(long propertyItemId)
        {
            var property = _propertyItemsRepository.GetPropertyItem(propertyItemId);
            return Json(property, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Create update property item
        /// </summary>
        /// <param name="viewModel">Property item view model</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult CreateUpdatePropertyItem(PropertyItemsViewModel viewModel)
        {
            if (viewModel == null || string.IsNullOrEmpty(viewModel.PatientId.ToString()) || viewModel.PatientId <= 0)
            {
                TempData["errorMessage"] = "Invalid request.";
                return RedirectToAction("Edit", "Patients", new { id = viewModel.PatientId });
            }

            var result = viewModel.PropertyId > 0 ? _propertyItemsRepository.EditPropertyItem(viewModel) : _propertyItemsRepository.CreatePropertyItem(viewModel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Delete property item
        /// </summary>
        /// <param name="id">Proeprty item id</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult DeletePropertyItem(long id)
        {
            if (id <= 0)
            {
                TempData["errorMessage"] = "Invalid request.";
                return RedirectToAction("List");
            }

            var result = _propertyItemsRepository.DeletePropertyItem(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private ActionResult LoadDatatable(IJqueryDatatableParam param, long? Id = null)
        {
            List<Tuple<int, string>> sort = new List<Tuple<int, string>>();
            if (!string.IsNullOrEmpty(param.sSortDir_0)) sort.Add(new Tuple<int, string>(param.iSortCol_0, param.sSortDir_0));
            if (!string.IsNullOrEmpty(param.sSortDir_1)) sort.Add(new Tuple<int, string>(param.iSortCol_1, param.sSortDir_1));
            if (!string.IsNullOrEmpty(param.sSortDir_2)) sort.Add(new Tuple<int, string>(param.iSortCol_2, param.sSortDir_2));

            var items = Id.HasValue ? _propertyItemsRepository.GetPropertyItemsForPatient(Id.Value) : _propertyItemsRepository.GetPropertyItems();
            if (sort.Any())
            {
                var sortItem = sort.First();
                var sortColumn = sortItem.Item1;
                var sortDirection = sortItem.Item2;
                switch (sortColumn)
                {
                    case 0:
                        items = sortDirection == "asc" ? items.OrderBy(c => c.PropertyId) : items.OrderByDescending(c => c.PropertyId);
                        break;
                    case 1:
                        items = sortDirection == "asc" ? items.OrderBy(c => c.ItemName) : items.OrderByDescending(c => c.ItemName);
                        break;
                    case 2:
                        items = sortDirection == "asc" ? items.OrderBy(c => c.Description) : items.OrderByDescending(c => c.Description);
                        break;
                    case 3:
                        items = sortDirection == "asc" ? items.OrderBy(c => c.PatientId) : items.OrderByDescending(c => c.PatientId);
                        break;
                    case 4:
                        items = sortDirection == "asc" ? items.OrderBy(c => c.Patient.FirstName).ThenBy(c => c.Patient.SurName) :
                                                          items.OrderByDescending(c => c.Patient.FirstName).ThenBy(c => c.Patient.SurName);
                        break;
                    case 5:
                        items = sortDirection == "asc" ? items.OrderBy(c => c.Qty) : items.OrderByDescending(c => c.Qty);
                        break;
                }
            }

            var totalDetails = items.ToList().Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();
            var totalCount = totalDetails.Count();
            return Json(new
            {
                param.sEcho,
                iTotalRecords = totalCount,
                iTotalDisplayRecords = totalCount,
                aaData = totalDetails
            }, JsonRequestBehavior.AllowGet);
        }
    }
}