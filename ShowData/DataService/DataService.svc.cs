using CommonLib.Contracts.Data;
using CommonLib.Contracts.Service;
using CommonLib.DataAccess;
using CommonLib.DataService;
using CommonLib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Dao instance
        /// </summary>
        private IDataAccessible dao;

        /// <summary>
        /// Construct service
        /// </summary>
        public DataService(IDataAccessible dao)
        {
            // Get dao instance
            this.dao = dao;
        }

        /// <summary>
        /// Get data records
        /// </summary>
        /// <returns>List of data records</returns>
        public Response<List<DataRecord>> GetDataRecords(string from, string to)
        {
            try
            {
                // If request params empty
                if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
                {
                    throw new DataServiceException("One of request's date param is empty", (int)DataServiceResultCode.EmptyParams);
                }

                // Get DateTimes range
                var dateFrom = from.ToUtcDateTime();
                var dateTo = to.ToUtcDateTime();

                // Get data records from data access object
                var dataRecords = dao.GetDataRecords(dateFrom, dateTo);

                // Return dataRecords
                return new Response<List<DataRecord>>(dataRecords.ToList());
            }
            catch (FormatException fex)
            {
                return new Response<List<DataRecord>>(fex.Message, (int)DataServiceResultCode.FormatError);
            }
            catch (DataServiceException dse)
            {
                return new Response<List<DataRecord>>(dse.Message, dse.Code);
            }
            catch (Exception ex)
            {
                return new Response<List<DataRecord>>( $"Server error: '{ex.Message}'", (int)DataServiceResultCode.SystemError);
            }
        }
    }
}
