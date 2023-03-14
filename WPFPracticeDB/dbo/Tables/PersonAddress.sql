CREATE TABLE [dbo].[PersonAddress]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [PersonId] INT NOT NULL, 
    [AddressId] INT NOT NULL
)
