/****************************************************

	Name: Red_Chart_Time_Totals
	Date: 12/23/17

****************************************************/

DROP TABLE IF EXISTS Red.Red_Chart_Time_Totals;

CREATE TABLE Red.Red_Chart_Time_Totals (	
	Categories NVARCHAR(100)	
	, Time_Totals DECIMAL(10,2) 	
)

INSERT INTO Red.Red_Chart_Time_Totals (
	Categories	
	, Time_Totals
)
SELECT Red_Daily_Work_Category AS Categories
	, SUM(Red_Daily_Work_Time_Today) AS Time_Totals
    FROM Red.Red_Daily_Work
    WHERE 1 = 1
		AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
        AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
		AND Red_Daily_Work_Category NOT LIKE 'WT%'
	GROUP BY Red_Daily_Work_Category