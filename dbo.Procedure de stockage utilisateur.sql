Create procedure[dbo].[AjoutUtilisateur]
 (         
 @Nom                     NVARCHAR(30),
 @Prenom                 NVARCHAR(30),
 @Id_genre                INT,           
 @Date_naissance         DATE ,         
 @Adresse                NVARCHAR(70), 
 @Id_ville                INT ,         
 @Num_telephone         NCHAR (10),   
  @Email                   NVARCHAR (50) ,
  @Date_inscription        DATE          ,
  @Date_desinscription    DATE          ,
  @Id_motif_desinscription INT          
)
as
begin
Insert into dbo.utilisateur values(@Nom,@Prenom,@Id_genre,@Date_naissance,@Adresse,@Id_ville,@Num_telephone,@Email,@Date_inscription,@Date_desinscription,@Id_motif_desinscription)
end