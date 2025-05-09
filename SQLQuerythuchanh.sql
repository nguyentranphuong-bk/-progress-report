USE UserDB;
GO

SELECT TABLE_NAME 
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';

SELECT * FROM tbluser;
DELETE FROM tbluser WHERE Id = 4;
DELETE FROM tbluser;
SELECT * FROM tbluser WHERE Username = 'bankphuong123';
UPDATE tbluser SET Status = 1 WHERE Username = 'bankphuong123';
