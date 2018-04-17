using CommonLib.Contracts.Data;
using CommonLib.Contracts.Service;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace DataService
{
    /// <summary>
    /// Data service
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple, AddressFilterMode = AddressFilterMode.Any)]
    public class DataService : IDataService
    {
        /// <summary>
        /// Get data records
        /// </summary>
        /// <param name="request">Request with date range</param>
        /// <returns>List of data records</returns>
        public Response<List<DataRecord>> GetDataRecords(DataRecordsRequest request)
        {
            return null;
        }
    }
}
