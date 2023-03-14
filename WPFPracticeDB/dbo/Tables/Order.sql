CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [Order Ref] NVARCHAR(50) NOT NULL, 
    [Product Name] NVARCHAR(50) NOT NULL, 
    [Status] NVARCHAR(50) NOT NULL, 
    [Date] DATE NOT NULL

)
