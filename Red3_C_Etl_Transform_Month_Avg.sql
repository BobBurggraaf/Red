/****************************************************

	Name: Red_Etl_Transform_Month_Avg
	Date: 01/03/2018
	
	SELECT Transform_Month
		, Transform_Run_Avg
		FROM Red.Red_Etl_Transform_Month_Avg

****************************************************/

DROP TABLE IF EXISTS #Red_Etl_Transform_Month_Avg;

CREATE TABLE #Red_Etl_Transform_Month_Avg (
	Transform_Month NVARCHAR(7)
	, Transform_Run_Avg INT
	, Row_Num INT
)

INSERT INTO #Red_Etl_Transform_Month_Avg (
	Transform_Month
	, Transform_Run_Avg
	, Row_Num
)
SELECT A.Transform_Month
	, A.Transform_Run_Avg
	, A.Row_Num
	FROM
		(SELECT CONCAT(A.Transform_Year,'-',Transform_Month) AS Transform_Month
			, CASE WHEN A.Run_Days_Counted > 0 THEN A.Run_Time_Summed/A.Run_Days_Counted ELSE 0 END AS Transform_Run_Avg
			, ROW_NUMBER() OVER(ORDER BY CONCAT(A.Transform_Year,'-',Transform_Month) DESC) AS Row_Num
			FROM		
				(SELECT CONVERT(NVARCHAR(4),A.Transform_Date) AS Transform_Year
					, CASE WHEN MONTH(A.Transform_Date) = 1 THEN CONCAT('0',CONVERT(NVARCHAR(2),MONTH(A.Transform_Date)))
							WHEN LEFT(MONTH(A.Transform_Date),1) = 1 THEN CONVERT(NVARCHAR(2),MONTH(A.Transform_Date)) 
							ELSE CONCAT('0',CONVERT(NVARCHAR(2),MONTH(A.Transform_Date))) END AS Transform_Month
					, SUM(A.Run_Time) AS Run_Time_Summed
					, COUNT(CASE WHEN Run_Time IS NOT NULL THEN 1 ELSE NULL END) AS Run_Days_Counted
					FROM
						(SELECT A.Transform_Date
							, DATEDIFF(MINUTE,A.Begin_Transform_Time,B.End_Transform_Time) AS Run_Time
							FROM
								(SELECT CONVERT(DATE, Transform_DateTime, 101) AS Transform_Date
									, MIN(CONVERT(TIME,Transform_DateTime)) AS Begin_Transform_Time
									FROM Transform_Data
									GROUP BY CONVERT(DATE, Transform_DateTime, 101) 
								) A 
								INNER JOIN
									(SELECT CONVERT(DATE, Transform_DateTime, 101) AS Transform_Date
										, MAX(CONVERT(TIME,Transform_DateTime)) AS End_Transform_Time
										FROM Transform_Data
										WHERE 1 = 1
											AND CONVERT(TIME(0),Transform_DateTime) BETWEEN '02:30:00' AND '06:00:00'
										GROUP BY CONVERT(DATE, Transform_DateTime, 101)
									) B ON A.Transform_Date = B.Transform_Date
						) A
					GROUP BY CONVERT(NVARCHAR(4),A.Transform_Date)
						, CASE WHEN MONTH(A.Transform_Date) = 1 THEN CONCAT('0',CONVERT(NVARCHAR(2),MONTH(A.Transform_Date)))
							WHEN LEFT(MONTH(A.Transform_Date),1) = 1 THEN CONVERT(NVARCHAR(2),MONTH(A.Transform_Date)) 
							ELSE CONCAT('0',CONVERT(NVARCHAR(2),MONTH(A.Transform_Date))) END
				) A
		) A
	WHERE 1 = 1
		AND A.Row_Num < 7
	ORDER BY A.Row_Num DESC;


DROP TABLE IF EXISTS Red.Red_Etl_Transform_Month_Avg;

CREATE TABLE Red.Red_Etl_Transform_Month_Avg (
	Transform_Month NVARCHAR(7)
	, Transform_Run_Avg INT
)

INSERT INTO Red.Red_Etl_Transform_Month_Avg (
	Transform_Month
	, Transform_Run_Avg
)
SELECT RIGHT(Transform_Month,5) AS Transform_Month
	, Transform_Run_Avg
	FROM #Red_Etl_Transform_Month_Avg
	WHERE 1 = 1
		AND Row_Num = 6
UNION
SELECT RIGHT(Transform_Month,5) AS Transform_Month
	, Transform_Run_Avg
	FROM #Red_Etl_Transform_Month_Avg
	WHERE 1 = 1
		AND Row_Num = 5
UNION
SELECT RIGHT(Transform_Month,5) AS Transform_Month
	, Transform_Run_Avg
	FROM #Red_Etl_Transform_Month_Avg
	WHERE 1 = 1
		AND Row_Num = 4
UNION
SELECT RIGHT(Transform_Month,5) AS Transform_Month
	, Transform_Run_Avg
	FROM #Red_Etl_Transform_Month_Avg
	WHERE 1 = 1
		AND Row_Num = 3
UNION
SELECT RIGHT(Transform_Month,5) AS Transform_Month
	, Transform_Run_Avg
	FROM #Red_Etl_Transform_Month_Avg
	WHERE 1 = 1
		AND Row_Num = 2
UNION
SELECT RIGHT(Transform_Month,5) AS Transform_Month
	, Transform_Run_Avg
	FROM #Red_Etl_Transform_Month_Avg
	WHERE 1 = 1
		AND Row_Num = 1;

