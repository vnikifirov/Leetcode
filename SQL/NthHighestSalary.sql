/*

Table: Employee
+-------------+------+
| Column Name | Type |
+-------------+------+
| id          | int  |
| salary      | int  |
+-------------+------+
id is the primary key column for this table.
Each row of this table contains information about the salary of an employee.

Write an SQL query to report the nth highest salary from the Employee table. If there is no nth highest salary, the query should report null.
The query result format is in the following example.

Example 1:
Input: 
Employee table:
+----+--------+
| id | salary |
+----+--------+
| 1  | 100    |
| 2  | 200    |
| 3  | 300    |
+----+--------+
n = 2
Output: 
+------------------------+
| getNthHighestSalary(2) |
+------------------------+
| 200                    |
+------------------------+
Example 2:

Input: 
Employee table:
+----+--------+
| id | salary |
+----+--------+
| 1  | 100    |
+----+--------+
n = 2
Output: 
+------------------------+
| getNthHighestSalary(2) |
+------------------------+
| null                   |
+------------------------+
*/

ALTER FUNCTION getNthHighestSalary(@N INT) RETURNS INT AS
BEGIN
    RETURN (
        /* Write your T-SQL query statement below. */
        SELECT distinct [salary] 
        FROM [Company].[dbo].[Employee]
        order by [salary] desc
        OFFSET (@N - 1) ROWS Fetch Next 1 Rows Only
    );
END; 

SELECT [dbo].getNthHighestSalary(2);

SELECT [salary] 
FROM [Company].[dbo].[Employee]
order by salary desc

SELECT [salary] 
FROM [Company].[dbo].[Employee]
order by salary desc
OFFSET 0 ROWS Fetch Next 3 Rows Only

