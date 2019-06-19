CREATE TABLE [dbo].[Persons]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [NationalNumber] NUMERIC NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [BirthDate] DATE NOT NULL, 
    [DeathDate] DATE NOT NULL, 
    [Father] INT NULL, 
    [Mother] INT NULL, 
    [Spouse] INT NULL 

)
