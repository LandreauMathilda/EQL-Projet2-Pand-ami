USE [pandamidb]
GO

/****** Object:  Table [dbo].[reponse]    Script Date: 26/01/2021 11:02:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[reponse](
	[id_reponse] [int] NOT NULL,
	[id_utilisateur] [int] NULL,
	[id_demande] [int] NULL,
	[date_reponse] [datetime] NULL,
	[date_acceptation] [datetime] NULL,
	[date_refus] [datetime] NULL,
	[date_annulation_participation] [datetime] NULL,
 CONSTRAINT [PK_reponse] PRIMARY KEY CLUSTERED 
(
	[id_reponse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[reponse]  WITH CHECK ADD  CONSTRAINT [FK_reponse_demande_service] FOREIGN KEY([id_demande])
REFERENCES [dbo].[demande_service] ([id_demande])
GO

ALTER TABLE [dbo].[reponse] CHECK CONSTRAINT [FK_reponse_demande_service]
GO

ALTER TABLE [dbo].[reponse]  WITH CHECK ADD  CONSTRAINT [FK_reponse_reponse] FOREIGN KEY([id_utilisateur])
REFERENCES [dbo].[utilisateur] ([id_utilisateur])
GO

ALTER TABLE [dbo].[reponse] CHECK CONSTRAINT [FK_reponse_reponse]
GO

