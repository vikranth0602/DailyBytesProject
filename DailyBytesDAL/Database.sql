USE master;

ALTER DATABASE DailyBytesDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE DailyBytesDB;

CREATE DATABASE DailyBytesDB
GO

USE DailyBytesDB
GO

-----------------------------
-- USERS
-----------------------------
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE()
)
GO

-----------------------------
-- CATEGORIES
-----------------------------
CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) UNIQUE NOT NULL
)
GO

-----------------------------
-- ARTICLES
-----------------------------
CREATE TABLE Articles (
    Id INT PRIMARY KEY IDENTITY,
    Title VARCHAR(200) NOT NULL,
    Content VARCHAR(MAX) NOT NULL,
    CategoryId INT,
    CreatedDate DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
)
GO

-----------------------------
-- BOOKMARKS
-----------------------------
CREATE TABLE Bookmarks (
    Id INT PRIMARY KEY IDENTITY,
    UserId INT,
    ArticleId INT,

    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (ArticleId) REFERENCES Articles(Id)
)
GO

-----------------------------
-- COMMENTS
-----------------------------
CREATE TABLE Comments
(
    Id INT PRIMARY KEY IDENTITY,

    UserId INT NOT NULL,

    ArticleId INT NOT NULL,

    Message VARCHAR(MAX) NOT NULL,

    CreatedDate DATETIME
        DEFAULT GETDATE(),

    FOREIGN KEY (UserId)
        REFERENCES Users(Id),

    FOREIGN KEY (ArticleId)
        REFERENCES Articles(Id)
)
GO

-----------------------------
-- RATINGS
-----------------------------

CREATE TABLE Ratings
(
    Id INT PRIMARY KEY IDENTITY,

    UserId INT NOT NULL,

    ArticleId INT NOT NULL,

    RatingValue INT NOT NULL
        CHECK (RatingValue BETWEEN 1 AND 5),

    FOREIGN KEY (UserId)
        REFERENCES Users(Id),

    FOREIGN KEY (ArticleId)
        REFERENCES Articles(Id)
)
GO

-----------------------------
-- SAMPLE DATA
-----------------------------

--USERS
INSERT INTO Users (FirstName, LastName, Email, PasswordHash)
VALUES ('Test', 'User', 'test@test.com', '#@!Te123579');

-- CATEGORIES
INSERT INTO Categories (Name)
VALUES
('Technology'),
('Science'),
('Health')

-- ARTICLES
INSERT INTO Articles (Title, Content, CategoryId)
VALUES
('AI is the Future', 'Content about AI...Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum', 1),

('Space Exploration', 'Content about space...Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum', 2),

('Healthy Living', 'Content about health... Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum', 3),

('AI Database Centres','Database centers around the world',1),
('New Element in Periodic table','A new element was discovered, which is said to highly radioactive',2),

('Brown Paper','Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum
Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,  
Excepteur sint sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum',3),

('4th Dimension','sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum
Lorem ipsum dolor sit amet, consectetur adipiscing elit, ',2),

('Google Pixel','sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum
Lorem ipsum dolor sit amet, consectetur adipiscing elit, ',1)


-----------------------------
-- VERIFY
-----------------------------
SELECT * FROM Users
SELECT * FROM Categories
SELECT * FROM Articles
SELECT * FROM Bookmarks
SELECT * FROM Ratings
SELECT * FROM Comments
GO



--Scaffold-DbContext -Connection "Data Source =(localdb)\MSSQLLocalDB;Initial Catalog=DailyBytesDB;Integrated Security=true" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force 

