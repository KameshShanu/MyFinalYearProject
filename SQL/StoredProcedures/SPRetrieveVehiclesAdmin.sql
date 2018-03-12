USE [transcendworld_dev]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SPRetrieveVehiclesAdmin] 
AS
BEGIN
SET NOCOUNT ON;

SELECT
 [VehicleNumber],
 [IsAvailable],
 [VehicleType]
FROM 
[transcendworld_dev].[dbo].[Vehicle] 
WHERE vehicleId  in(

SELECT v.vehicleId
FROM [transcendworld_dev].[dbo].[Vehicle] v INNER JOIN [transcendworld_dev].[dbo].[Trip] t ON t.[VehicleId] = v.[VehicleId]
WHERE t.[IsOpen] = 1 ) and [IsDeleted]=0

END
RETURN 0
