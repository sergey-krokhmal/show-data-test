using CommonLib.Contracts.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace CommonLib.Contracts.Service
{
    /// <summary>
    /// Data service contract
    /// </summary>
    [ServiceContract]
    public interface IDataService
    {
        /// <summary>
        /// Get data records
        /// </summary>
        /// <returns>List of data records</returns>
        [OperationContract]
        [WebGet(UriTemplate = "GetDataRecords?from={from}&to={to}")]
        Response<List<DataRecord>> GetDataRecords(string from, string to);
    }
}
