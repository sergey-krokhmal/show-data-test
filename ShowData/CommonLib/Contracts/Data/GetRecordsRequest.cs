using System;
using System.Runtime.Serialization;

namespace CommonLib.Contracts.Data
{
    /// <summary>
    /// Data contract represents GetDataRecords request
    /// </summary>
    [DataContract]
    public class DataRecordsRequest
    {
        /// <summary>
        /// Filter date from
        /// </summary>
        public DateTime DateFrom { get; set;}

        /// <summary>
        /// Filter date to
        /// </summary>
        public DateTime DateTo { get; set; }
    }
}
