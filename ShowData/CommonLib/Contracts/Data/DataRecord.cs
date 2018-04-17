using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Contracts.Data
{
    /// <summary>
    /// Data contract represents some data record
    /// </summary>
    [DataContract]
    public class DataRecord
    {
        /// <summary>
        /// Record's id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Record's date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Record's text
        /// </summary>
        public string Text { get; set; }
    }
}
