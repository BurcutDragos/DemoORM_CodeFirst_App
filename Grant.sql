-- Create the stored procedure
CREATE PROCEDURE dbo.CreateAppPoolUsersAndAssignRole
AS
BEGIN
    DECLARE @appPoolUsers TABLE (UserName NVARCHAR(100));
    INSERT INTO @appPoolUsers VALUES ('IIS APPPOOL\PDFtoWordMVC'), ('IIS APPPOOL\PDFtoWordAPI');

    DECLARE @userName NVARCHAR(100);

    DECLARE AppPoolUsersCursor CURSOR FOR
    SELECT UserName FROM @appPoolUsers;

    OPEN AppPoolUsersCursor;
    FETCH NEXT FROM AppPoolUsersCursor INTO @userName;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = @userName)
        BEGIN
            DECLARE @loginCommand NVARCHAR(MAX) = 
                'CREATE LOGIN [' + @userName + '] ' +
                'FROM WINDOWS WITH DEFAULT_DATABASE=[master], ' +
                'DEFAULT_LANGUAGE=[us_english]';

            EXEC sp_executesql @loginCommand;
        END

        IF EXISTS (SELECT name FROM sys.server_principals WHERE name = @userName)
        BEGIN
            EXEC sp_addrolemember 'db_owner', @userName;
        END

        FETCH NEXT FROM AppPoolUsersCursor INTO @userName;
    END

    CLOSE AppPoolUsersCursor;
    DEALLOCATE AppPoolUsersCursor;
END
GO

-- Execute the stored procedure
EXEC dbo.CreateAppPoolUsersAndAssignRole;
