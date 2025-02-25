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


-- 5. Skriv ett SQL-kommando för att uppdatera statusen på projekt "P-102" till "Pågående".
UPDATE Projects SET Status='Pågående' WHERE Projects.ProjectId='P-102';


-- 6. Skriv ett SQL-kommando för att ta bort kunden "DEF Industries" och alla dess projekt.
DELETE FROM Projects
WHERE CustomerId=(SELECT Id FROM Customers WHERE Name='DEF Industries');

DELETE FROM Customers
WHERE Name='DEF Industries';