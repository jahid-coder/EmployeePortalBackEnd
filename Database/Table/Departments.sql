IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('Departments'))
BEGIN
	CREATE TABLE [dbo].Departments(
		department_id INT IDENTITY(1,1) NOT NULL,
		department_name VARCHAR(256) NULL,
	)
END
GO