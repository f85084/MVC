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
IF ( EXISTS ( SELECT    *
              FROM      INFORMATION_SCHEMA.TABLES
              WHERE     TABLE_NAME = 'Team' ) )
    BEGIN
        TRUNCATE TABLE Team;
        DROP TABLE Team;
    END;
GO -- Run the previous command and begins new batch


--2. Create Table
CREATE TABLE Team
    (
      Id INT PRIMARY KEY
             IDENTITY(1, 1)
             NOT NULL ,
      [Name] NVARCHAR(100) NOT NULL
    );
GO -- Run the previous command and begins new batch
CREATE TABLE Gamer
    (
      Id INT PRIMARY KEY
             IDENTITY(1, 1)
             NOT NULL ,
      [Name] NVARCHAR(100) NOT NULL ,
      Gender NVARCHAR(10) NOT NULL ,
      City NVARCHAR(50) NOT NULL ,
      DateOfBirth DATETIME NOT NULL ,
      EmailAddress NVARCHAR(100) NOT NULL,
      Score INT NOT NULL,
      ProfileUrl NVARCHAR(100) ,
      GameMoney INT NOT NULL,
      RolePhoto NVARCHAR(100) ,
      RolePhotoAltText NVARCHAR(100) ,
      TeamId INT FOREIGN KEY REFERENCES Team ( Id ) NOT NULL
    );
GO -- Run the previous command and begins new batch



--3. Insert Data
INSERT  Team
VALUES  ( N'TeamOne' );
INSERT  Team
VALUES  ( N'TeamTwo' );
INSERT  Team
VALUES  ( N'TeamThree' );
GO -- Run the previous command and begins new batch
INSERT  Gamer
VALUES  ( N'NameOne ABB', N'Male', N'City01', '1979/4/28', '1@AAA.com', 3500,
          'https://ithandyguytutorial.blogspot.com.au/', 1000,
          '~/Photos/Name01.png', 'Name01RolePhoto', 1 );
INSERT  Gamer
VALUES  ( N'NameTwo CDDE', N'Female', N'City03', '1981/7/24', '2@BBB.com', 3500,
          'https://ithandyguytutorial.blogspot.com.au/', 1500,
          '~/Photos/Name02.png', 'Name02RolePhoto', 2 );
INSERT  Gamer
VALUES  ( N'NameThree FIJK', N'Female', N'City01', '1984/12/5', '3@CCCC.com',
          3500, 'https://ithandyguytutorial.blogspot.com.au/', 4000,
          '~/Photos/Name03.png', 'Name03RolePhoto', 3 );
INSERT  Gamer
VALUES  ( N'NameFour LMOPPQ', N'Male', N'City02', '1983/5/29', '4@DD.com', 3500,
          'https://ithandyguytutorial.blogspot.com.au/', 2500,
          '~/Photos/Name04.png', 'Name04RolePhoto', 1 );
INSERT  Gamer
VALUES  ( N'NameFive QRSTT', N'Male', N'City01', '1979/6/20', '5@EEE.com', 3500,
          'https://ithandyguytutorial.blogspot.com.au/', 3500,
          '~/Photos/Name05.png', 'Name05RolePhoto', 3 );
INSERT  Gamer
VALUES  ( N'NameSix TUVVX', N'Female', N'City03', '1984/5/15', '6@FF.com', 3500,
          'https://ithandyguytutorial.blogspot.com.au/', 2500,
          '~/Photos/Name06.png', 'Name06RolePhoto', 3 );
INSERT  Gamer
VALUES  ( N'NameSeven XYZZXX', N'Female', N'City01', '1986/4/29', '7@GGGG.com',
          3500, 'https://ithandyguytutorial.blogspot.com.au/', 4550,
          '~/Photos/Name07.png', 'Name07RolePhoto', 2 );
INSERT  Gamer
VALUES  ( N'NameEight ABBCDE', N'Male', N'City02', '1985/7/28', '8@HH.com', 3500,
          'https://ithandyguytutorial.blogspot.com.au/', 3550,
          '~/Photos/Name08.png', 'Name08RolePhoto', 1 );
INSERT  Gamer
VALUES  ( N'NameNine QRSTTUVXX', N'Male', N'City02', '1983/4/16', '9@IIII.com',
          3500, 'https://ithandyguytutorial.blogspot.com.au/', 2510,
          '~/Photos/Name09.png', 'Name09RolePhoto', 1 );
GO -- Run the previous command and begins new batch



