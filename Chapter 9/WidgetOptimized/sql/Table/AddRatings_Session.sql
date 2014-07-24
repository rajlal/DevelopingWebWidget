/****** Object:  Table [dbo].[AddRatings_Session]    Script Date: 10/20/2008 1:28:33 AM ******/
CREATE TABLE [AddRatings_Session] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[RatingID] [int] NULL ,
	[IPAddress] [nvarchar] (16) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DateAdded] [datetime] NULL CONSTRAINT [DF_AddRatingsSession_DateAdded] DEFAULT (getdate()),
	CONSTRAINT [PK_AddRatings_Session] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO


