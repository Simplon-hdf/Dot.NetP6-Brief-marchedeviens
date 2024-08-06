using MarcheEtDevient.Server.Models;
using Microsoft.EntityFrameworkCore;


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

    public virtual DbSet<AppartenirGalerie> Appartenir_Galerie { get; set; }

    public virtual DbSet<ContenuPublie> Contenu_Publie { get; set; }

    public virtual DbSet<Photo> Photo { get; set; }

    public virtual DbSet<PublicationActu> Publication_Actu { get; set; }

    public virtual DbSet<Reservation> Reservation { get; set; }

    public virtual DbSet<Sejour> Sejour { get; set; }

    public virtual DbSet<Utilisateur> Utilisateur { get; set; }

    public virtual DbSet<Video> Video { get; set; }
}

