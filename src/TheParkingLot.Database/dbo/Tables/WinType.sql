CREATE TABLE [dbo].[WinType] (
    [WinTypeId]   UNIQUEIDENTIFIER NOT NULL,
    [WinTypeCode] NVARCHAR (5)     NOT NULL,
    [Name]        NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_WinType] PRIMARY KEY CLUSTERED ([WinTypeId] ASC)
);

