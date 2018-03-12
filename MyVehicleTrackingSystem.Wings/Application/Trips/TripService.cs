using DBStorage.Trips;
using Domain.Driver;
using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;

namespace Application.Trips
{
    public class TripService : ITripService
    {
        private ITripRepository _tripRepository;

        public TripService(TripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public void EditTrip(int id, Trip model)
        {
            _tripRepository.EditTrip(id, model);
        }

        public IEnumerable<Trip> GetAllTripDetails()
        {
            return _tripRepository.GetAllTripDetails();
        }

        public Trip GetAllTripDetailsById(int id)
        {
            return _tripRepository.RetrieveByKey(id);
        }

        public int SaveTripDetails(Trip model)
        {
            return _tripRepository.SaveTripDetails(model);
        }

        public IEnumerable<Trip> GetAllTripsForDate(DateTime date)
        {
            return _tripRepository.GetAllTripsForDate(date);
        }
        public void DeleteTrip(int id)
        {
            _tripRepository.DeleteTrip(id);
        }

        public void DeleteMultipleTrips(IEnumerable<int> tripsToDelete)
        {
            _tripRepository.DeleteMultipleTrips(tripsToDelete);
        }

        public int GenarateVoucherNumber()
        {
            return _tripRepository.GenarateVoucherNumber();
        }

        public IEnumerable<Trip> SearchByVoucherNumber(string searchText)
        {
            IEnumerable<Trip> searchResult = new Collection<Trip>();
            if (!string.IsNullOrEmpty(searchText))
            {
                searchResult = GetAllTripDetails().Where(t => t.VoucherNumber.Contains(searchText.ToUpperInvariant()) || t.VoucherNumber.StartsWith(searchText.ToUpperInvariant()) || t.VoucherNumber.EndsWith(searchText.ToUpperInvariant()));
            }
            return searchResult;
        }

        public Trip GetTripDetailsToVoucher(string voucherNo)
        {
            return _tripRepository.GetTripDetailsToVoucher(voucherNo);
        }

        public Trip RemoveVoucher(int id, string remarks, string dispatcherName)
        {
            return _tripRepository.RemoveVoucher(id, remarks, dispatcherName);
        }

        public IEnumerable<TripDto> GetAllTripsForReport(ReportDto model)
        {
            return _tripRepository.GetAllTripsForReport(model);
        }

        public VoucherDataDto GetVoucherDetailsByVoucherNumber(string voucherNumber)
        {
            return _tripRepository.GetVoucherDetailsByVoucherNumber(voucherNumber);
        }

        public void UpdatePackageCost(int insertedTripId, decimal rate)
        {
            _tripRepository.UpdatePackageCost(insertedTripId, rate);
        }

        public void DeletePackageCost(int tripId, decimal rate)
        {
            _tripRepository.DeletePackageCost(tripId, rate);
        }
        public IEnumerable<TripDto> RetrieveTrips(bool? IsOpen, bool? IsRemoved, bool? IsArchive, DateTime? StartDate, DateTime? EndDate, string searchText)
        {
            return _tripRepository.RetrieveTrips(IsOpen, IsRemoved, IsArchive, StartDate, EndDate, searchText);
        }

        public void ArchiveTrips(IEnumerable<int> tripsToAchive)
        {
            _tripRepository.ArchiveTrips(tripsToAchive);
        }

        public string ArchiveTripsByDate(DateTime startDate, DateTime endDate)
        {
            return _tripRepository.ArchiveTripsByDate(startDate, endDate);
        }

        public void UpdateTripClosed(IEnumerable<int> tripsToUpdate)
        {
            _tripRepository.UpdateTripClosed(tripsToUpdate);
        }

        public bool VehicleAvailability(int vehicleId)
        {
            return _tripRepository.VehicleAvailability(vehicleId);
        }

        public bool DriverAvailability(int driverId)
        {
            return _tripRepository.DriverAvailability(driverId);
        }
        public TripCommonDto RetrieveTripPage(bool IsOpen, bool IsRemoved, bool IsArchive, int? pageNumber, string searchString, bool? isReopen)
        {
            return _tripRepository.RetrieveTripPage(IsOpen, IsRemoved, IsArchive, pageNumber, searchString, isReopen);
        }

        public IEnumerable<TripDto> RetrieveDriverWiseBataDetails(ReportDto reportDto)
        {
            return _tripRepository.RetrieveDriverWiseBataDetails(reportDto);
        }

        public void UpdatePendingTrip(int tripId)
        {
            _tripRepository.UpdatePendingTrip(tripId);
        }

        public void UpdateBataApproved(int id)
        {
            _tripRepository.UpdateBataApproved(id);
        }

        public void UpdateBataRejected(int id)
        {
            _tripRepository.UpdateBataRejected(id);
        }

        public string ArchiveTripById(int tripId)
        {
            return _tripRepository.ArchiveTripById(tripId);
        }
    }
}
