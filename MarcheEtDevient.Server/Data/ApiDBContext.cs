using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MarcheEtDevient.Server.Models;
using MarcheEtDevient.Server.ModelsDTO;

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

    public virtual DbSet<ContenuPublie> ContenuPublie { get; set; }

    public virtual DbSet<Photo> Photo { get; set; }

    public virtual DbSet<Publication> Publication { get; set; }

    public virtual DbSet<Reserver> Reserver { get; set; }

    public virtual DbSet<Sejour> Sejour { get; set; }

    public virtual DbSet<Utilisateur> Utilisateur { get; set; }

    public virtual DbSet<Video> Video { get; set; }
}