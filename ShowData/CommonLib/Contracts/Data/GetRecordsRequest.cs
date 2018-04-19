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
        // Here better use C# 7 ValueTuples, but my OS...(
        public (DateTime, DateTime) ToDateTimes()
        {
            string dateTimeFormat = DataRecord.DateFormat;
            DateTime dateFrom;
            if (!DateTime.TryParseExact(DateFrom, dateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out dateFrom))
            {
                throw new FormatException($"Wrong 'from' date format (needs {dateTimeFormat})");
            }
            DateTime dateTo;
            if (!DateTime.TryParseExact(DateTo, dateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out dateTo))
            {
                throw new FormatException($"Wrong 'to' date format (needs {dateTimeFormat})");
            }
            return (dateFrom.ToUniversalTime(), dateTo.ToUniversalTime());
        }
    }
}
