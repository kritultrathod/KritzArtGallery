CREATE TABLE [dbo].[ArtDetails] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [Name]           VARCHAR (100) NOT NULL,
    [Artist]         VARCHAR (50)  NOT NULL,
    [DimInch]        VARCHAR (15)  NOT NULL,
    [DimCm]          VARCHAR (15)  NOT NULL,
    [Description]    VARCHAR (500) NOT NULL,
    [Price]          FLOAT (53)    NOT NULL,
    [Private]        BIT           NOT NULL,
    [Available]      BIT           NOT NULL,
    [SendAFriend]    BIT           NOT NULL,
    [ImageSmall]     VARCHAR (200) NOT NULL,
    [ImageLarge]     VARCHAR (200) NOT NULL,
    [LastModifiedOn] DATETIME      NOT NULL,
    [Height]         DECIMAL (18)  NULL,
    [Width]          DECIMAL (18)  NULL
);

