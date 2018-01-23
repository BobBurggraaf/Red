/****************************************************

	Name: Red_Etl_Last_Run
	Date: 01/03/2018
	
	SELECT Etl_Stage
		, Run_Date
		, Run_End_Time
		, Error_Cnt
		FROM Red.Red_Etl_Last_Run
		ORDER BY Order_Num

****************************************************/


DROP TABLE IF EXISTS Red.Red_Etl_Last_Run;

CREATE TABLE Red.Red_Etl_Last_Run (
	Etl_Stage NVARCHAR(50)
	, Run_Date DATE
	, Run_End_Time TIME
	, Run_Time INT
	, Error_Cnt INT
	, Order_Num INT
)

INSERT INTO Red.Red_Etl_Last_Run (
	Etl_Stage
	, Run_Date
	, Run_End_Time
	, Run_Time
	, Error_Cnt
	, Order_Num
)
SELECT DISTINCT 'Extract' AS Etl_Stage
	, CONVERT(DATE,A.Alpha_DateTime,101) AS Run_Date 
	, B.Run_End_Time
	, C.Run_Time
	, D.Error_Cnt
	, 1 AS Order_Num
	FROM OneAccord_Warehouse.dbo.Alpha_Table_1 A ,
		(SELECT MAX(CONVERT(TIME(0),Alpha_DateTime)) AS Run_End_Time
			FROM OneAccord_Warehouse.dbo.Alpha_Table_1
		) B , 
		(SELECT DATEDIFF(MINUTE,A.Begin_Time,A.End_Time) AS Run_Time
			FROM
				(SELECT MIN(Alpha_DateTime) AS Begin_Time
					, MAX(Alpha_DateTime) AS End_Time
					FROM Alpha_Table_1
				) A
		) C ,
		(SELECT COUNT(Alpha_Result) AS Error_Cnt
			FROM OneAccord_Warehouse.dbo.Alpha_Table_1 
			WHERE Alpha_Result = '0'
		) D
UNION
SELECT DISTINCT 'Transform' AS Etl_Stage
	, CONVERT(DATE,A.Alpha_DateTime,101) AS Run_Date 
	, B.Run_End_Time
	, C.Run_Time
	, D.Error_Cnt
	, 2 AS Order_Num
	FROM OneAccord_Warehouse.dbo.Alpha_Table_2 A ,
		(SELECT MAX(CONVERT(TIME(0),Alpha_DateTime)) AS Run_End_Time
			FROM OneAccord_Warehouse.dbo.Alpha_Table_2
		) B ,
		(SELECT DATEDIFF(MINUTE,A.Begin_Time,A.End_Time) AS Run_Time
			FROM
				(SELECT MIN(Alpha_DateTime) AS Begin_Time
					, MAX(Alpha_DateTime) AS End_Time
					FROM Alpha_Table_2
				) A		
		) C ,
		(SELECT COUNT(Alpha_Result) AS Error_Cnt
			FROM OneAccord_Warehouse.dbo.Alpha_Table_2 
			WHERE Alpha_Result = '0'
		) D
UNION
SELECT DISTINCT 'Load' AS Etl_Stage
	, CONVERT(DATE,A.Alpha_DateTime,101) AS Run_Date 
	, B.Run_End_Time
	, C.Run_Time
	, D.Error_Cnt 
	, 3 AS Order_Num
	FROM [MSSQL12335\S01].OneAccord_Warehouse.dbo.Alpha_Table_3 A ,
		(SELECT MAX(CONVERT(TIME(0),Alpha_DateTime)) AS Run_End_Time
			FROM [MSSQL12335\S01].OneAccord_Warehouse.dbo.Alpha_Table_3
		) B ,
		(SELECT DATEDIFF(MINUTE,A.Begin_Time,B.End_Time) AS Run_Time
			FROM
				(SELECT MIN(Alpha_DateTime) AS Begin_Time
					FROM [MSSQL12335\S01].OneAccord_Warehouse.dbo.Alpha_Table_3
					WHERE 1 = 1
						AND Alpha_Stage = '_Affiliated_Dim'
				) A ,
				(SELECT MAX(Alpha_DateTime) AS End_Time
					FROM [MSSQL12335\S01].OneAccord_Warehouse.dbo.Alpha_Table_3
				) B		
		) C ,
		(SELECT COUNT(Alpha_Result) AS Error_Cnt
			FROM [MSSQL12335\S01].OneAccord_Warehouse.dbo.Alpha_Table_3 
			WHERE Alpha_Result = '0'
		) D
ORDER BY Order_Num

