using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientSystem.ViewModel.Patient
{
    /// <summary>
    /// Datatable parameter class for NOK details
    /// </summary>
    public class NOKDetailsJqueryDatatableParam : IJqueryDatatableParam
    {
        /// <summary>
        /// Patient Id
        /// </summary>
        public long PatientId { get; set; }
    }
}
