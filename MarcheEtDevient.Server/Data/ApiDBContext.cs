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

    public virtual DbSet<AppartenirGalerie> AppartenirGaleries { get; set; }

    public virtual DbSet<ContenuPublie> ContenuPublies { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<PublicationActu> PublicationActus { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Sejour> Sejours { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    public virtual DbSet<Video> Videos { get; set; }
}

