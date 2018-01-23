/****************************************************

	Name: Red_Daily_Work
	Date: 12/22/17

****************************************************/

DROP TABLE IF EXISTS Red.Red_Daily_Work;

CREATE TABLE Red.Red_Daily_Work (
	Red_Daily_Work_Key BIGINT IDENTITY (10000, 1)
	, Red_Daily_Work_Record_Date DATE
	, Red_Daily_Work_Name NVARCHAR(100)		
	, Red_Daily_Work_Category NVARCHAR(100)	
	, Red_Daily_Work_Time_Today DECIMAL(10,2) 	
	, Red_Daily_Work_TFS_Number BIGINT
	, Red_Daily_Work_Sprint NVARCHAR(100)
	, Red_Daily_Work_Type_Of_Ticket NVARCHAR(100)
	, Red_Daily_Work_Beginning_Of_Day_State NVARCHAR(100)
	, Red_Daily_Work_Ending_Of_Day_State NVARCHAR(100)
	, Red_Daily_Work_Business_Priority_For_Today INT	
	, Red_Daily_Work_Notes NVARCHAR(MAX)
	, Red_Daily_Work_Insert_Date DATETIME
	, Red_Daily_Work_Update_Date DATETIME
)


DROP TABLE IF EXISTS Red.Red_Daily_Work_bu;

CREATE TABLE Red.Red_Daily_Work_bu (
	Red_Daily_Work_Key BIGINT IDENTITY (10000, 1)
	, Red_Daily_Work_Record_Date DATE
	, Red_Daily_Work_Name NVARCHAR(100)		
	, Red_Daily_Work_Category NVARCHAR(100)	
	, Red_Daily_Work_Time_Today DECIMAL(10,2) 	
	, Red_Daily_Work_TFS_Number BIGINT
	, Red_Daily_Work_Sprint NVARCHAR(100)
	, Red_Daily_Work_Type_Of_Ticket NVARCHAR(100)
	, Red_Daily_Work_Beginning_Of_Day_State NVARCHAR(100)
	, Red_Daily_Work_Ending_Of_Day_State NVARCHAR(100)
	, Red_Daily_Work_Business_Priority_For_Today INT	
	, Red_Daily_Work_Notes NVARCHAR(MAX)
	, Red_Daily_Work_Insert_Date DATETIME
	, Red_Daily_Work_Update_Date DATETIME
)