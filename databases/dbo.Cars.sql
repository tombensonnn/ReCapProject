CREATE TABLE [dbo].[Cars]
(
	[Id] INT NOT NULL PRIMARY KEY, 
   	[BrandId] INT NULL, 
    	[ColorId] INT NULL, 
    	[ModelYear] NCHAR(10) NULL, 
    	[DailyPrice] MONEY NULL, 
    	[Description] NCHAR(10) NULL
)
