USE [pandamidb]
GO
DELETE FROM [dbo].[reponse]
GO
INSERT [dbo].[reponse] ([id_reponse], [id_utilisateur], [id_demande], [date_reponse], [date_acceptation], [date_refus], [date_annulation_participation]) VALUES (1, 3, 2, CAST(N'2021-01-26T00:00:00.000' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[reponse] ([id_reponse], [id_utilisateur], [id_demande], [date_reponse], [date_acceptation], [date_refus], [date_annulation_participation]) VALUES (2, 2, 1, CAST(N'2021-01-26T00:00:00.000' AS DateTime), NULL, NULL, NULL)
GO
