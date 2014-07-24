SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure protrack.AddRatings_Session_Item_Create    Script Date: 10/20/2008 1:30:28 AM ******/

CREATE  PROCEDURE AddRatings_Session_Item_Create
 @IPAddress NVARCHAR(16),
 @RatingID  INT

AS

IF NOT EXISTS (SELECT Id FROM AddRatings_Session WHERE RatingID = @RatingID and IPAddress=@IPAddress )
BEGIN
	INSERT AddRatings_Session
	(
		RatingID,
		IPAddress
	) 
	VALUES
	(
		@RatingID,
		@IPAddress
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

