using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using WebApplication1.Models;

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

    public virtual DbSet<ContenuPublie> ContenuPublies { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Publication> Publications { get; set; }

    public virtual DbSet<Reserver> Reservers { get; set; }

    public virtual DbSet<Sejour> Sejours { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    public virtual DbSet<Video> Videos { get; set; }
}