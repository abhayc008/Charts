  DECLARE @sqlCommand varchar(1000) 
   SET @sqlCommand = ('SELECT *
      FROM OPENROWSET(''SQLNCLI'', ''Connection Details'',
	  ''
	  DECLARE @Param1 varchar(50)
	SET @Param1 =''''Test''''
	exec [Procedure_Name] @Param1 
         ''
      ) AS a;')
exec (@sqlCommand)
