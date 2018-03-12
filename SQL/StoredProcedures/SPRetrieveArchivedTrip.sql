USE [transcendworld_dev]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPRetrieveArchiveTrip] 
@DispatchedHotel  nvarchar(max),
@VoucherNumber nvarchar(max),
@PageNumber int,
@PageSize int = 20
AS
BEGIN
SET NOCOUNT ON;
SELECT 
	   [ArchiveTripId]
      ,[TripId]
      ,[PackageId]
      ,[PaymentType]
      ,[VehicleId]
      ,[VehicleNumber]
      ,[DriverId]
      ,[DriverName]
      ,[GuestName]
      ,[RoomNumber]
      ,[MeterReadingIn]
      ,[MeterReadingOut]
      ,[MeterReadingInGps]
      ,[MeterReadingOutGps]
      ,[MeterReadingInStatus]
      ,[MeterReadingOutStatus]
      ,[Amount]
      ,[PackageCost]
      ,[AdditionalKmCost]
      ,[WaitingHourCost]
      ,[IsOpen]
      ,[IsRemoved]
      ,[IsDeleted]
      ,[PassengerType]
      ,[PassengerTypeList]
      ,[TimeIn]
      ,[TimeOut]
      ,[TripDuration]
      ,[PaymentDateTime]
      ,[Remarks]
      ,[AdditionalKM]
      ,[WaitedHrs]
      ,[VoucherNumber]
      ,[DispatchedHotel]
      ,[Createdby]
      ,[Updatedby]
      ,[TripMileage]
      ,[MeterReadingInGap]
      ,[MeterReadingOutGap]
      ,[PaymentCategory]
      ,[CorporateName]
      ,[ReservationNo]
      ,[IsCustomPackage]
      ,[IsArchive]
      ,[Created]
      ,[Modified]
      ,[IsReopened]

FROM [dbo].[ArchiveTrip]

 WHERE 
	(1 = CASE WHEN @DispatchedHotel IS NULL THEN 1 WHEN ArchiveTrip.DispatchedHotel = @DispatchedHotel THEN 1 ELSE 0 END) AND	
	(1 = CASE WHEN @VoucherNumber IS NULL THEN 1 WHEN ArchiveTrip.VoucherNumber LIKE '%'+@VoucherNumber+'%' THEN 1 ELSE 0 END) AND
    ArchiveTrip.IsDeleted = 0

	ORDER BY ArchiveTripId desc
    OFFSET @PageSize * (@PageNumber - 1) ROWS
    FETCH NEXT @PageSize ROWS ONLY OPTION (RECOMPILE);


	SELECT COUNT(ArchiveTripId) AS 'ItemCount'
	FROM ArchiveTrip
	WHERE 
	(1 = CASE WHEN @DispatchedHotel IS NULL THEN 1 WHEN ArchiveTrip.DispatchedHotel = @DispatchedHotel THEN 1 ELSE 0 END) AND	
	(1 = CASE WHEN @VoucherNumber IS NULL THEN 1 WHEN ArchiveTrip.VoucherNumber LIKE '%'+@VoucherNumber+'%' THEN 1 ELSE 0 END) AND
    ArchiveTrip.IsDeleted = 0 
END
RETURN 0

--exec [RetrieveTripPage] CGH,0,0,0,null,1


