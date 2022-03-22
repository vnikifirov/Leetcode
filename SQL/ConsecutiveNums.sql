/*

Table: Logs
+-------------+---------+
| Column Name | Type    |
+-------------+---------+
| id          | int     |
| num         | varchar |
+-------------+---------+
id is the primary key for this table.
 
Write an SQL query to find all numbers that appear at least three times consecutively.
Return the result table in any order.
The query result format is in the following example.

Example 1:

Input: 
Logs table:
+----+-----+
| id | num |
+----+-----+
| 1  | 1   |
| 2  | 1   |
| 3  | 1   |
| 4  | 2   |
| 5  | 1   |
| 6  | 2   |
| 7  | 2   |
+----+-----+

Output: 
+-----------------+
| ConsecutiveNums |
+-----------------+
| 1               |
+-----------------+
Explanation: 1 is the only number that appears consecutively for at least three times.

*/
SELECT [num] as "ConsecutiveNums"
FROM
    (SELECT [id]
        ,[num]
        ,LAG ([num], 1, null)
        OVER (order by [id] asc) as "lag_rank"
        ,LEAD ([num], 1, null)
        OVER (order by [id] asc) as "lead_rank"
    FROM [University].[dbo].[Logs]) as "temp"
    WHERE [lag_rank] = [num] and [lead_rank] = [num];
    

--Rank()
--Dense_Rank()
--LAG  (scalar_expression [,offset] [,default]) -- offset = 1, defaut = null
--LEAD (scalar_expression [,offset] [,default]) -- offset = 1, defaut = null