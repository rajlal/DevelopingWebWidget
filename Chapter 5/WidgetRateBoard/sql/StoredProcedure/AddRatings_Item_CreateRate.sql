SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure protrack.AddRatings_Item_CreateRate    Script Date: 10/20/2008 1:30:14 AM ******/

CREATE  PROCEDURE AddRatings_Item_CreateRate
 @Title		 NVARCHAR(255),
 @URL 	 NVARCHAR(255)

AS

IF NOT EXISTS (SELECT Id FROM AddRatings WHERE URL = @URL)
BEGIN
	INSERT AddRatings
	(
		Title,
		URL
	) 
	VALUES
	(
		@Title,
		@URL
	)
 	RETURN @@IDENTITY
END
ELSE
  RETURN 1

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

