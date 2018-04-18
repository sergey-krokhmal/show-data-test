﻿using System;
using System.Globalization;
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
        /// Data record format
        /// </summary>
        [IgnoreDataMember]
        public static string DateFormat { get { return "dd.MM.yyyy"; } }

        /// <summary>
        /// Record's id
        /// </summary>
        [DataMember(Name = "id", Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Record's date
        /// </summary>
        [IgnoreDataMember]
        public DateTime Date { get; set; }

        /// <summary>
        /// Record's formated date
        /// </summary>
        [DataMember(Name = "dt", Order = 2)]
        public string FormatedDate
        {
            get
            {
                return Date.ToString(DateFormat);
            }
            set
            {
                DateTime date;
                DateTime.TryParseExact(value, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out date);
                Date = date.ToUniversalTime();
            }
        }

        /// <summary>
        /// Record's text
        /// </summary>
        [DataMember(Name = "txt", Order = 3)]
        public string Text { get; set; }
    }
}
