--1. Drop Table if it exists
IF ( EXISTS ( SELECT    *
              FROM      INFORMATION_SCHEMA.TABLES
              WHERE     TABLE_NAME = 'Gamer' ) )
    BEGIN
        TRUNCATE TABLE Gamer;
        DROP TABLE Gamer;
    END;
GO -- Run the previous command and begins new batch
--2. Create Table
CREATE TABLE Gamer
    (
      Id INT PRIMARY KEY
             IDENTITY(1, 1)
             NOT NULL ,
      [Name] NVARCHAR(100) NULL ,
      Gender NVARCHAR(10) NULL ,
      City NVARCHAR(50) NULL,
    );
GO -- Run the previous command and begins new batch
--3. Insert Data
INSERT  Gamer
VALUES  ( N'Name01', N'Male', N'City01' );
INSERT  Gamer
VALUES  ( N'Name02', N'Female', N'City03' );
INSERT  Gamer
VALUES  ( N'Name03', N'Female', N'City01' );
INSERT  Gamer
VALUES  ( N'Name04', N'Male', N'City02' );
