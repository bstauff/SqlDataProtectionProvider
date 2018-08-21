CREATE TABLE [dbo].[DataProtectionKeys]
(
    [Id] INT NOT NULL PRIMARY KEY,
    [Name] nvarchar(max) NOT NULL,
    [XmlData] nvarchar(max) NULL
)
