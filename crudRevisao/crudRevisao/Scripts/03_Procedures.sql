

CREATE OR ALTER PROCEDURE dbo.p_BaqueiroAtivo_Sel 
    @Nome VARCHAR(100) = NULL
  AS
  BEGIN 
    SET NOCOUNT ON;
    SELECT [Id]
          ,[Nome]
          ,[Sigla]
          ,[Ativo]
      FROM [MeuBanco].[dbo].[Banqueiro]
      WHERE Nome LIKE '%' + @Nome + '%'

  END

EXEC p_BaqueiroAtivo_Sel ''