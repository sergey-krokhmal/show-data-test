using System;
using System.Runtime.Serialization;

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
        [DataMember(Name = "id", Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Record's date
        /// </summary>
        [DataMember(Name = "dt", Order = 2)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Record's text
        /// </summary>
        [DataMember(Name = "txt", Order = 3)]
        public string Text { get; set; }
    }
}
