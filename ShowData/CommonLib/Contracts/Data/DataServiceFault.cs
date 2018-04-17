using System.Runtime.Serialization;

namespace CommonLib.Contracts.Data
{
    /// <summary>
    /// Data service contract for fault
    /// </summary>
    [DataContract]
    public class DataServiceFault
    {
        /// <summary>
        /// Error message
        /// </summary>
        [DataMember(Name = "err", Order = 1)]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Error code
        /// </summary>
        [DataMember(Name = "c", Order = 2)]
        public int Code { get; set; }

        public DataServiceFault() { }

        public DataServiceFault(string error, int code)
        {
            ErrorMessage = error;
            Code = code;
        }
    }
}
