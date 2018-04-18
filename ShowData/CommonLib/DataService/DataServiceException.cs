using System;

namespace CommonLib.DataService
{
    /// <summary>
    /// Data service exception
    /// </summary>
    [Serializable]
    public class DataServiceException : Exception
    {
        public int Code { get; private set; }

        public DataServiceException(int code = default(int)) : base()
        {
            Code = code;
        }

        public DataServiceException(string message, int code = default(int)) : base(message)
        {
            Code = code;
        }

        public DataServiceException(string message, Exception ex, int code = default(int)) : base(message, ex)
        {
            Code = code;
        }
    }
}
