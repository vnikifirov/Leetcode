DECLARE @N INT = 3;
exec('SELECT TOP ' + @N + ' [class] FROM [University].[dbo].[Courses]');

declare @t1 varchar(500);
set @t1 = ' 1000 * from [Courses]; delete [Courses];--';
-- плохо
exec ('select top ' + @t1 + ' * from [Courses]')
SELECT @t1;

SELECT * from [Courses];