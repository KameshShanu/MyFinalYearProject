using Domain.Driver;
using Domin.Common;
using System;
using System.Collections.Generic;
using Domain.DTO;

namespace Domain.Trips
{
    public interface ITripRepository : IRepository<Trip>
    {
        IEnumerable<Trip> GetAllTripDetails();
        IEnumerable<Trip> GetAllTripsForDate(DateTime date);
        void EditTrip(int id, Trip model);
        void DeleteMultipleTrips(IEnumerable<int> tripsToDelete);
        int GenarateVoucherNumber();
        Trip GetTripDetailsToVoucher(string voucherNo);
        Trip RemoveVoucher(int id, string remarks, string dispatcherName);
        IEnumerable<TripDto> GetAllTripsForReport(ReportDto model);
        VoucherDataDto GetVoucherDetailsByVoucherNumber(string vehicleNumber);
        void UpdatePackageCost(int insertedTripId, decimal rate);
        int SaveTripDetails(Trip model);
        void DeletePackageCost(int tripId, decimal rate);
        void DeleteTrip(int id);
        IEnumerable<TripDto> RetrieveTrips(bool? IsOpen, bool? IsRemoved, bool? IsArchive, DateTime? StartDate, DateTime? EndDate, string searchText);
        void ArchiveTrips(IEnumerable<int> tripsToAchive);
        string ArchiveTripsByDate(DateTime startDate, DateTime endDate);
        void UpdateTripClosed(IEnumerable<int> tripsToUpdate);
        bool VehicleAvailability(int vehicleId);
        bool DriverAvailability(int driverId);
        TripCommonDto RetrieveTripPage(bool? isOpen, bool? isRemoved, bool? isArchive, int? pageNumber, string searchText, bool? isReopen);
        IEnumerable<TripDto> RetrieveDriverWiseBataDetails(ReportDto reportDto);
        void UpdatePendingTrip(int tripId);
        void UpdateBataApproved(int id);
        void UpdateBataRejected(int id);
        string ArchiveTripById(int tripId);
    }
}
