/****************************************************

	Name: Red_Weekly_Summary
	Date: 12/22/17

****************************************************/

SELECT A.Category
	, A.Monday
	, A.Tuesday
	, A.Wednesday
	, A.Thursday
	, A.Friday
	, A.SubTotal
	FROM
		(SELECT A.Category
			, A.Monday
			, A.Tuesday
			, A.Wednesday
			, A.Thursday
			, A.Friday
			, A.SubTotal
			, 1 AS Row_Order
			FROM
				(SELECT A.Red_Daily_Work_Category AS Category
					, Monday.Time_Today_Monday AS Monday
					, Tuesday.Time_Today_Tuesday AS Tuesday
					, Wednesday.Time_Today_Wednesday AS Wednesday
					, Thursday.Time_Today_Thursday AS Thursday
					, Friday.Time_Today_Friday AS Friday
					, A.Time_Today_SubTotal AS SubTotal
					FROM 
						(SELECT Red_Daily_Work_Category
							, SUM(Red_Daily_Work_Time_Today) AS Time_Today_SubTotal
							FROM Red.Red_Daily_Work
							WHERE 1 = 1
								AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																					AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
								AND Red_Daily_Work_Category NOT LIKE 'WT%'
							GROUP BY Red_Daily_Work_Category
						) A 
						LEFT JOIN
							(SELECT Red_Daily_Work_Category
								, SUM(Red_Daily_Work_Time_Today) AS Time_Today_Monday
								FROM Red.Red_Daily_Work
								WHERE 1 = 1
									AND DATENAME(DW,Red_Daily_Work_Record_Date) = 'Monday'
									AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																						AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
									AND Red_Daily_Work_Category NOT LIKE 'WT%'
								GROUP BY Red_Daily_Work_Category
							) Monday ON A.Red_Daily_Work_Category = Monday.Red_Daily_Work_Category
						LEFT JOIN
							(SELECT Red_Daily_Work_Category
								, SUM(Red_Daily_Work_Time_Today) AS Time_Today_Tuesday
								FROM Red.Red_Daily_Work
								WHERE 1 = 1
									AND DATENAME(DW,Red_Daily_Work_Record_Date) = 'Tuesday'
									AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																						AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
									AND Red_Daily_Work_Category NOT LIKE 'WT%'
								GROUP BY Red_Daily_Work_Category
							) Tuesday ON A.Red_Daily_Work_Category = Tuesday.Red_Daily_Work_Category
						LEFT JOIN
							(SELECT Red_Daily_Work_Category
								, SUM(Red_Daily_Work_Time_Today) AS Time_Today_Wednesday
								FROM Red.Red_Daily_Work
								WHERE 1 = 1
									AND DATENAME(DW,Red_Daily_Work_Record_Date) = 'Wednesday'
									AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																						AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
									AND Red_Daily_Work_Category NOT LIKE 'WT%'
								GROUP BY Red_Daily_Work_Category
							) Wednesday ON A.Red_Daily_Work_Category = Wednesday.Red_Daily_Work_Category
						LEFT JOIN
							(SELECT Red_Daily_Work_Category
								, SUM(Red_Daily_Work_Time_Today) AS Time_Today_Thursday
								FROM Red.Red_Daily_Work
								WHERE 1 = 1
									AND DATENAME(DW,Red_Daily_Work_Record_Date) = 'Thursday'
									AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																						AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
									AND Red_Daily_Work_Category NOT LIKE 'WT%'
								GROUP BY Red_Daily_Work_Category
							) Thursday ON A.Red_Daily_Work_Category = Thursday.Red_Daily_Work_Category
						LEFT JOIN
							(SELECT Red_Daily_Work_Category
								, SUM(Red_Daily_Work_Time_Today) AS Time_Today_Friday
								FROM Red.Red_Daily_Work
								WHERE 1 = 1
									AND DATENAME(DW,Red_Daily_Work_Record_Date) = 'Friday'
									AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																						AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
									AND Red_Daily_Work_Category NOT LIKE 'WT%'
								GROUP BY Red_Daily_Work_Category
							) Friday ON A.Red_Daily_Work_Category = Friday.Red_Daily_Work_Category
				) A
		UNION
		SELECT A.Category
			, A.Monday
			, A.Tuesday
			, A.Wednesday
			, A.Thursday
			, A.Friday
			, A.SubTotal
			, 2 AS Row_Order
			FROM
				(SELECT '                 Total Worked:' AS Category
					, SUM(Monday.Time_Today_Monday) AS Monday
					, SUM(Tuesday.Time_Today_Tuesday) AS Tuesday
					, SUM(Wednesday.Time_Today_Wednesday) AS Wednesday
					, SUM(Thursday.Time_Today_Thursday) AS Thursday
					, SUM(Friday.Time_Today_Friday) AS Friday
					, SUM(A.Time_Today_SubTotal) AS SubTotal
					FROM 
						(SELECT Red_Daily_Work_Category
							, SUM(Red_Daily_Work_Time_Today) AS Time_Today_SubTotal
							FROM Red.Red_Daily_Work
							WHERE 1 = 1
								AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																					AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
								AND Red_Daily_Work_Category NOT LIKE 'WT%'
							GROUP BY Red_Daily_Work_Category
						) A 
						LEFT JOIN
							(SELECT Red_Daily_Work_Category
								, SUM(Red_Daily_Work_Time_Today) AS Time_Today_Monday
								FROM Red.Red_Daily_Work
								WHERE 1 = 1
									AND DATENAME(DW,Red_Daily_Work_Record_Date) = 'Monday'
									AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																						AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
									AND Red_Daily_Work_Category NOT LIKE 'WT%'
								GROUP BY Red_Daily_Work_Category
							) Monday ON A.Red_Daily_Work_Category = Monday.Red_Daily_Work_Category
						LEFT JOIN
							(SELECT Red_Daily_Work_Category
								, SUM(Red_Daily_Work_Time_Today) AS Time_Today_Tuesday
								FROM Red.Red_Daily_Work
								WHERE 1 = 1
									AND DATENAME(DW,Red_Daily_Work_Record_Date) = 'Tuesday'
									AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																						AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
									AND Red_Daily_Work_Category NOT LIKE 'WT%'
								GROUP BY Red_Daily_Work_Category
							) Tuesday ON A.Red_Daily_Work_Category = Tuesday.Red_Daily_Work_Category
						LEFT JOIN
							(SELECT Red_Daily_Work_Category
								, SUM(Red_Daily_Work_Time_Today) AS Time_Today_Wednesday
								FROM Red.Red_Daily_Work
								WHERE 1 = 1
									AND DATENAME(DW,Red_Daily_Work_Record_Date) = 'Wednesday'
									AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																						AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
									AND Red_Daily_Work_Category NOT LIKE 'WT%'
								GROUP BY Red_Daily_Work_Category
							) Wednesday ON A.Red_Daily_Work_Category = Wednesday.Red_Daily_Work_Category
						LEFT JOIN
							(SELECT Red_Daily_Work_Category
								, SUM(Red_Daily_Work_Time_Today) AS Time_Today_Thursday
								FROM Red.Red_Daily_Work
								WHERE 1 = 1
									AND DATENAME(DW,Red_Daily_Work_Record_Date) = 'Thursday'
									AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																						AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
									AND Red_Daily_Work_Category NOT LIKE 'WT%'
								GROUP BY Red_Daily_Work_Category
							) Thursday ON A.Red_Daily_Work_Category = Thursday.Red_Daily_Work_Category
						LEFT JOIN
							(SELECT Red_Daily_Work_Category
								, SUM(Red_Daily_Work_Time_Today) AS Time_Today_Friday
								FROM Red.Red_Daily_Work
								WHERE 1 = 1
									AND DATENAME(DW,Red_Daily_Work_Record_Date) = 'Friday'
									AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																						AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
									AND Red_Daily_Work_Category NOT LIKE 'WT%'
								GROUP BY Red_Daily_Work_Category
							) Friday ON A.Red_Daily_Work_Category = Friday.Red_Daily_Work_Category
				) A
		UNION
		SELECT NULL AS Category
			, NULL AS Monday
			, NULL AS Tuesday
			, NULL AS Wednesday
			, NULL AS Thursday
			, NULL AS Friday
			, NULL AS SubTotal
			, 3 AS Row_Order
		UNION
		SELECT A.Category
			, A.Monday
			, A.Tuesday
			, A.Wednesday
			, A.Thursday
			, A.Friday
			, A.SubTotal
			, 4 AS Row_Order
			FROM
				(SELECT A.Red_Daily_Work_Category AS Category
					, Monday.Time_Today_Monday AS Monday
					, Tuesday.Time_Today_Tuesday AS Tuesday
					, Wednesday.Time_Today_Wednesday AS Wednesday
					, Thursday.Time_Today_Thursday AS Thursday
					, Friday.Time_Today_Friday AS Friday
					, A.Time_Today_SubTotal AS SubTotal
					FROM 
						(SELECT Red_Daily_Work_Category
							, SUM(Red_Daily_Work_Time_Today) AS Time_Today_SubTotal
							FROM Red.Red_Daily_Work
							WHERE 1 = 1
								AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																					AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
								AND Red_Daily_Work_Category LIKE 'WT%'
							GROUP BY Red_Daily_Work_Category
						) A 
						LEFT JOIN
							(SELECT Red_Daily_Work_Category
								, SUM(Red_Daily_Work_Time_Today) AS Time_Today_Monday
								FROM Red.Red_Daily_Work
								WHERE 1 = 1
									AND DATENAME(DW,Red_Daily_Work_Record_Date) = 'Monday'
									AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																						AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
									AND Red_Daily_Work_Category LIKE 'WT%'
								GROUP BY Red_Daily_Work_Category
							) Monday ON A.Red_Daily_Work_Category = Monday.Red_Daily_Work_Category
						LEFT JOIN
							(SELECT Red_Daily_Work_Category
								, SUM(Red_Daily_Work_Time_Today) AS Time_Today_Tuesday
								FROM Red.Red_Daily_Work
								WHERE 1 = 1
									AND DATENAME(DW,Red_Daily_Work_Record_Date) = 'Tuesday'
									AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																						AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
									AND Red_Daily_Work_Category LIKE 'WT%'
								GROUP BY Red_Daily_Work_Category
							) Tuesday ON A.Red_Daily_Work_Category = Tuesday.Red_Daily_Work_Category
						LEFT JOIN
							(SELECT Red_Daily_Work_Category
								, SUM(Red_Daily_Work_Time_Today) AS Time_Today_Wednesday
								FROM Red.Red_Daily_Work
								WHERE 1 = 1
									AND DATENAME(DW,Red_Daily_Work_Record_Date) = 'Wednesday'
									AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																						AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
									AND Red_Daily_Work_Category LIKE 'WT%'
								GROUP BY Red_Daily_Work_Category
							) Wednesday ON A.Red_Daily_Work_Category = Wednesday.Red_Daily_Work_Category
						LEFT JOIN
							(SELECT Red_Daily_Work_Category
								, SUM(Red_Daily_Work_Time_Today) AS Time_Today_Thursday
								FROM Red.Red_Daily_Work
								WHERE 1 = 1
									AND DATENAME(DW,Red_Daily_Work_Record_Date) = 'Thursday'
									AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																						AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
									AND Red_Daily_Work_Category LIKE 'WT%'
								GROUP BY Red_Daily_Work_Category
							) Thursday ON A.Red_Daily_Work_Category = Thursday.Red_Daily_Work_Category
						LEFT JOIN
							(SELECT Red_Daily_Work_Category
								, SUM(Red_Daily_Work_Time_Today) AS Time_Today_Friday
								FROM Red.Red_Daily_Work
								WHERE 1 = 1
									AND DATENAME(DW,Red_Daily_Work_Record_Date) = 'Friday'
									AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																						AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
									AND Red_Daily_Work_Category LIKE 'WT%'
								GROUP BY Red_Daily_Work_Category
							) Friday ON A.Red_Daily_Work_Category = Friday.Red_Daily_Work_Category
				) A
		UNION
		SELECT A.Category
			, A.Monday
			, A.Tuesday
			, A.Wednesday
			, A.Thursday
			, A.Friday
			, A.SubTotal
			, 5 AS Row_Order
			FROM
				(SELECT '                 Total Wait:' AS Category
					, SUM(Monday.Time_Today_Monday) AS Monday
					, SUM(Tuesday.Time_Today_Tuesday) AS Tuesday
					, SUM(Wednesday.Time_Today_Wednesday) AS Wednesday
					, SUM(Thursday.Time_Today_Thursday) AS Thursday
					, SUM(Friday.Time_Today_Friday) AS Friday
					, SUM(A.Time_Today_SubTotal) AS SubTotal
					FROM 
						(SELECT Red_Daily_Work_Category
							, SUM(Red_Daily_Work_Time_Today) AS Time_Today_SubTotal
							FROM Red.Red_Daily_Work
							WHERE 1 = 1
								AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																					AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
								AND Red_Daily_Work_Category LIKE 'WT%'
							GROUP BY Red_Daily_Work_Category
						) A 
						LEFT JOIN
							(SELECT Red_Daily_Work_Category
								, SUM(Red_Daily_Work_Time_Today) AS Time_Today_Monday
								FROM Red.Red_Daily_Work
								WHERE 1 = 1
									AND DATENAME(DW,Red_Daily_Work_Record_Date) = 'Monday'
									AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																						AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
									AND Red_Daily_Work_Category LIKE 'WT%'
								GROUP BY Red_Daily_Work_Category
							) Monday ON A.Red_Daily_Work_Category = Monday.Red_Daily_Work_Category
						LEFT JOIN
							(SELECT Red_Daily_Work_Category
								, SUM(Red_Daily_Work_Time_Today) AS Time_Today_Tuesday
								FROM Red.Red_Daily_Work
								WHERE 1 = 1
									AND DATENAME(DW,Red_Daily_Work_Record_Date) = 'Tuesday'
									AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																						AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
									AND Red_Daily_Work_Category LIKE 'WT%'
								GROUP BY Red_Daily_Work_Category
							) Tuesday ON A.Red_Daily_Work_Category = Tuesday.Red_Daily_Work_Category
						LEFT JOIN
							(SELECT Red_Daily_Work_Category
								, SUM(Red_Daily_Work_Time_Today) AS Time_Today_Wednesday
								FROM Red.Red_Daily_Work
								WHERE 1 = 1
									AND DATENAME(DW,Red_Daily_Work_Record_Date) = 'Wednesday'
									AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																						AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
									AND Red_Daily_Work_Category LIKE 'WT%'
								GROUP BY Red_Daily_Work_Category
							) Wednesday ON A.Red_Daily_Work_Category = Wednesday.Red_Daily_Work_Category
						LEFT JOIN
							(SELECT Red_Daily_Work_Category
								, SUM(Red_Daily_Work_Time_Today) AS Time_Today_Thursday
								FROM Red.Red_Daily_Work
								WHERE 1 = 1
									AND DATENAME(DW,Red_Daily_Work_Record_Date) = 'Thursday'
									AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																						AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
									AND Red_Daily_Work_Category LIKE 'WT%'
								GROUP BY Red_Daily_Work_Category
							) Thursday ON A.Red_Daily_Work_Category = Thursday.Red_Daily_Work_Category
						LEFT JOIN
							(SELECT Red_Daily_Work_Category
								, SUM(Red_Daily_Work_Time_Today) AS Time_Today_Friday
								FROM Red.Red_Daily_Work
								WHERE 1 = 1
									AND DATENAME(DW,Red_Daily_Work_Record_Date) = 'Friday'
									AND CONVERT(DATE,Red_Daily_Work_Record_Date,101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1)
																						AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6)
									AND Red_Daily_Work_Category LIKE 'WT%'
								GROUP BY Red_Daily_Work_Category
							) Friday ON A.Red_Daily_Work_Category = Friday.Red_Daily_Work_Category
				) A
		) A
	ORDER BY Row_Order, SubTotal DESC
