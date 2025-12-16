CREATE TABLE Companies (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Name NVARCHAR(MAX),
    Email NVARCHAR(MAX) NOT NULL,
    Website NVARCHAR(MAX),
    Phone NVARCHAR(MAX),
    Logo VARBINARY(MAX),
    About NVARCHAR(MAX),
    Vision NVARCHAR(MAX),
    Mission NVARCHAR(MAX),
    Location NVARCHAR(MAX),
    Address NVARCHAR(MAX),
    Status NVARCHAR(MAX),
    CreatedDate DATETIME2
);

CREATE TABLE Users (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    FirstName NVARCHAR(MAX),
    LastName NVARCHAR(MAX),
    Email NVARCHAR(MAX) NOT NULL,
    Gender NVARCHAR(MAX),
    Location NVARCHAR(MAX),
    Phone NVARCHAR(MAX),
    password NVARCHAR(MAX),
    Roles INT CHECK (Roles IN (0, 1, 2)),  -- Enum constraint: 0 = JobSeeker, 1 = JobProvider, 2 = Admin
    About NVARCHAR(MAX),
    Designation NVARCHAR(MAX),
    CompanyId UNIQUEIDENTIFIER,
    Status NVARCHAR(MAX),
    Image VARBINARY(MAX),
    CreatedDate DATETIME2,
    CONSTRAINT FK_Users_Companies_CompanyId FOREIGN KEY (CompanyId) REFERENCES Companies(Id)
);


CREATE TABLE Jobs (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Title NVARCHAR(MAX),
    Description NVARCHAR(MAX),
    Location NVARCHAR(MAX),
    Experience NVARCHAR(MAX),
    TypeOfWorkPlace NVARCHAR(MAX),
    Salary NVARCHAR(MAX),
    Responsibilities NVARCHAR(MAX),
    JobType NVARCHAR(MAX),
    VacanciesCount INT,
    AppliedCount INT,
    Status NVARCHAR(MAX),
    CompanyId UNIQUEIDENTIFIER,
    CreatedDate DATETIME2,
    UpdatedDate DATETIME2,
    CreatedBy UNIQUEIDENTIFIER,
    CONSTRAINT FK_Jobs_Companies_CompanyId FOREIGN KEY (CompanyId) REFERENCES Companies(Id),
    CONSTRAINT FK_Jobs_Users_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES Users(Id)
);

CREATE TABLE Applications (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    UserId UNIQUEIDENTIFIER,
    JobId UNIQUEIDENTIFIER,
    CompanyId UNIQUEIDENTIFIER,
    AppliedDate DATETIME2,
    Status NVARCHAR(MAX),
    CONSTRAINT FK_Applications_Users_UserId FOREIGN KEY (UserId) REFERENCES Users(Id),
    CONSTRAINT FK_Applications_Jobs_JobId FOREIGN KEY (JobId) REFERENCES Jobs(Id),
    CONSTRAINT FK_Applications_Companies_CompanyId FOREIGN KEY (CompanyId) REFERENCES Companies(Id)
);

CREATE TABLE Interviews (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    JobId UNIQUEIDENTIFIER,
    CompanyId UNIQUEIDENTIFIER,
    Date DATETIME2,
    Time TIME,
    Location NVARCHAR(MAX),
    Status NVARCHAR(MAX),
    CreatedDate DATETIME2,
    CONSTRAINT FK_Interviews_Jobs_JobId FOREIGN KEY (JobId) REFERENCES Jobs(Id),
    CONSTRAINT FK_Interviews_Companies_CompanyId FOREIGN KEY (CompanyId) REFERENCES Companies(Id)
);

CREATE TABLE Experiences (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    UserId UNIQUEIDENTIFIER,
    JobTitle NVARCHAR(MAX),
    Company NVARCHAR(MAX),
    Duration NVARCHAR(MAX),
    Year NVARCHAR(MAX),
    CONSTRAINT FK_Experiences_Users_UserId FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE Qualifications (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    UserId UNIQUEIDENTIFIER NOT NULL,
    Title NVARCHAR(MAX),
    Mark NVARCHAR(MAX),
    YearOfPassout NVARCHAR(MAX),
    University NVARCHAR(MAX),
    Status NVARCHAR(MAX),
    CONSTRAINT FK_Qualifications_Users_UserId FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE Skills (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    UserId UNIQUEIDENTIFIER NOT NULL,
    Title NVARCHAR(MAX),
    Status NVARCHAR(MAX),
    CONSTRAINT FK_Skills_Users_UserId FOREIGN KEY (UserId) REFERENCES Users(Id)
);
