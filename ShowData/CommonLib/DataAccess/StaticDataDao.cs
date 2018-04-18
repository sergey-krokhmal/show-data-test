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
        /// <summary>
        /// Lazy initialization of self instanse
        /// </summary>
        private static readonly Lazy<StaticDataDao> lazyInit =
            new Lazy<StaticDataDao>(() => new StaticDataDao());
        
        /// <summary>
        /// Get self instanse
        /// </summary>
        public static StaticDataDao Get { get { return lazyInit.Value; } }

        /// <summary>
        /// Close constructor
        /// </summary>
        private StaticDataDao() { }

        /// <summary>
        /// Get data records
        /// </summary>
        /// <param name="dateFrom">Date from</param>
        /// <param name="dateTo">Date to</param>
        /// <returns>List interface of data records</returns>
        public IList<DataRecord> GetDataRecords(DateTime dateFrom, DateTime dateTo)
        {
            return new List<DataRecord>
            {
                new DataRecord
                {
                    Id = 1,
                    Date = new DateTime(2018, 4, 18, 0, 0, 0, DateTimeKind.Utc),
                    Text = "test1"
                },
                new DataRecord
                {
                    Id = 2,
                    Date = new DateTime(2018, 4, 16, 0, 0, 0, DateTimeKind.Utc),
                    Text = "test2"
                },
                new DataRecord
                {
                    Id = 3,
                    Date = new DateTime(2018, 4, 10, 0, 0, 0, DateTimeKind.Utc),
                    Text = "test3"
                },
                new DataRecord
                {
                    Id = 4,
                    Date = new DateTime(2018, 3, 24, 0, 0, 0, DateTimeKind.Utc),
                    Text = "test4"
                },
                new DataRecord
                {
                    Id = 5,
                    Date = new DateTime(2018, 2, 9, 0, 0, 0, DateTimeKind.Utc),
                    Text = "test5"
                }
            };
        }
    }
}
