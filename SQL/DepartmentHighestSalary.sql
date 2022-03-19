SELECT [id]
      ,[name]
  FROM [Company].[dbo].[Department]

SELECT [id]
      ,[name]
      ,[salary]
      ,[departmentId]
  FROM [Company].[dbo].[Employee]

SELECT [dep].[name] as "Department",
       [emp].[name] as "Employee",
       [salary] as "Salary"
FROM [Department] dep, [Employee] emp
WHERE emp.departmentId = dep.id 
    and [emp].[salary] = 
        (SELECT MAX([salary]) 
        FROM [Employee]
        WHERE departmentId = dep.id)

SELECT [dep].[name] as "Department",
       [emp].[name] as "Employee",
       [MaxSalary].[salary] as "Salary"
FROM [Department] dep
     ,[Employee] emp
     ,(SELECT [departmentId] as "Department ID",
             MAX([salary]) as "Salary"
        FROM [Employee] emp
        GROUP BY [departmentId]) as "MaxSalary"
WHERE emp.departmentId = dep.id 
    and MaxSalary.[Department ID] = [dep].[id]
    and MaxSalary.Salary = [emp].[salary]

WITH MaxSalary as (SELECT [departmentId] as "Department ID",
             MAX([salary]) as "Salary"
        FROM [Employee] emp
        GROUP BY [departmentId])
SELECT [dep].[name] as "Department",
       [emp].[name] as "Employee",
       [MaxSalary].[salary] as "Salary"
FROM [Department] dep
     ,[Employee] emp
     , MaxSalary
WHERE emp.departmentId = dep.id 
    and MaxSalary.[Department ID] = [dep].[id]
    and MaxSalary.Salary = [emp].[salary]
    