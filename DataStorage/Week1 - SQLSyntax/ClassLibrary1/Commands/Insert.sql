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