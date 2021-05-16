using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientSystem.ViewModel.Patient
{
    /// <summary>
    /// Datatable param for patients
    /// </summary>
    public class PatientListJqueryDatatableParam : IJqueryDatatableParam
    {
        /// <summary>
        /// Filter
        /// </summary>
        public int Filter { get; set; }
    }
}
