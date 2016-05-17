CREATE TABLE [dbo].[Course] (
    [CourseId]  UNIQUEIDENTIFIER NOT NULL,
    [Name]      NVARCHAR (100)   NOT NULL,
    [Url]       NVARCHAR (250)   NULL,
    [Zip]       NVARCHAR (10)    NULL,
    [Latitude]  NVARCHAR (50)    NULL,
    [Longitude] NVARCHAR (50)    NULL,
    [Par]       INT              NULL,
    [Rating]    NUMERIC (18, 1)  NULL,
    [Slope]     INT              NULL,
    [CourseNum] INT              NULL,
    CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED ([CourseId] ASC)
);

