using PatientSystem.Repository.Interface;
using PatientSystem.ViewModel;
using PatientSystem.ViewModel.NOKDetails;
using PatientSystem.ViewModel.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientSystem.Controllers
{
    /// <summary>
    /// NOKDetails controller
    /// </summary>
    public class NOKDetailsController : Controller
    {
        private readonly INOKDetailsRepository _NOKDetailsRepository;
        private readonly IRelationshipRepository _relationshipRepository;
        private readonly IPatientRepository _patientRepository;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="patientRepository">Patient repository with DB logic</param>
        /// <param name="nokDetailsRepository">NOKDetail repository with DB logic</param>
        /// <param name="relationshipRepository">Relationship repository with DB logic</param>
        public NOKDetailsController(IPatientRepository patientRepository, INOKDetailsRepository nokDetailsRepository, IRelationshipRepository relationshipRepository)
        {
            this._patientRepository = patientRepository;
            this._NOKDetailsRepository = nokDetailsRepository;
            this._relationshipRepository = relationshipRepository;
        }

        /// <summary>
        /// List action
        /// </summary>
        /// <returns>List view</returns>
        public ActionResult List()
        {
            var viewModel = new NOKDetailsViewModel();
            var relationships = _relationshipRepository.GetRelationships();
            if (relationships != null)
            {
                viewModel.RelationshipList = new SelectList(relationships.Select(x => new SelectListItem { Text = x.Description, Value = x.RelationshipId.ToString() }), "Value", "Text");
            }

            var patients = _patientRepository.GetPatients();
            if (patients != null)
            {
                viewModel.PatientsList = new SelectList(patients.Select(x => new SelectListItem { Text = "Id: " + x.PatientId + ", Name: " + x.FirstName + " " + x.SurName, Value = x.PatientId.ToString() }), "Value", "Text");
            }

            return View(viewModel);
        }

        /// <summary>
        /// Load datatable for NOK Details
        /// </summary>
        /// <param name="param">Datatable.net parameters</param>
        /// <returns>Datatable list</returns>
        [HttpGet]
        public ActionResult LoadNOKDetails(IJqueryDatatableParam param)
        {
            return GetDataTable(param);
        }

        /// <summary>
        /// Load datatable for NOK Details
        /// </summary>
        /// <param name="param">Datatable.net parameters</param>
        /// <returns>Datatable list</returns>
        [HttpGet]
        public ActionResult LoadNOKDetailForPatient(NOKDetailsJqueryDatatableParam param)
        {
            return GetDataTable(param, param.PatientId);
        }

        /// <summary>
        /// Load one NOK detail
        /// </summary>
        /// <param name="nokId">NOK Id</param>
        /// <returns>Json result</returns>
        [HttpGet]
        public JsonResult LoadNOK(long nokId)
        {
            var nok = _NOKDetailsRepository.GetNOKDetail(nokId);
            return Json(nok, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Create or update NOK detail record
        /// </summary>
        /// <param name="viewModel">NOK detail view model</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult CreateUpdateNOK(NOKDetailsViewModel viewModel)
        {
            if (viewModel == null || string.IsNullOrEmpty(viewModel.PatientId.ToString()) || viewModel.PatientId <= 0)
            {
                TempData["errorMessage"] = "Invalid request.";
                return RedirectToAction("Edit", "Patients", new { id = viewModel.PatientId });
            }

            var result = viewModel.NOKId > 0 ? _NOKDetailsRepository.EditNOKDetail(viewModel) : _NOKDetailsRepository.CreateNOKDetail(viewModel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Delete NOK detail record
        /// </summary>
        /// <param name="id">NOK Id</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult DeleteNOK(long id)
        {
            if (id <= 0)
            {
                TempData["errorMessage"] = "Invalid request.";
                return RedirectToAction("List");
            }

            var result = _NOKDetailsRepository.DeleteNOKDetail(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private ActionResult GetDataTable(IJqueryDatatableParam param, long? PatientId = null)
        {
            List<Tuple<int, string>> sort = new List<Tuple<int, string>>();
            if (!string.IsNullOrEmpty(param.sSortDir_0)) sort.Add(new Tuple<int, string>(param.iSortCol_0, param.sSortDir_0));
            if (!string.IsNullOrEmpty(param.sSortDir_1)) sort.Add(new Tuple<int, string>(param.iSortCol_1, param.sSortDir_1));
            if (!string.IsNullOrEmpty(param.sSortDir_2)) sort.Add(new Tuple<int, string>(param.iSortCol_2, param.sSortDir_2));

            var details = PatientId.HasValue ? _NOKDetailsRepository.GetNOKDetailsForPatient(PatientId.Value) : _NOKDetailsRepository.GetNOKDetails();
            if (sort.Any())
            {
                var sortItem = sort.First();
                var sortColumn = sortItem.Item1;
                var sortDirection = sortItem.Item2;
                switch (sortColumn)
                {
                    case 0:
                        details = sortDirection == "asc" ? details.OrderBy(c => c.NOKId) : details.OrderByDescending(c => c.NOKId);
                        break;
                    case 1:
                        details = sortDirection == "asc" ? details.OrderBy(c => c.NOKName) : details.OrderByDescending(c => c.NOKName);
                        break;
                    case 2:
                        details = sortDirection == "asc" ? details.OrderBy(c => c.PatientId) : details.OrderByDescending(c => c.PatientId);
                        break;
                    case 3:
                        details = sortDirection == "asc" ? details.OrderBy(c => c.Patient.FirstName).ThenBy(c => c.Patient.SurName) :
                                                          details.OrderByDescending(c => c.Patient.FirstName).ThenBy(c => c.Patient.SurName);
                        break;
                    case 4:
                        details = sortDirection == "asc" ? details.OrderBy(c => c.Relationship.Description) : details.OrderByDescending(c => c.Relationship.Description);
                        break;
                    case 5:
                        details = sortDirection == "asc" ? details.OrderBy(c => c.PhoneNumber) : details.OrderByDescending(c => c.PhoneNumber);
                        break;
                    case 6:
                        details = sortDirection == "asc" ? details.OrderBy(c => c.EmailAddress) : details.OrderByDescending(c => c.EmailAddress);
                        break;
                }
            }

            var totalDetails = details.ToList().Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();
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