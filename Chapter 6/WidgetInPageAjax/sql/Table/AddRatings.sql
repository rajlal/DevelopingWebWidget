/****** Object:  Table [protrack].[AddRatings]    Script Date: 10/20/2008 1:27:27 AM ******/
CREATE TABLE [AddRatings] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[URL] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Title] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[RatedBy] [int] NULL CONSTRAINT [DF_AddRatings_RatedBy] DEFAULT (0),
	[Score] [int] NULL CONSTRAINT [DF_AddRatings_Score] DEFAULT (0),
	[Star5] [int] NULL CONSTRAINT [DF_AddRatings_Star5] DEFAULT (0),
	[Star4] [int] NULL CONSTRAINT [DF_AddRatings_Star4] DEFAULT (0),
	[Star3] [int] NULL CONSTRAINT [DF_AddRatings_Star3] DEFAULT (0),
	[Star2] [int] NULL CONSTRAINT [DF_AddRatings_Star2] DEFAULT (0),
	[Star1] [int] NULL CONSTRAINT [DF_AddRatings_Star1] DEFAULT (0),
	[StarType] [int] NULL CONSTRAINT [DF_AddRatings_StarType] DEFAULT (0),
	[DateAdded] [datetime] NULL CONSTRAINT [DF_AddRatings_DateAdded] DEFAULT (getdate()),
	[DateModified] [datetime] NULL CONSTRAINT [DF_AddRatings_DateModified] DEFAULT (getdate()),
	CONSTRAINT [PK_AddRatings] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO


