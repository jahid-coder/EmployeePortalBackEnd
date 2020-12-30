IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('Employees'))
BEGIN
	CREATE TABLE [dbo].Employees(
		employee_id INT IDENTITY(1,1) NOT NULL,
		employee_name VARCHAR(256) NULL,
		department VARCHAR(256) NULL,
		mail_id VARCHAR(256) NULL,
		doj date
	)
END
GO