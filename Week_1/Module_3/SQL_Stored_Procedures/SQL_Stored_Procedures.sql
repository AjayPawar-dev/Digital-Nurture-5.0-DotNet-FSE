-- Create Departments Table
      
CREATE TABLE Departments
(
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);
GO
     
-- Create Employees Table
      
CREATE TABLE Employees
(
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT,
    Salary DECIMAL(10,2),
    JoinDate DATE,

    CONSTRAINT FK_Employees_Departments
    FOREIGN KEY (DepartmentID)
    REFERENCES Departments(DepartmentID)
);
GO
      
-- Insert Sample Data into Departments
      
INSERT INTO Departments
VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');
GO
      
-- Insert Sample Data into Employees
      
INSERT INTO Employees
(
    FirstName,
    LastName,
    DepartmentID,
    Salary,
    JoinDate
)
VALUES
('John', 'Doe', 1, 5000.00, '2020-01-15'),
('Jane', 'Smith', 2, 6000.00, '2019-03-22'),
('Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
('Emily', 'Davis', 4, 5500.00, '2021-11-05');
GO
     
-- Verify Sample Data
      
SELECT * FROM Departments;
SELECT * FROM Employees;
GO

/*
Exercise 1: Create a Stored Procedure
Goal: Create a stored procedure to insert employee details.
*/

CREATE PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN

    INSERT INTO Employees
    (
        FirstName,
        LastName,
        DepartmentID,
        Salary,
        JoinDate
    )
    VALUES
    (
        @FirstName,
        @LastName,
        @DepartmentID,
        @Salary,
        @JoinDate
    );

END;
GO

/*
Exercise 4: Execute the Stored Procedure
Goal: Insert a new employee record using the procedure.
*/

EXEC sp_InsertEmployee
    @FirstName = 'Ajay',
    @LastName = 'Pawar',
    @DepartmentID = 3,
    @Salary = 7500.00,
    @JoinDate = '2026-06-22';
GO

-- Verify Inserted Employee     

SELECT *
FROM Employees;
GO

/*
Exercise 5: Return Data from a Stored Procedure
Goal: Return the total number of employees in a department.
*/

CREATE PROCEDURE sp_GetEmployeeCountByDepartment
    @DepartmentID INT
AS
BEGIN

    SELECT
        DepartmentID,
        COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = @DepartmentID
    GROUP BY DepartmentID;

END;
GO
 
-- Execute Employee Count Procedure

EXEC sp_GetEmployeeCountByDepartment
    @DepartmentID = 3;
GO
