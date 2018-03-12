using Domain.Vehicles;
using MyVehicleTrackingSystem.Wings.Models;

namespace ProjectX.App_Start
{
    using AutoMapper;
    using Domain.Advertisements;
    using Domain.BataRates;
    using Domain.Client;
    using Domain.Corporates;
    using Domain.Customers;
    using Domain.DispatchNote;
    using Domain.Driver;
    using Domain.DTO;
    using Domain.Helper;
    using Domain.Invoice;
    using Domain.Trips;
    using Domain.Users;
    using Domain.VehicleMaintenance;
    using MyVehicleTrackingSystem.Wings.Models;

    /// <summary>
    /// AutoMapperConfig class.
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// Register all the auto mapping.
        /// </summary>
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Vehicle, VehicleListViewModel>();
                cfg.CreateMap<VehicleListViewModel, Vehicle>();
                cfg.CreateMap<Domain.Driver.Driver, DriverViewModel>();
                cfg.CreateMap<DriverViewModel, Domain.Driver.Driver>();
                cfg.CreateMap<Domain.Trips.PreDefineTrip, PreDefineTripViewModel>();
                cfg.CreateMap<PreDefineTripViewModel, Domain.Trips.PreDefineTrip>();
                cfg.CreateMap<VehicleRateViewModel, Domain.Trips.VehicleRate>();
                cfg.CreateMap<Domain.Trips.VehicleRate, VehicleRateViewModel>();
                cfg.CreateMap<TripViewModel, Trip>();
                cfg.CreateMap<Trip, TripViewModel>();
                cfg.CreateMap<DailyReportViewModel, Trip>();
                cfg.CreateMap<Trip, DailyReportViewModel>();
                cfg.CreateMap<BataRate, BataRateViewModel>();
                cfg.CreateMap<BataRateViewModel, BataRate>();
                cfg.CreateMap<TripViewModel, TripReportDto>();
                cfg.CreateMap<TripReportDto, TripViewModel>();
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<UserViewModel, User>();
                cfg.CreateMap<VoucherPrintModel, Trip>();
                cfg.CreateMap<Trip, VoucherPrintModel>();
                cfg.CreateMap<PackagesDto, PackagesList>();
                cfg.CreateMap<PackagesList, PackagesDto>();
                cfg.CreateMap<DailyReportDto, DailyReportViewModel>();
                cfg.CreateMap<DailyReportViewModel, DailyReportDto>();
                cfg.CreateMap<PackagesListDto, PackagesList>();
                cfg.CreateMap<PackagesList, PackagesListDto>();
                cfg.CreateMap<TripBataDto, TripBata>();
                cfg.CreateMap<TripBata, TripBataDto>();
                cfg.CreateMap<ReportViewModel, ReportViewDto>();
                cfg.CreateMap<ReportViewDto, ReportViewModel>();
                cfg.CreateMap<TripDto, Trip>();
                cfg.CreateMap<Trip, TripDto>();
                cfg.CreateMap<DailyReportDto, Trip>();
                cfg.CreateMap<Trip, DailyReportDto>();
                cfg.CreateMap<DailyReportDto, TripDto>();
                cfg.CreateMap<TripDto, DailyReportDto>();
                cfg.CreateMap<DailyDriverPerformanceDto, TripDto>();
                cfg.CreateMap<TripDto, DailyDriverPerformanceDto>();
                cfg.CreateMap<DailyVehiclePerformanceDto, TripDto>();
                cfg.CreateMap<TripDto, DailyVehiclePerformanceDto>();
                cfg.CreateMap<TripViewModel, TripDto>();
                cfg.CreateMap<TripDto, TripViewModel>();
                cfg.CreateMap<CorporateViewModel, Corporate>();
                cfg.CreateMap<Corporate, CorporateViewModel>();
                cfg.CreateMap<AdvertisementCategory, AdvertisementCategoryViewModel>();
                cfg.CreateMap<AdvertisementCategoryViewModel, AdvertisementCategory>();
                cfg.CreateMap<AdvertisementItem, AdvertisementItemViewModel>();
                cfg.CreateMap<AdvertisementItemViewModel, AdvertisementItem>();
                cfg.CreateMap<AdvertisementCategory, AdvertisementCategoryDTO>();
                cfg.CreateMap<AdvertisementCategoryDTO, AdvertisementCategory>();
                cfg.CreateMap<AdvertisementItem, AdvertisementItemDTO>();
                cfg.CreateMap<AdvertisementItemDTO, AdvertisementItem>();
                cfg.CreateMap<BataReportModel, BataReportDto>();
                cfg.CreateMap<BataReportDto, BataReportModel>();
                cfg.CreateMap<Vehicle, VehicleDto>();
                cfg.CreateMap<VehicleDto, Vehicle>();
                cfg.CreateMap<Driver, DriverDto>();
                cfg.CreateMap<DriverDto, Driver>();
                cfg.CreateMap<VehicleRate, VehicleRateDto>();
                cfg.CreateMap<VehicleRateDto, VehicleRate>();
                cfg.CreateMap<CustomBata, CustomBataDto>();
                cfg.CreateMap<CustomBataDto, CustomBata>();
                cfg.CreateMap<ArchiveTrip, ArchiveTripViewModel>().ReverseMap();
                cfg.CreateMap<Customer, CustomerViewModel>().ReverseMap();
                cfg.CreateMap<CustomerViewModel, Customer>().ReverseMap();
                cfg.CreateMap<UserViewModel, UserDto>().ReverseMap();
                cfg.CreateMap<Helper, HelperViewModel>();
                cfg.CreateMap<HelperViewModel, Helper>();
                cfg.CreateMap<Client, ClientViewModel>();
                cfg.CreateMap<ClientViewModel, Client>();               
                cfg.CreateMap<VehicleMaintenance, VehicleMaintenanceViewModel>();
                cfg.CreateMap<VehicleMaintenanceViewModel, VehicleMaintenance>();
                cfg.CreateMap<DispatchNoteViewModel, DispatchNote>().ReverseMap();
                cfg.CreateMap<InvoiceViewModel, Invoice>().ReverseMap();
            });
        }
    }
}