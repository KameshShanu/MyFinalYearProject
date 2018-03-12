namespace DBStorage.Common
{
    using Configuration;
    using Domain.Advertisements;
    using Domain.BataRates;
    using Domain.Corporates;
    using Domain.Customers;
    using Domain.Driver;
    using Domain.Helper;
    using Domain.Client;
    using Domain.VehicleMaintenance;
    using Domain.DispatchNote;
    using Domain.Roles;
    using Domain.Trips;
    using Domain.UserLog;
    using Domain.Users;
    using Domain.Vehicles;
    using Domin.Common;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Threading;
    using Domain.Invoice;
    using Domain.InvoiceDispatchNote;

    /// <summary>
    /// ProjectXContext class.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    /// <seealso cref="Domin.Common.IUnitOfWork" /> 
    public class WingsContext : DbContext, IUnitOfWork
    {
        /// <summary>
        /// Connection string.
        /// </summary>
        private static ThreadLocal<string> connectionString = new ThreadLocal<string>();

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public DbSet<User> User
        {
            get;
            set;
        }

        public DbSet<Vehicle> Vehicle
        {
            get;
            set;
        }
        public DbSet<Role> Role
        {
            get;
            set;
        }

        public DbSet<Driver> Driver
        {
            get;
            set;
        }

        public DbSet<Helper> Helper
        {
            get;
            set;
        }

        public DbSet<Trip> Trip
        {
            get;
            set;
        }

        public DbSet<VehicleRate> VehicleRate
        {
            get;
            set;
        }

        public DbSet<PreDefineTrip> PreDefineTrip
        {
            get;
            set;
        }

        public DbSet<BataRate> BataRate
        {
            get;
            set;
        }

        public DbSet<PackagesList> PackagesList
        {
            get;
            set;
        }

        public DbSet<TripBata> TripBata
        {
            get;
            set;
        }

        public DbSet<UserLog> UserLog
        {
            get;
            set;
        }

        public DbSet<Corporate> Corporate
        {
            get;
            set;
        }

        public DbSet<AdvertisementCategory> AdvertisementCategory
        {
            get;
            set;
        }

        public DbSet<AdvertisementItem> AdvertisementItem
        {
            get;
            set;
        }

        public DbSet<ArchiveTrip> ArchiveTrip
        {
            get;
            set;
        }

        public DbSet<CustomBata> CustomBata
        {
            get;
            set;
        }

        public DbSet<Customer> Customer
        {
            get;
            set;
        }

        public DbSet<Client> Client
        {
            get;
            set;
        }

        public DbSet<VehicleMaintenance> VehicleMaintenance
        {
            get;
            set;
        }

        public DbSet<Invoice> Invoice
        {
            get;
            set;
        }

        public DbSet<DispatchNote> DispatchNote
        {
            get;
            set;
        }

        public DbSet<InvoiceDispatchNote> InvoiceDispatchNote
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WingsContext" /> class.
        /// </summary>
        public WingsContext()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WingsContext" /> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public WingsContext(string connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// Gets or sets connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        public static string ConnectionString
        {
            get
            {
                return connectionString.Value;
            }

            set
            {
                connectionString.Value = value;
            }
        }

        /// <summary>
        /// Factory method to construct an instance of <see cref="WingsContext" />.
        /// </summary>
        /// <returns>
        /// An instance of <see cref="WingsContext" />.
        /// </returns>
        public static WingsContext GetInstance()
        {
            WingsContext instance = null;
            if (!string.IsNullOrWhiteSpace(ConnectionString))
            {
                instance = new WingsContext(ConnectionString);
            }
            else
            {
                instance = new WingsContext();
            }

            instance.Database.CommandTimeout = 40000;
            return instance;
        }

        /// <summary>
        /// Save all entities in the unit.
        /// </summary>
        public void Commit()
        {
            this.SaveChanges();
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        public override int SaveChanges()
        {
            DateTime nowAuditDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate();
            IEnumerable<System.Data.Entity.Infrastructure.DbEntityEntry<BaseEntity>> changeSet = ChangeTracker.Entries<BaseEntity>();
            if (changeSet != null)
            {
                foreach (System.Data.Entity.Infrastructure.DbEntityEntry<BaseEntity> entry in changeSet)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.Created = nowAuditDate;
                            entry.Entity.Modified = nowAuditDate;
                            break;
                        case EntityState.Modified:
                            entry.Entity.Modified = nowAuditDate;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        /// <summary>
        /// Rest all entities in the unit.
        /// </summary>
        public void Rollback()
        {
            ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Unchanged);
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <exception cref="System.ArgumentNullException">modelBuilder</exception>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("modelBuilder");
            }

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            //modelBuilder.Configurations.Add(new VehicleConfiguration());
            modelBuilder.Configurations.Add(new DriverConfiguration());
            modelBuilder.Configurations.Add(new HelperConfiguration());
            modelBuilder.Configurations.Add(new TripConfiguration());
            modelBuilder.Configurations.Add(new VehicleRateConfiguration());
            modelBuilder.Configurations.Add(new PreDefineTripConfiguration());
            modelBuilder.Configurations.Add(new PackagesListConfiguration());
            modelBuilder.Configurations.Add(new BataRateConfiguration());
            modelBuilder.Configurations.Add(new TripBataConfiguration());
            modelBuilder.Configurations.Add(new UserLogConfiguration());
            modelBuilder.Configurations.Add(new CorporateConfiguration());
            modelBuilder.Configurations.Add(new AdvertisementCategoryConfiguration());
            modelBuilder.Configurations.Add(new AdvertisementItemConfiguration());
            modelBuilder.Configurations.Add(new ArchiveTripConfiguration());
            modelBuilder.Configurations.Add(new CustomBataConfiguration());
           // modelBuilder.Configurations.Add(new VehicleMaintenanceConfiguration());

            //base.OnModelCreating(modelBuilder);
        }
    }
}
