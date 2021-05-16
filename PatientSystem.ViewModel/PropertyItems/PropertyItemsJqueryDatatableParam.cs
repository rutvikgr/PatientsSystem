using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientSystem.ViewModel.PropertyItems
{
    /// <summary>
    /// Datatable param for property items
    /// </summary>
    public class PropertyItemsJqueryDatatableParam : IJqueryDatatableParam
    {
        /// <summary>
        /// Patient id
        /// </summary>
        public long PatientId { get; set; }
    }
}
