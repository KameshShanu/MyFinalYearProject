using DBStorage.Common;
using Domain.Driver;
using Domain.Trips;
using Domain.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Domain.DTO;
using System.Text;

namespace DBStorage.Trips
{
    public class TripRepository : Repository<Trip>, ITripRepository
    {
        public TripRepository(WingsContext context) : base(context)
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
        public int SaveTripDetails(Trip model)
        {
            Save(model);
            return model.TripId;
        }
        public void EditTrip(int id, Trip model)
        {
            Trip trip = RetrieveByKey(id);

            trip.IsOpen = false;
            trip.GuestName = model.GuestName;
            trip.MeterReadingIn = model.MeterReadingIn;
            trip.MeterReadingInGps = model.MeterReadingInGps;
            trip.MeterReadingInGap = model.MeterReadingInGap;
            trip.TripMileage = model.TripMileage;
            trip.PaymentType = model.PaymentType;
            trip.RoomNumber = model.RoomNumber;
            trip.AdditionalKM = model.AdditionalKM;
            trip.WaitedHrs = model.WaitedHrs;
            trip.PaymentDateTime = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate();
            trip.Remarks = model.Remarks;
            trip.TimeIn = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate();
            trip.Amount = model.Amount;
            trip.AdditionalKmCost = model.AdditionalKmCost;
            trip.WaitingHourCost = model.WaitingHourCost;
            trip.PackageCost = model.PackageCost;
            trip.Updatedby = model.Updatedby;
            if (trip.IsCustomPackage != true)
            {
                trip.IsCustomPackage = model.IsCustomPackage;
            }
            if (model.PassengerType != null)
            {
                trip.PassengerType = model.PassengerType;
                trip.PassengerTypeList = model.PassengerTypeList;
            }
            TimeSpan span = (CustomDataHelper.CurrentDateTimeSL.GetCurrentDate() - trip.TimeOut);
            String.Format("{0} days, {1} hours, {2} minutes", span.Days, span.Hours, span.Minutes);
            trip.TripDuration = span.Days.ToString() + " d " + span.Hours.ToString() + " h " + span.Minutes.ToString() + " m ";
            trip.MeterReadingInStatus = model.MeterReadingInStatus;
            trip.CorporateName = model.CorporateName;
            trip.PaymentCategory = model.PaymentCategory;
            trip.ReservationNo = model.ReservationNo;
            Save(trip);
        }

        public IEnumerable<Trip> GetAllTripDetails()
        {
            return Context.Set<Trip>();
        }

        public IEnumerable<Trip> GetAllTripsForDate(DateTime date)
        {
            return Retrieve(t => t.Created.Day == date.Day);
        }
        public void DeleteTrip(int id)
        {
            Trip trip = RetrieveByKey(id);
            Delete(trip);
        }

        public void DeleteMultipleTrips(IEnumerable<int> tripsToDelete)
        {
            Context.Trip.Where(t => tripsToDelete.Contains(t.TripId)).ToList().ForEach(t => t.IsDeleted = true);
            Context.Commit();
        }

        public int GenarateVoucherNumber()
        {
            return (Context.Trip.OrderByDescending(i => i.TripId).Select(i => i.TripId).FirstOrDefault() + 1);
        }

        public Trip GetTripDetailsToVoucher(string voucherNo)
        {
            return Context.Set<Trip>().Where(x => x.VoucherNumber == voucherNo).FirstOrDefault();
            //return Retrieve(t => t.VoucherNumber == voucherNo).FirstOrDefault();
        }

        public Trip RemoveVoucher(int id, string remarks, string dispatcherName)
        {
            Trip trip = RetrieveByKey(id);
            trip.IsRemoved = true;
            trip.IsOpen = false;
            trip.Remarks = remarks;
            trip.Updatedby = dispatcherName;
            trip.TimeIn = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate();
            Save(trip);
            return trip;
        }


        public void UpdatePackageCost(int insertedTripId, decimal rate)
        {
            Trip trip = RetrieveByKey(insertedTripId);
            trip.PackageCost = trip.PackageCost + rate;
            trip.Amount = trip.Amount + rate;
            Save(trip);
        }

        public void DeletePackageCost(int tripId, decimal rate)
        {
            Trip trip = RetrieveByKey(tripId);
            if (trip.Amount != 0)
            {
                trip.PackageCost = trip.PackageCost - rate;
                trip.Amount = trip.Amount - rate;
                Save(trip);
            }
        }
        public VoucherDataDto GetVoucherDetailsByVoucherNumber(string voucherNumber)
        {
            var data = from trips in Context.Trip
                       join vehicles in Context.Vehicle
                       on trips.VehicleId equals vehicles.VehicleId
                       join driver in Context.Driver
                       on trips.DriverId equals driver.DriverId
                       where trips.VoucherNumber == voucherNumber
                       select new VoucherDataDto
                       {
                           VoucherNumber = trips.VoucherNumber,
                           VehicleRegNumber = vehicles.VehicleNumber,
                           DriverName = driver.Name,
                           Status = trips.IsOpen.ToString()
                       };
            return data.FirstOrDefault();
        }

        //new codes using Dapper
        public IEnumerable<TripDto> RetrieveTrips(bool? IsOpen, bool? IsRemoved, bool? IsArchive, DateTime? StartDate, DateTime? EndDate, string voucherNumber)
        {
            try
            {
                SPRetrieveTrip parameters = new SPRetrieveTrip();
                parameters.IsOpen = IsOpen;
                parameters.IsRemoved = IsRemoved;
                parameters.IsArchive = IsArchive;
                parameters.StartDate = StartDate;
                parameters.EndDate = EndDate;
                parameters.Vouchernumber = voucherNumber;

                using (var connection = GetConnection())
                {
                    return connection.Query<TripDto>(sql: parameters.GetName(), param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public IEnumerable<TripDto> GetAllTripsForReport(ReportDto model)
        {
            try
            {
                SPRetrieveTripReport parameters = new SPRetrieveTripReport();
                parameters.Dispatcher = model.Dispatcher;
                parameters.DriverId = model.DriverId == 0 ? null : model.DriverId.ToString();
                parameters.EndDate = model.EndDate;
                parameters.DispatchedHotel = model.HotelName;
                parameters.PassengerType = model.PassengerType;
                parameters.PaymentType = model.PaymentType;
                parameters.StartDate = model.StartDate;
                parameters.VehicleId = model.VehicleId == 0 ? null : model.VehicleId.ToString();
                parameters.CorporateName = model.CorporateName;
                parameters.PaymentCategory = model.PaymentCategory;
                switch (model.Status)
                {
                    case "All":
                        parameters.IsOpen = null;
                        parameters.IsRemoved = null;
                        break;
                    case "Open":
                        parameters.IsOpen = true;
                        parameters.IsRemoved = false;
                        break;
                    case "Closed":
                        parameters.IsOpen = false;
                        parameters.IsRemoved = false;
                        break;
                    case "Cancelled":
                        parameters.IsOpen = false;
                        parameters.IsRemoved = true;
                        break;
                }

                using (var connection = GetConnection())
                {
                    var resultSet = connection.QueryMultiple(sql: parameters.GetName(), param: parameters, commandType: CommandType.StoredProcedure);
                    IEnumerable<TripDto> trips = resultSet.Read<TripDto>();
                    IEnumerable<PackagesListDto> packages = resultSet.Read<PackagesListDto>();

                    foreach (TripDto t in trips)
                    {
                        var tripPackages = new List<PackagesListDto>();
                        var stringBuilder = new StringBuilder();
                        foreach (PackagesListDto tp in packages)
                        {
                            if (tp.TripId.Equals(t.TripId))
                            {
                                tripPackages.Add(tp);
                                t.PackagesList = tripPackages;
                                t.Packages = stringBuilder.Append(tp.PreDefineTripName).Append(", ").ToString();
                            }
                        }
                        t.Status = t.IsReopened == true ? "ReOpen" : t.IsRemoved == true ? "Cancelled" : t.IsOpen == false ? "Closed" : t.IsOpen == true ? "Open" : "-";
                    }
                    return trips;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void ArchiveTrips(IEnumerable<int> tripsToAchive)
        {
            Context.Trip.Where(t => tripsToAchive.Contains(t.TripId)).ToList().ForEach(t => t.IsArchive = true);
            Context.Commit();
        }

        public string ArchiveTripsByDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                SPArchiveTrip parameters = new SPArchiveTrip();
                parameters.StartDate = startDate;
                parameters.EndDate = endDate;

                using (var connection = GetConnection())
                {
                    return connection.Query<string>(sql: parameters.GetName(), param: parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void UpdateTripClosed(IEnumerable<int> tripsToUpdate)
        {
            Context.Trip.Where(v => tripsToUpdate.Contains(v.TripId)).ToList().ForEach(v => v.IsOpen = false);
            Context.Commit();
        }

        public bool VehicleAvailability(int vehicleId)
        {
            return !Context.Trip.Any(x => x.VehicleId == vehicleId && x.IsOpen == true);
        }

        public bool DriverAvailability(int driverId)
        {
            return !Context.Trip.Any(x => x.DriverId == driverId && x.IsOpen == true);
        }

        public TripCommonDto RetrieveTripPage(bool? isOpen, bool? isRemoved, bool? isArchive, int? pageNumber, string searchText, bool? isReopen)
        {
            try
            {
                SPRetrieveTripPage parameters = new SPRetrieveTripPage();
                parameters.IsOpen = isOpen;
                parameters.IsRemoved = isRemoved;
                parameters.IsArchive = isArchive;
                parameters.Vouchernumber = searchText;
                parameters.IsReopened = isReopen;
                parameters.PageNumber = pageNumber;

                using (var connection = GetConnection())
                {
                    var resultSet = connection.QueryMultiple(sql: parameters.GetName(), param: parameters, commandType: CommandType.StoredProcedure);

                    TripCommonDto trip = new TripCommonDto();
                    trip.trips = resultSet.Read<TripDto>();
                    trip.ItemCount = resultSet.Read<int>().Single();
                    return trip;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public IEnumerable<TripDto> RetrieveDriverWiseBataDetails(ReportDto model)
        {
            try
            {
                SPRetrieveDriverWiseBata parameters = new SPRetrieveDriverWiseBata();
                parameters.DriverId = model.DriverId == 0 ? null : model.DriverId.ToString();
                parameters.VehicleId = model.VehicleId == 0 ? null : model.VehicleId.ToString();
                parameters.EmployeeNumber = model.EmployeeNumber;
                parameters.EndDate = model.EndDate;
                parameters.StartDate = model.StartDate;

                using (var connection = GetConnection())
                {
                    var resultSet = connection.QueryMultiple(sql: parameters.GetName(), param: parameters, commandType: CommandType.StoredProcedure);
                    var trips = resultSet.Read<TripDto>().ToList();
                    var packages = resultSet.Read<PackagesListDto>();
                    var customBata = resultSet.Read<CustomBataDto>().ToList();
                    var tripBata = resultSet.Read<TripBataDto>().ToList();

                    trips = resultSet.MapChild
                    (
                        trips,
                        customBata,
                        c => c.TripId,
                        i => i.TripId,
                        (c, i) => { c.CustomBata = i.ToList(); }
                    ).ToList();

                    trips = resultSet.MapChild
                   (
                       trips,
                       tripBata,
                       c => c.TripId,
                       i => i.TripId,
                       (c, i) => { c.TripBata = i.ToList(); }
                   ).ToList();

                    foreach (TripDto t in trips)
                    {
                        var tripPackages = new List<PackagesListDto>();
                        var stringBuilder = new StringBuilder();
                        foreach (PackagesListDto tp in packages)
                        {
                            if (tp.TripId.Equals(t.TripId))
                            {
                                tripPackages.Add(tp);
                                t.PackagesList = tripPackages;
                                t.Packages = stringBuilder.Append(tp.PreDefineTripName).Append(", ").ToString();
                            }
                        }
                        t.Status = t.IsReopened == true ? "ReOpen" : t.IsRemoved == true ? "Cancelled" : t.IsOpen == false ? "Closed" : t.IsOpen == true ? "Open" : "-";
                    };
                    return trips;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePendingTrip(int tripId)
        {
            try
            {
                Context.Trip.Where(t => t.TripId == tripId).ToList().ForEach(t => t.IsReopened = true);
                Context.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateBataApproved(int tripId)
        {
            try
            {
                Context.Trip.Where(t => t.TripId == tripId).ToList().ForEach(t => t.IsReopened = false);
                Context.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateBataRejected(int tripId)
        {
            try
            {
                Context.Trip.Where(t => t.TripId == tripId).ToList().ForEach(t => t.IsReopened = false);
                Context.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ArchiveTripById(int tripId)
        {
            try
            {
                SPArchiveTripById parameters = new SPArchiveTripById();
                parameters.TripId = tripId;

                using (var connection = GetConnection())
                {
                    return connection.Query<string>(sql: parameters.GetName(), param: parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
