ALTER PROCEDURE [dbo].[SPRetrieveDriversAdmin] 
AS
BEGIN
SET NOCOUNT ON;

SELECT
 [FirstName],
 [LastName],
 [IsAvailable]
FROM 
[transcendworld_dev].[dbo].[Driver] 
WHERE [DriverId]  in(

SELECT v.[DriverId]
FROM [transcendworld_dev].[dbo].[Driver] v INNER JOIN [transcendworld_dev].[dbo].[Trip] t ON t.[DriverId] = v.[DriverId]
WHERE t.[IsOpen] = 1 ) and [IsDeleted]=0

END
RETURN 0
 