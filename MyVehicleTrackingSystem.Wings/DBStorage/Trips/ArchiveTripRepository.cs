using Dapper;
using DBStorage.Common;
using Domain.Trips;
using Domin.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Trips
{
    public class ArchiveTripRepository : Repository<ArchiveTrip>, IArchiveTripRepository
    {
        public ArchiveTripRepository(WingsContext context) : base(context)
        {
        }

        private IDbConnection GetConnection()
        {
            var connection = new SqlConnection();
            WingsContext wings = WingsContext.GetInstance();
            connection.ConnectionString = wings.Database.Connection.ConnectionString;
            connection.Open();
            return connection;
        }

        public ArchiveTripCommonDTO Retrieve(int? pageNumber, string voucherNumber)
        {
            try
            {
                SPRetrieveArchiveTrip parameters = new SPRetrieveArchiveTrip();
                parameters.VoucherNumber = voucherNumber;
                parameters.PageNumber = pageNumber;

                using (var connection = GetConnection())
                {
                    var resultSet = connection.QueryMultiple(sql: parameters.GetName(), param: parameters, commandType: CommandType.StoredProcedure);

                    ArchiveTripCommonDTO archivedTrip = new ArchiveTripCommonDTO();
                    archivedTrip.ArchivedTrips = resultSet.Read<ArchiveTrip>();
                    archivedTrip.ItemCount = resultSet.Read<int>().Single();
                    return archivedTrip;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
