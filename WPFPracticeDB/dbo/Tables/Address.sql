CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StreetNumber] VARCHAR(10) NOT NULL, 
    [StreetName] NVARCHAR(100) NOT NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    [Country] NVARCHAR(50) NOT NULL, 
    [Postcode] VARCHAR(10) NOT NULL
)
