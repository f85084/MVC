--1. Drop if it exists
--Drop Table if it exists.
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
   [Name] NVARCHAR(100) NOT NULL ,
   Gender NVARCHAR(10) NOT NULL,
   EmailAddress nvarchar(100) NOT NULL,
) 


--3. Insert Data
INSERT  Gamer
VALUES  ( N'Name01 ABB', N'Male', '1@AAA.com');
INSERT  Gamer
VALUES  ( N'Name02 CDDE', N'Female', '2@BBB.com');
INSERT  Gamer
VALUES  ( N'Name03 FIJK', N'Female', '3@CCCC.com');
INSERT  Gamer
VALUES  ( N'Name04 LMOPPQ', N'Male', '4@DD.com');
INSERT  Gamer
VALUES  ( N'Name05 QRSTT', N'Male', '5@EEE.com');
INSERT  Gamer
VALUES  ( N'Name06 TUVVX', N'Female', '6@FF.com');
INSERT  Gamer
VALUES  ( N'Name07 XYZZXX', N'Female', '7@GGGG.com');
INSERT  Gamer
VALUES  ( N'Name08 ABBCDE', N'Male', '8@HH.com');
INSERT  Gamer
VALUES  ( N'Name09 QRSTTUVXX', N'Male', '9@IIII.com');
INSERT  Gamer
VALUES  ( N'Name10 GGAAEE', N'Male', '10@XXWFFS.com');
INSERT  Gamer
VALUES  ( N'Name11 HFSASER', N'Male', '11@AAA.com');
INSERT  Gamer
VALUES  ( N'Name12 ESVSADC', N'Female', '12@BBB.com');
INSERT  Gamer
VALUES  ( N'Name13 REDSVF', N'Female', '13@CCCC.com');
INSERT  Gamer
VALUES  ( N'Name14 BBGVDD', N'Male', '14@DD.com');
INSERT  Gamer
VALUES  ( N'Name15 WWVFSSQ', N'Male', '15@EEE.com');
INSERT  Gamer
VALUES  ( N'Name16 TTVSS', N'Female', '16@FF.com');
INSERT  Gamer
VALUES  ( N'Name17 AAQERR', N'Female', '17@GGGG.com');
INSERT  Gamer
VALUES  ( N'Name18 BBFSAQ', N'Male', '18@HH.com');
INSERT  Gamer
VALUES  ( N'Name19 QRSTTUVXX', N'Male', '19@IIII.com');
INSERT  Gamer
VALUES  ( N'Name20 HHFWSWQ', N'Male', '20@XXWFFS.com');
GO -- Run the previous command and begins new batch

