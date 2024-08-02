using System;
using System.Collections.Generic;
using MarcheEtDevient.Server.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace MarcheEtDevient.Server.Data;

public partial class ApiDBContext : DbContext
{
    public ApiDBContext()
    {
    }

    public ApiDBContext(DbContextOptions<ApiDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppartenirGalerie> AppartenirGaleries { get; set; }

    public virtual DbSet<ContenuPublie> ContenuPublies { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<PublicationActu> PublicationActus { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Sejour> Sejours { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;database=marche_devient_ddb;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.3.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AppartenirGalerie>(entity =>
        {
            entity.HasKey(e => new { e.IdSejour, e.IdPhoto })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("appartenir_galerie");

            entity.HasIndex(e => e.IdPhoto, "id_photo");

            entity.Property(e => e.IdSejour)
                .HasMaxLength(50)
                .HasColumnName("id_sejour");
            entity.Property(e => e.IdPhoto)
                .HasMaxLength(50)
                .HasColumnName("id_photo");
        });

        modelBuilder.Entity<ContenuPublie>(entity =>
        {
            entity.HasKey(e => e.IdPublication).HasName("PRIMARY");

            entity.ToTable("contenu_publie");

            entity.Property(e => e.IdPublication)
                .HasMaxLength(50)
                .HasColumnName("id_publication");
            entity.Property(e => e.Commentaire)
                .HasMaxLength(50)
                .HasColumnName("commentaire");
            entity.Property(e => e.DateCslv).HasColumnName("date_cslv");
            entity.Property(e => e.Theme)
                .HasMaxLength(50)
                .HasColumnName("theme");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.IdPhoto).HasName("PRIMARY");

            entity.ToTable("photo");

            entity.Property(e => e.IdPhoto)
                .HasMaxLength(50)
                .HasColumnName("id_photo");
            entity.Property(e => e.DatePhoto).HasColumnName("date_photo");
            entity.Property(e => e.EstPublique)
                .HasColumnType("bit(1)")
                .HasColumnName("est_publique");
            entity.Property(e => e.Photo1)
                .HasColumnType("blob")
                .HasColumnName("Photo");
        });

        modelBuilder.Entity<PublicationActu>(entity =>
        {
            entity.HasKey(e => e.IdPublicationActu).HasName("PRIMARY");

            entity.ToTable("publication_actu");

            entity.HasIndex(e => e.IdPublication, "id_publication").IsUnique();

            entity.HasIndex(e => e.IdVideo, "id_video").IsUnique();

            entity.Property(e => e.IdPublicationActu)
                .HasMaxLength(50)
                .HasColumnName("Id_Publication_Actu");
            entity.Property(e => e.DatePublication).HasColumnName("date_publication");
            entity.Property(e => e.IdPublication)
                .HasMaxLength(50)
                .HasColumnName("id_publication");
            entity.Property(e => e.IdVideo)
                .HasMaxLength(50)
                .HasColumnName("id_video");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => new { e.IdUtilisateur, e.IdSejour })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("reservation");

            entity.HasIndex(e => e.IdSejour, "id_sejour");

            entity.Property(e => e.IdUtilisateur)
                .HasMaxLength(50)
                .HasColumnName("Id_Utilisateur");
            entity.Property(e => e.IdSejour)
                .HasMaxLength(50)
                .HasColumnName("id_sejour");
            entity.Property(e => e.DatePaiement).HasColumnName("date_paiement");
            entity.Property(e => e.MaxParticipant).HasColumnName("max_participant");
            entity.Property(e => e.MinParticipant).HasColumnName("min_participant");
            entity.Property(e => e.NombrePlacesDemandee).HasColumnName("nombre_places_demandee");
            entity.Property(e => e.NumeroReservation)
                .HasMaxLength(50)
                .HasColumnName("numero_reservation");
            entity.Property(e => e.TotalReservation)
                .HasMaxLength(50)
                .HasColumnName("total_reservation");
            entity.Property(e => e.ValidationReservation)
                .HasColumnType("bit(1)")
                .HasColumnName("validation_reservation");
        });

        modelBuilder.Entity<Sejour>(entity =>
        {
            entity.HasKey(e => e.IdSejour).HasName("PRIMARY");

            entity.ToTable("sejour");

            entity.Property(e => e.IdSejour)
                .HasMaxLength(50)
                .HasColumnName("id_sejour");
            entity.Property(e => e.DateDebutSejour).HasColumnName("date_debut_sejour");
            entity.Property(e => e.DateFinSejour).HasColumnName("date_fin_sejour");
            entity.Property(e => e.Descriptif)
                .HasMaxLength(50)
                .HasColumnName("descriptif");
            entity.Property(e => e.NomLieuSejour)
                .HasMaxLength(50)
                .HasColumnName("nom_lieu_sejour");
            entity.Property(e => e.NomSejour)
                .HasMaxLength(50)
                .HasColumnName("nom_sejour");
            entity.Property(e => e.PrixSejour)
                .HasPrecision(15, 2)
                .HasColumnName("prix_sejour");
            entity.Property(e => e.TotalParticipant).HasColumnName("total_participant");
            entity.Property(e => e.TypeSejour)
                .HasMaxLength(50)
                .HasColumnName("type_sejour");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.IdUtilisateur).HasName("PRIMARY");

            entity.ToTable("utilisateur");

            entity.Property(e => e.IdUtilisateur)
                .HasMaxLength(50)
                .HasColumnName("Id_Utilisateur");
            entity.Property(e => e.AgeUtilisateur)
                .HasMaxLength(50)
                .HasColumnName("age_utilisateur");
            entity.Property(e => e.MailUtilisateur)
                .HasMaxLength(50)
                .HasColumnName("mail_utilisateur");
            entity.Property(e => e.MdpUtilisateur)
                .HasMaxLength(50)
                .HasColumnName("mdp_utilisateur");
            entity.Property(e => e.NomUtilisateur)
                .HasMaxLength(50)
                .HasColumnName("nom_utilisateur");
            entity.Property(e => e.PermissionUtilisateur)
                .HasMaxLength(50)
                .HasColumnName("permission_utilisateur");
            entity.Property(e => e.PrenomUtilisateur)
                .HasMaxLength(50)
                .HasColumnName("prenom_utilisateur");
            entity.Property(e => e.TelUtilisateur)
                .HasMaxLength(50)
                .HasColumnName("tel_utilisateur");
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(e => e.IdVideo).HasName("PRIMARY");

            entity.ToTable("video");

            entity.HasIndex(e => e.IdSejour, "id_sejour");

            entity.Property(e => e.IdVideo)
                .HasMaxLength(50)
                .HasColumnName("id_video");
            entity.Property(e => e.DateSortie).HasColumnName("date_sortie");
            entity.Property(e => e.IdSejour)
                .HasMaxLength(50)
                .HasColumnName("id_sejour");
            entity.Property(e => e.LienVideo)
                .HasMaxLength(50)
                .HasColumnName("lien_video");
            entity.Property(e => e.TitreVideo)
                .HasMaxLength(50)
                .HasColumnName("titre_video");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
