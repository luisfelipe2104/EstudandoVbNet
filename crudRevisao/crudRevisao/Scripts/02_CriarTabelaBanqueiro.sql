IF OBJECT_ID('dbo.Banqueiro', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Banqueiro
    (
        Id    INT IDENTITY(1,1) NOT NULL,
        Nome  NVARCHAR(150)     NOT NULL,
        Sigla NVARCHAR(20)      NOT NULL,
        Ativo BIT               NOT NULL CONSTRAINT DF_Banqueiro_Ativo DEFAULT (1),

        CONSTRAINT PK_Banqueiro PRIMARY KEY (Id)
    );
END
GO
