CREATE OR ALTER PROCEDURE [dbo].[sp_UpdateInsctructor]
    @InstructorId INT,
    @Email NVARCHAR(255)
    AS
    BEGIN

       update INSTRUCTORS
       set Email = @Email
       where InstructorID = @InstructorId
    END

GO

CREATE OR ALTER PROCEDURE [dbo].[sp_AddInsctructor]
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email NVARCHAR(255)
    AS
    BEGIN

       INSERT INTO INSTRUCTORS (FirstName, LastName, Email)
       VALUES (@FirstName, @LastName, @Email)
    END