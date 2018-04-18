using CommonLib.Contracts.Data;
using CommonLib.Contracts.Service;
using CommonLib.DataAccess;
using CommonLib.DataService;
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
        private IDataAccessible dao;

        public DataService()
        {
            dao = StaticDataDao.Get;
        }

        /// <summary>
        /// Get data records
        /// </summary>
        /// <param name="request">Request with date range</param>
        /// <returns>List of data records</returns>
        public Response<List<DataRecord>> GetDataRecords(DataRecordsRequest request)
        {
            try
            {
                // If request empty
                if (request == null)
                {
                    throw new DataServiceException("Empty request params", (int)DataServiceResultCode.EmptyParams);
                }
                // If request params empty
                if (string.IsNullOrWhiteSpace(request.DateFrom) || string.IsNullOrWhiteSpace(request.DateTo))
                {
                    throw new DataServiceException("One of request's date param is empty", (int)DataServiceResultCode.EmptyParams);
                }
                // Get DateTimes range
                var dateRange = request.ToDateTimes();

                // Get data records from data access object
                var dataRecords = dao.GetDataRecords(dateRange.Item1, dateRange.Item2);

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
