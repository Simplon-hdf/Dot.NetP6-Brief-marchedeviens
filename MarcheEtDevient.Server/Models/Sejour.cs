using System;
using System.Collections.Generic;

namespace MarcheEtDevient.Server.Models;

public partial class Sejour
{
    public string IdSejour { get; set; } = null!;

    public string? NomSejour { get; set; }

    public string? Descriptif { get; set; }

    public DateOnly? DateDebutSejour { get; set; }

    public DateOnly? DateFinSejour { get; set; }

    public string? NomLieuSejour { get; set; }

    public decimal? PrixSejour { get; set; }

    public string? TypeSejour { get; set; }

    public int? TotalParticipant { get; set; }
}
