-- Drop the database if it exists
IF DB_ID('SimpleContactDb') IS NOT NULL
BEGIN
    DROP DATABASE SimpleContactDb;
END
GO

-- Create the database
CREATE DATABASE SimpleContactDb;
GO

-- Use the new database
USE SimpleContactDb;
GO


-- Check if the tables already exist and drop them if they do
IF OBJECT_ID('dbo.ContactGroups', 'U') IS NOT NULL
    DROP TABLE dbo.ContactGroups;

IF OBJECT_ID('dbo.Groups', 'U') IS NOT NULL
    DROP TABLE dbo.Groups;

IF OBJECT_ID('dbo.Contacts', 'U') IS NOT NULL
    DROP TABLE dbo.Contacts;

-- Create Contacts table
CREATE TABLE Contacts (
    ContactId INT PRIMARY KEY IDENTITY(1,1),
    ContactName NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
	Description NVARCHAR(255),
    Email NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255)
);

-- Create Groups table
CREATE TABLE Groups (
    GroupId INT PRIMARY KEY IDENTITY(1,1),
    GroupName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    MaxContacts INT,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Create ContactGroups table
CREATE TABLE ContactGroups (
    ContactGroupId INT PRIMARY KEY IDENTITY(1,1),
    ContactId INT,
    GroupId INT,
    FOREIGN KEY (ContactId) REFERENCES Contacts(ContactId),
    FOREIGN KEY (GroupId) REFERENCES Groups(GroupId)
);

-- Insert sample data into Contacts table
INSERT INTO Contacts (ContactName, PhoneNumber, Email, Description, Address)
VALUES 
('John Doe', '123-456-7890', 'john.doe@example.com', 'The first born of the family', '123 Main St'),
('Jane Smith', '987-654-3210', 'jane.smith@example.com', 'My Padi for life', '456 Elm St'),
('Bob Johnson', '555-555-5555', 'bob.johnson@example.com', 'The working partner','789 Oak St');

-- Insert sample data into Groups table
INSERT INTO Groups (GroupName, Description, MaxContacts)
VALUES 
('Family', 'Family members', 10),
('Friends', 'Close friends', 15),
('Work', 'Work contacts', 20);

-- Insert sample data into ContactGroups table
INSERT INTO ContactGroups (ContactId, GroupId)
VALUES 
(1, 1), -- John Doe in Family
(2, 2), -- Jane Smith in Friends
(3, 3), -- Bob Johnson in Work
(1, 2); -- John Doe also in Friends

-- Script to enforce the Duplicate Contact Rule
-- Create a unique index to prevent duplicate contacts
CREATE UNIQUE INDEX UX_Contacts_UniqueContact 
ON Contacts (ContactName, PhoneNumber, Email);

