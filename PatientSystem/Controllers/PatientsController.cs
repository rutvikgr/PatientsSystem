using PatientSystem.Repository.Interface;
using PatientSystem.ViewModel.NOKDetails;
using PatientSystem.ViewModel.Patient;
using PatientSystem.ViewModel.PropertyItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientSystem.Controllers
{
    /// <summary>
    /// Patients controller
    /// </summary>
    public class PatientsController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IRelationshipRepository _relationshipRepository;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="patientRepository">Patient repository with DB logic</param>
        /// <param name="relationshipRepository">Relationship repository with DB logic</param>
        public PatientsController(IPatientRepository patientRepository, IRelationshipRepository relationshipRepository)
        {
            this._patientRepository = patientRepository;
            this._relationshipRepository = relationshipRepository;
        }

        /// <summary>
        /// List action
        /// </summary>
        /// <returns>List view</returns>
        public ActionResult List()
        {
            var viewModel = new PatientViewModel();
            return View(viewModel);
        }

        /// <summary>
        /// Load datatable for patients
        /// </summary>
        /// <param name="param">Datatable.net parameters</param>
        /// <returns>Datatable list</returns>
        [HttpGet]
        public ActionResult LoadPatients(PatientListJqueryDatatableParam param)
        {
            List<Tuple<int, string>> sort = new List<Tuple<int, string>>();
            if (!string.IsNullOrEmpty(param.sSortDir_0)) sort.Add(new Tuple<int, string>(param.iSortCol_0, param.sSortDir_0));
            if (!string.IsNullOrEmpty(param.sSortDir_1)) sort.Add(new Tuple<int, string>(param.iSortCol_1, param.sSortDir_1));
            if (!string.IsNullOrEmpty(param.sSortDir_2)) sort.Add(new Tuple<int, string>(param.iSortCol_2, param.sSortDir_2));

            var patients = _patientRepository.GetPatients();

            if (param.Filter == 1)
            {
                patients = patients.Where(x => x.ConsentGiven);
            }
            else if (param.Filter == 2)
            {
                patients = patients.Where(x => x.ReleaseDate == null);
            }

            if (sort.Any())
            {
                var sortItem = sort.First();
                var sortColumn = sortItem.Item1;
                var sortDirection = sortItem.Item2;
                switch (sortColumn)
                {
                    case 0:
                        patients = sortDirection == "asc" ? patients.OrderBy(c => c.PatientId) : patients.OrderByDescending(c => c.PatientId);
                        break;
                    case 1:
                        patients = sortDirection == "asc" ? patients.OrderBy(c => c.FirstName).ThenBy(c => c.SurName) : patients.OrderByDescending(c => c.FirstName).ThenBy(c => c.SurName);
                        break;
                    case 2:
                        patients = sortDirection == "asc" ? patients.OrderBy(c => c.Referred) : patients.OrderByDescending(c => c.Referred);
                        break;
                    case 3:
                        patients = sortDirection == "asc" ? patients.OrderBy(c => c.ConsentGiven) : patients.OrderByDescending(c => c.ConsentGiven);
                        break;
                }
            }

            var totalPatients = patients.ToList().Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();
            var totalCount = totalPatients.Count();
            return Json(new
            {
                param.sEcho,
                iTotalRecords = totalCount,
                iTotalDisplayRecords = totalCount,
                aaData = totalPatients
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get patient record for edit
        /// </summary>
        /// <param name="id">Patient id</param>
        /// <returns>View</returns>
        public ActionResult Edit(long? id)
        {
            if (!id.HasValue)
            {
                TempData["errorMessage"] = "Please select patient to see patient profile.";
                return RedirectToAction("List");
            }

            var viewModel = _patientRepository.GetPatient(id.Value);

            if (viewModel != null)
            {
                var relationships = _relationshipRepository.GetRelationships();
                if (relationships != null)
                {
                    viewModel.PropertyPatientNOKDetail = new ViewModel.NOKDetails.NOKDetailsViewModel
                    {
                        RelationshipList = new SelectList(relationships.Select(x => new SelectListItem { Text = x.Description, Value = x.RelationshipId.ToString() }), "Value", "Text")
                    };
                }

                return View(viewModel);
            }
            else
            {
                TempData["errorMessage"] = "No record found.";
                return RedirectToAction("List");
            }
        }

        /// <summary>
        /// Delete patient record
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>View</returns>
        public ActionResult Delete(long id)
        {
            if (id <= 0)
            {
                TempData["errorMessage"] = "Invalid request.";
                return RedirectToAction("List");
            }

            var result = _patientRepository.DeletePatient(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Edit patient record
        /// </summary>
        /// <param name="viewModel">Patient record view model</param>
        /// <returns>View</returns>
        public ActionResult EditPatient(PatientViewModel viewModel)
        {
            if (viewModel == null || string.IsNullOrEmpty(viewModel.PatientId.ToString()))
            {
                TempData["errorMessage"] = "Invalid request.";
                return RedirectToAction("List");
            }

            if (viewModel.PatientId == 0)
            {
                var result = _patientRepository.CreatePatient(viewModel);
                TempData["successMessage"] = result ? "Patient created successfully." : "Something went wrong! Please check your inputs.";

                return RedirectToAction("List");
            }
            else
            {
                var result = _patientRepository.EditPatient(viewModel);
                TempData["successMessage"] = result ? "Profile updated successfully." : "Something went wrong! Please check your inputs.";

                return RedirectToAction("Edit", new { id = viewModel.PatientId });
            }
        }

        /// <summary>
        /// Search action
        /// </summary>
        /// <returns>Search view</returns>
        public ActionResult Search()
        {
            var viewModel = new SearchPatientViewModel();
            return View(viewModel);
        }

        /// <summary>
        /// Search patient by id
        /// </summary>
        /// <param name="model">Search view model</param>
        /// <returns>View</returns>
        public ActionResult SearchPatientById(SearchPatientViewModel model)
        {
            if (!model.PatientId.HasValue)
            {
                TempData["errorMessage"] = "No record found.";
                return RedirectToAction("Search");
            }

            var viewModel = _patientRepository.GetPatient(model.PatientId.Value);

            if (viewModel != null)
            {
                var relationships = _relationshipRepository.GetRelationships();
                if (relationships != null)
                {
                    viewModel.PropertyPatientNOKDetail = new ViewModel.NOKDetails.NOKDetailsViewModel
                    {
                        RelationshipList = new SelectList(relationships.Select(x => new SelectListItem { Text = x.Description, Value = x.RelationshipId.ToString() }), "Value", "Text")
                    };
                }

                return View("Edit", viewModel);
            }
            else
            {
                TempData["errorMessage"] = "No record found.";
                return RedirectToAction("Search");
            }
        }
    }
}