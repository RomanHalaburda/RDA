USE [RepublicDatabaseAutoservice]
GO
/****** Object:  Trigger [dbo].[tg_ChangeWorkCost]    Script Date: 15.06.2017 18:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[tg_ChangeWorkCost] 
   ON [dbo].[WorkOn]  
   AFTER UPDATE
AS IF UPDATE([workon_cost]) 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @cost_old FLOAT
	DECLARE @cost_new FLOAT
	DECLARE @id_work INT	
	DECLARE @id_service INT
	SELECT @cost_old = (SELECT [workon_cost] FROM deleted)
	SELECT @cost_new = (SELECT [workon_cost] FROM inserted)
	SELECT @id_work = (SELECT [work_id] FROM deleted)
	SELECT @id_service = (SELECT [service_id] FROM deleted)
	INSERT 
		INTO cost_changes 
		VALUES (@id_work,@id_service,USER_NAME(), GETDATE(), @cost_old, @cost_new) 

END
