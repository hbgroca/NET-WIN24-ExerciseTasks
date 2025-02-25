DROP TABLE Projects;
DROP TABLE Customers;
DROP TABLE Services;
DROP TABLE Employees;

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