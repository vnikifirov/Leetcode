-- Write an SQL query to swap the seat id of every two consecutive students. 
-- If the number of students is odd / even, the id of the last student is not swapped.
-- Return the result table ordered by id in ascending order.

/*
Pseudocode
SELECT 
    case 
  
        when [id] % 2 = 0
        then [id] - 1 -- even
        else [id] + 1 -- odd

    end
    as "Number"

Seat table:
+----+---------+
| id | student |
+----+---------+
| 1  | Abbot   |
| 2  | Doris   |
+----+---------+
Output: 
+----+---------+
| id | student |
+----+---------+
| 1  | Doris   |
| 2  | Abbot   |
+----+---------+

*/

DECLARE @count int
set @count = (SELECT COUNT(*)
             FROM [University].[dbo].[Seat])

SELECT 
    case 
        when [id] % 2 = 0
        then [id] - 1 -- even

        when 
        [id] = @count and @count % 2 = 1
        then [id]
        else [id] + 1 -- odd
    end
    as "Student ID",
    [student]
  FROM [University].[dbo].[Seat]
  ORDER BY "Student ID" ASC