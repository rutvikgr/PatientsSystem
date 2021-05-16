using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientSystem.ViewModel
{
    /// <summary>
    /// Jquery datatable parameter model
    /// </summary>
    public class IJqueryDatatableParam
    {
        /// <summary>
        /// Echo
        /// </summary>
        public string sEcho { get; set; }

        /// <summary>
        /// Search text
        /// </summary>
        public string sSearch { get; set; }

        /// <summary>
        /// Display length
        /// </summary>
        public int iDisplayLength { get; set; }

        /// <summary>
        /// Display start
        /// </summary>
        public int iDisplayStart { get; set; }

        /// <summary>
        /// Columns
        /// </summary>
        public int iColumns { get; set; }

        /// <summary>
        /// Sort column index
        /// </summary>
        public int iSortCol_0 { get; set; }

        /// <summary>
        /// Sort direction
        /// </summary>
        public string sSortDir_0 { get; set; }

        /// <summary>
        /// Sort column index
        /// </summary>
        public int iSortCol_1 { get; set; }

        /// <summary>
        /// Sort direction
        /// </summary>
        public string sSortDir_1 { get; set; }

        /// <summary>
        /// Sort column index
        /// </summary>
        public int iSortCol_2 { get; set; }

        /// <summary>
        /// Sort direction
        /// </summary>
        public string sSortDir_2 { get; set; }

        /// <summary>
        /// Sorting column
        /// </summary>
        public int iSortingCols { get; set; }

        /// <summary>
        /// Sort columns
        /// </summary>
        public string sColumns { get; set; }
    }
}
