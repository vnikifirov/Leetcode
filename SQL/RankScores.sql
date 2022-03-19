SELECT [score]
      ,Dense_Rank()
      OVER (order by [score] desc) as "rank"
  FROM [Scores]
  ORDER BY [score] desc;

--Rank()
--Dense_Rank()

WITH Scores2 as (SELECT MIN(s1.[id]) as "rank"
        ,s1.[score]
        FROM [Scores] s1
        GROUP BY s1.[score])
SELECT s2.[score]
      , s2.[rank]
FROM [Scores] s1 LEFT JOIN Scores2 s2 on [s1].[score] = [s2].[score]
ORDER BY s2.[score] desc
