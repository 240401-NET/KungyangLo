SELECT count(*) FROM dbo.Album;
SELECT count(*) FROM InvoiceLine;

SELECT
  *
FROM
  PetsDB.INFORMATION_SCHEMA.TABLES;
GO

SELECT * FROM PLaylistTrack;

-- Exercises:
-- Create a View/Table Valued Function that can get a customer's order, and what they purchased
-- Create a Stored Procedure that will Create an order, and all tracks that are associated to the order
-- Create a Stored Procedure that will Create a playlist from a list of songs

-- Having clause, SubQuery, cascading, Running Stored Procedure in EF Core