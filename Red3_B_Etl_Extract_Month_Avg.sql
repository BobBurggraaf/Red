/****************************************************

	Name: Red_Etl_Extract_Month_Avg
	Date: 01/03/2018
	
	SELECT Extract_Month
		, Extract_Run_Avg
		FROM Red.Red_Etl_Extract_Month_Avg

****************************************************/

DROP TABLE IF EXISTS #Red_Etl_Extract_Month_Avg;

CREATE TABLE #Red_Etl_Extract_Month_Avg (
	Extract_Month NVARCHAR(7)
	, Extract_Run_Avg INT
	, Row_Num INT
)

INSERT INTO #Red_Etl_Extract_Month_Avg (
	Extract_Month
	, Extract_Run_Avg
	, Row_Num
)
SELECT A.Extract_Month
	, A.Extract_Run_Avg
	, A.Row_Num
	FROM
		(SELECT CONCAT(A.Extract_Year,'-',Extract_Month) AS Extract_Month
			, CASE WHEN A.Run_Days_Counted > 0 THEN A.Run_Time_Summed/A.Run_Days_Counted ELSE 0 END AS Extract_Run_Avg
			, ROW_NUMBER() OVER(ORDER BY CONCAT(A.Extract_Year,'-',Extract_Month) DESC) AS Row_Num
			FROM		
				(SELECT CONVERT(NVARCHAR(4),A.Extract_Date) AS Extract_Year
					, CASE WHEN MONTH(A.Extract_Date) = 1 THEN CONCAT('0',CONVERT(NVARCHAR(2),MONTH(A.Extract_Date)))
							WHEN LEFT(MONTH(A.Extract_Date),1) = 1 THEN CONVERT(NVARCHAR(2),MONTH(A.Extract_Date)) 
							ELSE CONCAT('0',CONVERT(NVARCHAR(2),MONTH(A.Extract_Date))) END AS Extract_Month
					, SUM(A.Run_Time) AS Run_Time_Summed
					, COUNT(CASE WHEN Run_Time IS NOT NULL THEN 1 ELSE NULL END) AS Run_Days_Counted
					FROM		
						(
						SELECT A.Extract_Date
							, CASE WHEN A.Run_Time > 100 THEN NULL
								ELSE A.Run_Time END AS Run_Time
							FROM
								(SELECT A.Extract_Date
									, CASE WHEN B.Extract_DateTime IS NOT NULL THEN DATEDIFF(MINUTE,A.Extract_DateTime,B.Extract_DateTime)
										ELSE NULL END AS Run_Time
									FROM
										(SELECT 'Beginning of the run' AS Beginning
											, B.Extract_Date
											, A.Extract_DateTime
											FROM Extract_Data A
												INNER JOIN
													(
													SELECT A.Extract_Table_Id
														, CONVERT(DATE,A.Extract_DateTime,101) AS Extract_Date
														, MIN(A.Extract_Data_Key) AS Min_Extract_Data_Key
														FROM Extract_Data A
															INNER JOIN 
																(SELECT CONVERT(DATE,Extract_DateTime,101) AS Extract_Date
																	, MAX(Extract_Table_Id) AS Max_Extract_Table_Id
																	, MIN(Extract_Table_Id) AS Min_Extract_Table_Id
																	FROM Extract_Data
																	GROUP BY CONVERT(DATE,Extract_DateTime,101)
																) B ON CONVERT(DATE,A.Extract_DateTime,101) = B.Extract_Date
																		AND A.Extract_Table_Id = B.Min_Extract_Table_Id
														GROUP BY A.Extract_Table_Id
															, CONVERT(DATE,A.Extract_DateTime,101)
													) B ON A.Extract_Data_Key = B.Min_Extract_Data_Key
										) A
										LEFT JOIN
										(SELECT 'Ending of the run' AS Ending
											, B.Extract_Date
											, A.Extract_DateTime
											FROM Extract_Data A
												INNER JOIN
												(
												SELECT A.Extract_Table_Id
													, CONVERT(DATE,A.Extract_DateTime,101) AS Extract_Date
													, MIN(A.Extract_Data_Key) AS Min_Extract_Data_Key
													FROM Extract_Data A
														INNER JOIN 
															(SELECT CONVERT(DATE,Extract_DateTime,101) AS Extract_Date
																, MAX(Extract_Table_Id) AS Max_Extract_Table_Id
																, MIN(Extract_Table_Id) AS Min_Extract_Table_Id
																FROM Extract_Data
																GROUP BY CONVERT(DATE,Extract_DateTime,101)
															) B ON CONVERT(DATE,A.Extract_DateTime,101) = B.Extract_Date
																	AND A.Extract_Table_Id = B.Max_Extract_Table_Id
													GROUP BY A.Extract_Table_Id
														, CONVERT(DATE,A.Extract_DateTime,101)
												) B ON A.Extract_Data_Key = B.Min_Extract_Data_Key
										) B ON A.Extract_Date = B.Extract_Date
								) A
						) A
					GROUP BY CONVERT(NVARCHAR(4),A.Extract_Date)
						, CASE WHEN MONTH(A.Extract_Date) = 1 THEN CONCAT('0',CONVERT(NVARCHAR(2),MONTH(A.Extract_Date)))
							WHEN LEFT(MONTH(A.Extract_Date),1) = 1 THEN CONVERT(NVARCHAR(2),MONTH(A.Extract_Date)) 
							ELSE CONCAT('0',CONVERT(NVARCHAR(2),MONTH(A.Extract_Date))) END
				) A
		) A
	WHERE 1 = 1
		AND A.Row_Num < 7
	ORDER BY A.Row_Num DESC;


DROP TABLE IF EXISTS Red.Red_Etl_Extract_Month_Avg;

CREATE TABLE Red.Red_Etl_Extract_Month_Avg (
	Extract_Month NVARCHAR(7)
	, Extract_Run_Avg INT
)

INSERT INTO Red.Red_Etl_Extract_Month_Avg (
	Extract_Month
	, Extract_Run_Avg
)
SELECT RIGHT(Extract_Month,5) AS Extract_Month
	, Extract_Run_Avg
	FROM #Red_Etl_Extract_Month_Avg
	WHERE 1 = 1
		AND Row_Num = 6
UNION
SELECT RIGHT(Extract_Month,5) AS Extract_Month
	, Extract_Run_Avg
	FROM #Red_Etl_Extract_Month_Avg
	WHERE 1 = 1
		AND Row_Num = 5
UNION
SELECT RIGHT(Extract_Month,5) AS Extract_Month
	, Extract_Run_Avg
	FROM #Red_Etl_Extract_Month_Avg
	WHERE 1 = 1
		AND Row_Num = 4
UNION
SELECT RIGHT(Extract_Month,5) AS Extract_Month
	, Extract_Run_Avg
	FROM #Red_Etl_Extract_Month_Avg
	WHERE 1 = 1
		AND Row_Num = 3
UNION
SELECT RIGHT(Extract_Month,5) AS Extract_Month
	, Extract_Run_Avg
	FROM #Red_Etl_Extract_Month_Avg
	WHERE 1 = 1
		AND Row_Num = 2
UNION
SELECT RIGHT(Extract_Month,5) AS Extract_Month
	, Extract_Run_Avg
	FROM #Red_Etl_Extract_Month_Avg
	WHERE 1 = 1
		AND Row_Num = 1;

