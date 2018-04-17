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
        /// <param name="request">Request with date range</param>
        /// <returns>List of data records</returns>
        [OperationContract]
        List<DataRecord> GetDataRecords(DataRecordsRequest request);
    }
}
