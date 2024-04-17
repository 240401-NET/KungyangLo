-- CREATE TABLE Tools (
--     tool_id int IDENTITY(1,1) NOT NULL,
--     tool_type VARCHAR(20),
--     price float,
--     battV int,
--     CONSTRAINT PK_TransactionHistoryArchive1_TransactionID PRIMARY KEY CLUSTERED (tool_id)
-- )

-- INSERT INTO Tools (tool_type, price, battV)
-- VALUES
-- ('Drill', 129.99, 40),
-- ('Drill', 159.99, 60),
-- ('Impact', 79.99, 24),
-- ('Saw', 54.99, 45),
-- ('Grinder', 210.99, 90);

-- SELECT * FROM Tools;

-- ALTER TABLE Tools
-- ADD brand VARCHAR(20);

-- UPDATE Tools
-- SET brand = 'Bosch'
-- WHERE tool_id = 5;





















-- SELECT * FROM Tools;
------------------------------------
-- CREATE PROCEDURE getBudgetTool
-- AS
-- BEGIN
-- SELECT * FROM Tools
-- WHERE price <= 100
-- END

-- EXEC getBudgetTool
------------------------------------

-- CREATE PROCEDURE getToolsUnderPrice
-- @myPrice int
-- AS
-- BEGIN
-- SELECT * FROM Tools
-- WHERE price <= @myPrice
-- END

-- EXEC getToolsUnderPrice @myPrice = 160;
------------------------------------

-- CREATE PROCEDURE getToolsBetweenPrice
-- (@lowPrice int,
-- @highPrice int)
-- AS
-- BEGIN
-- SELECT * FROM Tools
-- WHERE price >= @lowPrice
-- AND price <= @highPrice
-- END

EXEC getToolsBetweenPrice @lowPrice = 50, @highPrice = 80;
------------------------------------