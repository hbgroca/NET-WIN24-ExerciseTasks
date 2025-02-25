-- REMOVE PREVOIUS TABLES
DROP TABLE Projects;
DROP TABLE Customers;
DROP TABLE Services;
DROP TABLE Employees;

-- CREATE TABLES
IF OBJECT_ID('Customers','U') IS NULL
	CREATE TABLE Customers (
		Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		Name NVARCHAR(125) NOT NULL,
		ContactPerson NVARCHAR(125) null
	)

IF OBJECT_ID('Services','U') IS NULL
	CREATE TABLE Services (
		Id INT PRIMARY KEY IDENTITY(1,1),
		Name NVARCHAR(200) NOT NULL,
		Price money NOT NULL,
	)

IF OBJECT_ID('Employees','U') IS NULL
	CREATE TABLE Employees (
		Id INT IDENTITY(101,1) PRIMARY KEY,
		FirstName NVARCHAR(75) NOT NULL,
		LastName NVARCHAR(750) NOT NULL,
		Role NVARCHAR(75) NOT NULL,
	)

IF OBJECT_ID('Projects','U') IS NULL
	CREATE TABLE Projects (
		ProjectId NVARCHAR(100) PRIMARY KEY,
		Name NVARCHAR(100) NOT NULL,
		Description NVARCHAR(max) NOT NULL,
		StartDate DATETIME2 NOT NULL DEFAULT GETDATE(),
		EndDate DATETIME2 NULL,
		Status NVARCHAR(50) NOT NULL CHECK (Status IN ('Ej påbörjad', 'Pågående', 'Avslutad')),
		CustomerId INT not null references Customers(Id),
		ServiceId INT not null references Services(Id),
		ProjectManagerId INT not null references Employees(Id)
	)

-- INSERT DATA
INSERT INTO Customers (Name, ContactPerson)
VALUES('ABC Consulting', 'Anna Karlsson'),('DEF Industries', 'Bengt Svensson');


INSERT INTO Services (Name, Price)
VALUES('Konsulttid', 1000),('Utbildning', 5000);


INSERT INTO Employees (FirstName, LastName, Role)
VALUES('Erik', 'Andersson', 'Projectledare'),('Sara', 'Nilsson', 'Konsult');


INSERT INTO Projects(ProjectId, Name, Description, StartDate, EndDate, Status, CustomerId, ServiceId, ProjectManagerId)
VALUES
('P-101', 'Webbutveckling', 'Utveckling av ny webbplats', '2025-01-01', '2025-03-01', 'Pågående', 1, 1, 101),
('P-102', 'Systemintegration', 'Integration av ERP-system', '2025-02-01', '2025-06-01', 'Ej påbörjad', 2, 2, 102);



-- COLLECT DATA
-- 1. Hämta en lista över alla projekt, inklusive projektnummer, namn, status och kundnamn.
SELECT 
    Projects.ProjectId,
    Projects.Name,
    Projects.Status,
    Customers.Name AS CustomerName
FROM Projects
JOIN Customers ON Projects.CustomerId=Customers.Id


-- 2. Hämta detaljer om ett specifikt projekt, inklusive projektnummer, namn, beskrivning, tidsperiod (startdatum och slutdatum), status, kundnamn och tjänstens namn och pris.
SELECT 
    Projects.ProjectId,
    Projects.Name AS ProjectName,
    Projects.Description,
    Projects.StartDate,
    Projects.EndDate,
    Projects.Status,
    Customers.Name AS CustomerName,
    Services.Name AS ServiceName,
    Services.Price AS ServicePrice
FROM Projects
JOIN Customers ON Projects.CustomerId=Customers.Id
JOIN Services ON Projects.ServiceId=Services.Id
WHERE Projects.ProjectId='P-102';


-- 3. Hämta alla pågående projekt som leds av "Erik Andersson".
SELECT 
    Projects.ProjectId,
    Projects.Name,
    Projects.Description,
    Projects.Status,
    CONCAT(Employees.FirstName, ' ', Employees.LastName) AS ProjectManager
FROM Projects
JOIN Customers ON Projects.CustomerId=Customers.Id
JOIN Services ON Projects.ServiceId=Services.Id
JOIN Employees ON Projects.ProjectManagerId=Employees.Id
WHERE Employees.FirstName='Erik' AND Employees.LastName='Andersson';


-- 4. Visa en lista över alla kunder och antalet projekt de har.
SELECT 
    Customers.Name AS CustomerName,
    COUNT(Projects.ProjectID) AS ProjectCount
FROM
    Customers
LEFT JOIN
    Projects ON Customers.Id=Projects.CustomerId
GROUP BY
    Customers.Name
ORDER BY
    CustomerName;



-- UPDATE AND REMOVE DATA
-- 1. Skriv ett SQL-kommando för att uppdatera statusen på projekt "P-102" till "Pågående".
UPDATE Projects SET Status='Pågående' WHERE Projects.ProjectId='P-102';

-- 2. Skriv ett SQL-kommando för att ta bort kunden "DEF Industries" och alla dess projekt.
DELETE FROM Projects
WHERE CustomerId=(SELECT Id FROM Customers WHERE Name='DEF Industries');

DELETE FROM Customers
WHERE Name='DEF Industries';