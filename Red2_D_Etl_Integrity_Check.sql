/****************************************************

	Name: Red_Etl_Integrity_Check
	Date: 01/04/2018
	
	SELECT Check_Name
		, Error_Cnt
		FROM Red.Red_Etl_Integrity_Check

****************************************************/

DROP TABLE IF EXISTS Red.Red_Etl_Integrity_Check;

CREATE TABLE Red.Red_Etl_Integrity_Check (
	Check_Name NVARCHAR(100)
	, Error_Cnt INT
)

INSERT INTO Red.Red_Etl_Integrity_Check (
	Check_Name
	, Error_Cnt
)
SELECT 'New_EmailBase - Orphans' AS Check_Name
	, COUNT(*) AS Error_Cnt
	FROM Check_New_EmailBase_Orphans
UNION
SELECT 'New_AddressBase - New_Confidential' AS Check_Name
	, COUNT(*) AS Error_Cnt
	FROM Check_New_AddressBase_New_Confidential
UNION
SELECT 'New_AddressBase - Orphans' AS Check_Name
	, COUNT(*) AS Error_Cnt
	FROM Check_New_AddressBase_Orphans
UNION
SELECT 'New_PhoneBase - Orphans' AS Check_Name
	, COUNT(*) AS Error_Cnt
	FROM Check_New_PhoneBase_Orphans
UNION
SELECT 'New_StudentAttendanceBase - Orphans' AS Check_Name
	, COUNT(*) AS Error_Cnt
	FROM Check_New_StudentAttendanceBase_Orphans
UNION
SELECT 'New_PhoneBase - Invalid Phones' AS Check_Name
	, COUNT(*) AS Error_Cnt
	FROM Check_New_PhoneBase_Invalid_Phones
UNION
SELECT 'New_EmailBase - Invalid Emails' AS Check_Name
	, COUNT(*) AS Error_Cnt
	FROM Check_New_EmailBase_Invalid_Emails
UNION
SELECT 'Plus_AlumniBase - Plus_Constituent' AS Check_Name
	, COUNT(*) AS Error_Cnt
	FROM Check_Plus_AlumniBase_Plus_Constituent
UNION
SELECT 'New_StudentAttendanceBase - New_Term' AS Check_Name
	, COUNT(*) AS Error_Cnt
	FROM Check_New_StudentAttendanceBase_New_Term
UNION
SELECT 'AccountBase - AccountId' AS Check_Name
	, COUNT(*) AS Error_Cnt
	FROM Check_AccountBase_AccountId
UNION
SELECT 'AccountBase - New_LdspId' AS Check_Name
	, COUNT(*) AS Error_Cnt
	FROM Check_AccountBase_New_LdspId
UNION
SELECT 'New_StudentAttendanceBase - Plus_Year' AS Check_Name
	, COUNT(*) AS Error_Cnt
	FROM Check_New_StudentAttendanceBase_Plus_Year

