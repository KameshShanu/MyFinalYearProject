namespace Wings
{
    using Application.BataRates;
    using Application.Client;
    using Application.DispatchNote;
    using Application.Driver;
    using Application.Helper;
    using Application.Invoice;
    using Application.Trips;
    using Application.Users;
    using Application.VehicleMaintenance;
    using DBStorage.BataRates;
    using DBStorage.Client;
    using DBStorage.Common;
    using DBStorage.Customers;
    using DBStorage.DispatchNote;
    using DBStorage.Driver;
    using DBStorage.Helper;
    using DBStorage.Invoice;
    using DBStorage.Trips;
    using DBStorage.Users;
    using Domain.BataRates;
    using Domain.Client;
    using Domain.Customers;
    using Domain.DispatchNote;
    using Domain.Driver;
    using Domain.Helper;
    using Domain.Invoice;
    using Domain.Trips;
    using Domain.Users;
    using EmailUtility.EmailHelpers;
    using StructureMap;

    public static class IoC
    {
        public static StructureMap.IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

                x.For<IUserRepository>().Use<UserRepository>();
                x.For<IUserService>().Use<UserService>();
                x.For<IDriverRepository>().Use<DriverRepository>();
                x.For<IDriverService>().Use<DriverService>();
                x.For<IPreDefineTripRepository>().Use<PreDefineTripRepository>();
                x.For<IPreDefineTripService>().Use<Application.Trips.PreDefineTripService>();
                x.For<IVehicleRateRepository>().Use<VehicleRateRepository>();
                x.For<IVehicleRateService>().Use<VehicleRateService>();
                x.For<IBataRepository>().Use<BataRateRepository>();
                x.For<IBataRateService>().Use<BataRateService>();
                x.For<IPackageListRepository>().Use<PackageListRepository>();
                x.For<IPackageListService>().Use<PackageListService>();
                x.For<IArchiveTripRepository>().Use<ArchiveTripRepository>();
                x.For<IArchiveTripService>().Use<ArchiveTripService>();
                x.For<IMailClient>().Use<SmtpMailClient>();
                x.For<ICustomerRepository>().Use<CustomerRepository>();
                x.For<IHelperRepository>().Use<HelperRepository>();
                x.For<IHelperService>().Use<HelperService>();               
                x.For<IClientRepository>().Use<ClientRepository>();
                x.For<IClientService>().Use<ClientService>();
                x.For<IVehicleMaintenanceService>().Use<VehicleMaintenanceService>();
                x.For<IDispatchNoteRepository>().Use<DispatchNoteRepository>();
                x.For<IDispatchNoteService>().Use<DispatchNoteService>();
                x.For<IInvoiceRepository>().Use<InvoiceRepository>();
                x.For<IInvoiceService>().Use<InvoiceService>();

                x.For<WingsContext>().HybridHttpOrThreadLocalScoped().Use(() => WingsContext.GetInstance());
            });

            return ObjectFactory.Container;
        }
    }
}