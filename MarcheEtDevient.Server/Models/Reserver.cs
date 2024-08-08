using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Reserver
{
    public int IdUtilisateur { get; set; }

    public int IdSejour { get; set; }

    public int IdReserver { get; set; }

    public short NombrePlaceReserver { get; set; }

    public bool? ValidationReserver { get; set; }

    public DateTime? DatePaiementReserver { get; set; }
}
