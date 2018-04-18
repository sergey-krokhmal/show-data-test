using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Contracts.Data
{
    /// <summary>
    /// Service operations response
    /// </summary>
    /// <typeparam name="T">Type of response data</typeparam>
    [DataContract]
    public class Response<T>
    {
        /// <summary>
        /// Success operation
        /// </summary>
        [DataMember(Name = "sc", Order = 1)]
        public bool Success { get; set; }

        /// <summary>
        /// Result code
        /// </summary>
        [DataMember(Name = "cd", Order = 2)]
        public int Code { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        [DataMember(Name = "er", Order = 3)]
        public string Error { get; set; }

        /// <summary>
        /// Result value
        /// </summary>
        [DataMember(Name = "val", Order = 4)]
        public T Value { get; set; }

        public Response()
        {
            Success = true;
            Error = string.Empty;
        }

        public Response(T val)
        {
            Value = val;
            Success = true;
            Error = string.Empty;
        }

        public Response(string error, int code)
        {
            Code = code;
            Error = error;
            Success = false;
            Value = default(T);
        }
    }
}
