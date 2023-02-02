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
