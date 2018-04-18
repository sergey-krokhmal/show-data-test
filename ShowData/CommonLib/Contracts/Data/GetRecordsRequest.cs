using System;
using System.Globalization;
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
        /// Filter UTC date from
        /// </summary>
        [DataMember(Name = "from", Order = 1)]
        public string DateFrom { get; set;}

        /// <summary>
        /// Filter UTC date to
        /// </summary>
        [DataMember(Name = "to", Order = 2)]
        public string DateTo { get; set; }

        /// <summary>
        /// Parse request's string fields to DateTime
        /// </summary>
        /// <returns>DateTime range (from/to)</returns>
        public (DateTime dateFrom, DateTime dateTo) ToDateTimes()
        {
            if (!DateTime.TryParse(DateFrom, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out var dateFrom))
            {
                throw new FormatException("Wrong 'from' date format (needs dd.mm.yyyy)");
            }
            if (!DateTime.TryParse(DateTo, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out var dateto))
            {
                throw new FormatException("Wrong 'to' date format (needs dd.mm.yyyy)");
            }
            return (dateFrom, dateto);
        }
    }
}
