CREATE TABLE [dbo].[cart]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [fruit_id] INT NOT NULL, 
    [user_id] INT NOT NULL
)
