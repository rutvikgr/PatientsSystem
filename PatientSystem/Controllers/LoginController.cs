using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientSystem.Controllers
{
    /// <summary>
    /// Fake login controller
    /// </summary>
    public class LoginController : Controller
    {
        /// <summary>
        /// Index action
        /// </summary>
        /// <returns>Login view</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}