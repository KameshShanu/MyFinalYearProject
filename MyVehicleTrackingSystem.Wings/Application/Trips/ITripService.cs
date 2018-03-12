using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Trips;
using Domain.Driver;
using Domain.DTO;

namespace Application.Trips
{
    public interface ITripService
    {
        int SaveTripDetails(Trip model);
        IEnumerable<Trip> GetAllTripDetails();

        IEnumerable<Trip> GetAllTripsForDate(DateTime date);
        Trip GetAllTripDetailsById(int id);
        void EditTrip(int id, Trip model);
        void DeleteTrip(int id);
        void DeleteMultipleTrips(IEnumerable<int> tripsToDelete);
        int GenarateVoucherNumber();
        IEnumerable<Trip> SearchByVoucherNumber(string searchText);
        VoucherDataDto GetVoucherDetailsByVoucherNumber(string voucherNumber);
        Trip GetTripDetailsToVoucher(string voucherNo);
        Trip RemoveVoucher(int id, string remarks, string dispatcherName);
        string ArchiveTripsByDate(DateTime startDate, DateTime endDate);
        IEnumerable<TripDto> GetAllTripsForReport(ReportDto model);
        void UpdatePackageCost(int insertedTripId, decimal rate);
        void DeletePackageCost(int tripId, decimal rate);
        IEnumerable<TripDto> RetrieveTrips(bool? IsOpen, bool? IsRemoved, bool? IsArchive, DateTime? StartDate, DateTime? EndDate, string searchText);
        void ArchiveTrips(IEnumerable<int> tripsToAchive);
        void UpdateTripClosed(IEnumerable<int> tripsToUpdate);
        bool VehicleAvailability(int vehicleId);
        bool DriverAvailability(int driverId);
        TripCommonDto RetrieveTripPage(bool v1, bool v2, bool v3, int? page, string searchString, bool? isReopen);
        IEnumerable<TripDto> RetrieveDriverWiseBataDetails(ReportDto reportDto);
        void UpdatePendingTrip(int tripId);
        void UpdateBataApproved(int id);
        void UpdateBataRejected(int id);
        string ArchiveTripById(int tripId);
    }
}
