# Contact Manager

Synopsis
Build a very simple contact management MVC application using C#.
This is Entity Framework 6 Code First using MVC 5 web application.
Applications
-	Visual Studio 2017 (C# .Net 4.5)
-	SQL Server 2012
Setup
After running the project, it will create 1 database and 2 tables.
DB: ContactDB
Tables: ContactDB and ContactViewAudit
 
Then run DBscript in DbScript.txt  on master DB, it will create 2 triggers and 1 stored procedure.
Trigger:  AuditDeleteTrigger and AuditUpdateTrigger
Stored Procedure: Audit_Retrieve 
 
UI elements: list, search, create, edit and delete
 
*****************************************************************************************
Db Script - Please run this db script on sql after you run web application at first time 
*****************************************************************************************
USE [ContactDB]; 
GO


CREATE TRIGGER [dbo].[AuditUpdateTrigger] 
   ON  [dbo].[ContactModel] 
   AFTER UPDATE
AS 
BEGIN
	
	INSERT INTO ContactViewAudit
	(ContactID, LastUpdateDateTime, TransactionType)
	select i.ContactID, getdate(), 'UPDATED'
	from ContactModel t
	inner join inserted i on t.ContactID=i.ContactID

END
GO


CREATE TRIGGER [dbo].[AuditDeleteTrigger] 
   ON  [dbo].[ContactModel] 
   AFTER DELETE
AS 
BEGIN
	
	INSERT INTO ContactViewAudit
	(ContactID, LastUpdateDateTime, TransactionType)
	SELECT (SELECT deleted.ContactID FROM deleted), getdate(), 'DELETED'

END
GO


CREATE PROCEDURE [dbo].[Audit_Retrieve] 
@ContactID	int	
AS
BEGIN
	
    SET NOCOUNT ON;

    SELECT ContactID, numberOfChanges = count(ContactID),
           LastUpdateDateTime = (select top 1 LastUpdateDateTime from [ContactDB].[dbo].[ContactViewAudit] A order by LastUpdateDateTime desc) 
     FROM [ContactDB].[dbo].[ContactViewAudit] B
     WHERE ContactID = @ContactID
     GROUP BY ContactID
END
GO
**********************************************************************************************

