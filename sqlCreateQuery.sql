

CREATE TABLE [dbo].[tblAlbum](
	[AlbumID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[ReleaseDate] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL
)


CREATE TABLE [dbo].[tblArtist](
	[ArtistID] [bigint] IDENTITY(1,1) Primary Key NOT NULL,
	[genre] [nvarchar](100) NULL,
	[popularity] [nvarchar](500) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[Name] [nvarchar](200) NULL
)

CREATE TABLE [dbo].[tblPlaylist](
	[PlaylistID] [bigint] IDENTITY(1,1) Primary Key NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](500) NULL,
	[TrackID] [bigint] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	CONSTRAINT [FK_tblTrack_TrackID] FOREIGN KEY([TrackID]) REFERENCES [dbo].[tblTrack] ([TrackID])
)

CREATE TABLE [dbo].[tblTrack](
	[TrackID] [bigint] IDENTITY(1,1) Primary Key NOT NULL,
	[Title] [nvarchar](100) NULL,
	[duration] [nvarchar](500) NULL,
	[genre] [nvarchar](500) NULL,
	[popularity] [nvarchar](500) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ArtistID] [bigint] NULL,
	[AlbumID] [bigint] NULL

CONSTRAINT [FK_tblTrack_AlbumID] FOREIGN KEY([AlbumID])
REFERENCES [dbo].[tblAlbum] ([AlbumID]),

CONSTRAINT [FK_tblTrack_ArtistID] FOREIGN KEY([ArtistID])
REFERENCES [dbo].[tblArtist] ([ArtistID]),

)
