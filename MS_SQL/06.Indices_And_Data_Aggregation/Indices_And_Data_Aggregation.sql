USE Gringotts

--01. Records’ Count

SELECT
    COUNT(*)
FROM WizzardDeposits

--02. Longest Magic Wand

SELECT
    MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits

--03. Longest Magic Wand per Deposit Groups

SELECT
    DepositGroup
    ,MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup

--04. Smallest Deposit Group per Magic Wand Size

SELECT TOP(2)
    DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

--05. Deposits Sum

SELECT
    DepositGroup
    ,SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup

--06. Deposits Sum for Ollivander Family

SELECT
    DepositGroup
    ,SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup,MagicWandCreator
HAVING MagicWandCreator = 'Ollivander family'

--07. Deposits Filter

SELECT
    DepositGroup
    ,SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup,MagicWandCreator
HAVING 
    MagicWandCreator = 'Ollivander family' 
    AND SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--08. Deposit Charge

SELECT
    DepositGroup
    ,MagicWandCreator
    ,MIN(DepositCharge) AS NubDeoisutCharge
FROM WizzardDeposits
GROUP BY DepositGroup,MagicWandCreator
ORDER BY MagicWandCreator,DepositGroup

--09. Age Groups

SELECT
    ag.AgeGroup
    ,COUNT(*) AS WizardCount
FROM(
SELECT
    CASE
        WHEN Age <= 10 THEN '[0-10]'
        WHEN Age <= 20 THEN '[11-20]'
        WHEN Age <= 30 THEN '[21-30]'
        WHEN Age <= 40 THEN '[31-40]'
        WHEN Age <= 50 THEN '[41-50]'
        WHEN Age <= 60 THEN '[51-60]'
            ELSE '[61+]' 
    END AS AgeGroup
FROM WizzardDeposits
) as ag
GROUP BY AgeGroup

--10. First Letter
SELECT
    *
FROM
(
    SELECT
        SUBSTRING( FirstName,1,1) AS FirstLetter
    FROM WizzardDeposits
    WHERE DepositGroup = 'Troll Chest'
) AS fl
GROUP BY FirstLetter
ORDER BY FirstLetter

--11. Average Interest

SELECT
    DepositGroup
    ,IsDepositExpired
    ,AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY
    DepositGroup DESC
    ,IsDepositExpired

--12. *Rich Wizard, Poor Wizar

SELECT
	SUM(w1.[DepositAmount] - w2.[DepositAmount]) AS [SumDifference]
FROM [WizzardDeposits] AS [w1]
LEFT JOIN [WizzardDeposits] AS [w2]
	ON w1.[Id] = w2.[Id] - 1

----------------
USE [SoftUni]
----------------

--13. Departments Total Salaries

SELECT
    DepartmentID
    ,SUM( Salary)
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

--14. Employees Minimum Salaries

SELECT
    DepartmentID
    ,MIN(Salary) AS MinimumSalary
FROM Employees
WHERE HireDate > '2000-01-01'
GROUP BY DepartmentID
HAVING 
    DepartmentID = 2
    OR DepartmentID = 5
    OR DepartmentID = 7

--15. Employees Average Salaries

SELECT 
    *
INTO newTable
FROM Employees
WHERE Salary > 30000


DELETE FROM newTable
WHERE ManagerID = 42

UPDATE newTable
    SET Salary += 5000
WHERE DepartmentID = 1

SELECT 
    DepartmentID
    ,AVG(Salary)
FROM newTable
GROUP BY DepartmentID

--16. Employees Maximum Salaries

SELECT 
    DepartmentID
    ,MAX(Salary)
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--17. Employees Count Salaries

SELECT
    COUNT(*) AS Count
FROM Employees
WHERE ManagerID IS NULL

--18. *3rd Highest Salary

SELECT
    DepartmentID
    ,MAX(Salary) AS ThirdHighestSalary
FROM
(
    SELECT
        DepartmentID
        ,Salary
        ,DENSE_RANK()
            OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank
    FROM Employees
) AS r
WHERE Rank = 3
GROUP BY DepartmentID

--19. **Salary Challenge

SELECT TOP(10)
	e.FirstName,
	e.LastName,
	e.DepartmentID
FROM Employees AS e
JOIN
(
	SELECT
		e.DepartmentID
		,AVG(e.Salary) AS AverageSalary
	FROM Employees AS e
	GROUP BY e.DepartmentID
) AS avgSalary
	ON e.DepartmentID = avgSalary.DepartmentID
WHERE e.Salary > avgSalary.AverageSalary