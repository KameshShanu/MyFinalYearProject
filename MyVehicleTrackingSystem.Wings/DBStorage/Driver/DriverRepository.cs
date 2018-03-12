using System;
using System.Collections.Generic;
using DBStorage.Common;
using Domain.Driver;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using DBStorage.IdentityConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace DBStorage.Driver
{
    public class DriverRepository : Repository<Domain.Driver.Driver>, IDriverRepository
    {
        public DriverRepository(WingsContext context) : base(context)
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
        public void DeleteMultipleDrivers(IEnumerable<int> driversToDelete)
        {
            List<string> driversToDeleteInUserTable = new List<string>();

            Context.Driver.Where(d => driversToDelete.Contains(d.DriverId)).ToList().ForEach(
                d =>
                    {
                        d.IsDeleted = true;
                    }
                );
            Context.Commit();

            using (ApplicationDbContext appDBcontext = new ApplicationDbContext())
            {
                UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(appDBcontext);
                UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(store);
                foreach (var userId in driversToDeleteInUserTable)
                {
                    var user = UserManager.FindById(userId);
                    var logins = user.Logins;
                    var rolesForUser = UserManager.GetRoles(userId);

                    using (var transaction = appDBcontext.Database.BeginTransaction())
                    {
                        foreach (var login in logins.ToList())
                        {
                            UserManager.RemoveLogin(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                        }

                        if (rolesForUser.Count() > 0)
                        {
                            foreach (var item in rolesForUser.ToList())
                            {
                                // item should be the name of the role
                                var result = UserManager.RemoveFromRole(user.Id, item);
                            }
                        }
                        UserManager.Delete(user);
                        transaction.Commit();
                    }
                }
            }                
        }

        public IEnumerable<Domain.Driver.Driver> GetAllDrives()
        {
            return Context.Set<Domain.Driver.Driver>().Where(a => a.IsDeleted == false);
        }

        public bool IsDriverExists(string epfNumber, string nIC)
        {
            return !Context.Driver.Any(x => (x.EPFNumber == epfNumber || x.NIC == nIC) && x.IsDeleted.Equals(false));
        }

        public void SaveDriver(Domain.Driver.Driver driver)
        {
            Save(driver);
        }

        public void UpdateDriverAvailable(IEnumerable<int> driversToUpdate)
        {
            Context.Driver.Where(d => driversToUpdate.Contains(d.DriverId)).ToList().ForEach(d => d.IsAvailable = false);
            Context.Commit();
        }
        public void UpdateDriverUnAvailable(IEnumerable<int> driversToUpdate)
        {
            Context.Driver.Where(d => driversToUpdate.Contains(d.DriverId)).ToList().ForEach(d => d.IsAvailable = true);
            Context.Commit();
        }

        public IEnumerable<Domain.Driver.Driver> RetrieveTripsWithDriver()
        {
            try
            {
                SPRetrieveDriversAdmin parameters = new SPRetrieveDriversAdmin();
                using (var connection = GetConnection())
                {
                    return connection.Query<Domain.Driver.Driver>(sql: parameters.GetName(), param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
