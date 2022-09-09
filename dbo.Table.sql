CREATE TABLE [dbo].[FinalDesignTable] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Aircraft Type] VARCHAR (50)  NULL,
    [Manufacturer]  VARCHAR (50)  NULL,
    [Serial Number] VARCHAR (50)  NULL,
    [PDF path]      VARCHAR (500) NULL,
    [Native Path]   VARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

