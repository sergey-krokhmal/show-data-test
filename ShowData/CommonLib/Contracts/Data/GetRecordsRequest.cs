﻿using System;
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
        [DataMember(Name = "from", Order = 1)]
        public DateTime DateFrom { get; set;}

        /// <summary>
        /// Filter date to
        /// </summary>
        [DataMember(Name = "to", Order = 2)]
        public DateTime DateTo { get; set; }
    }
}
