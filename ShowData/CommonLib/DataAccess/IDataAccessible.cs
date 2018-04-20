using CommonLib.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.DataAccess
{
    /// <summary>
    /// Interface of data access
    /// </summary>
    public interface IDataAccessible
    {
        IList<DataRecord> GetDataRecords(DateTime dateFrom, DateTime dateTo);
    }
}
