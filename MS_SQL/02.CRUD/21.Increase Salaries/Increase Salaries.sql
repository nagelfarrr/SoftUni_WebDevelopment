UPDATE [Employees]
SET 
    [Salary] += [Salary] * 12 / 100
WHERE
    [DepartmentID] = 1 
    OR [DepartmentID] = 2
    OR [DepartmentID] = 4
    OR [DepartmentID] = 11

SELECT [Salary]
FROM [Employees]