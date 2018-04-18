using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLib.Contracts.Data;

namespace CommonLib.DataAccess
{
    /// <summary>
    /// Static data DAO
    /// </summary>
    public class StaticDataDao : IDataAccessible
    {
        public IList<DataRecord> GetDataRecords(DateTime dateFrom, DateTime to)
        {
            return new List<DataRecord>();
        }
    }
}
