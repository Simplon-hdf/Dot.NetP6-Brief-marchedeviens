using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Sejour
{
    public int IdSejour { get; set; }

    public string NomSejour { get; set; } = null!;

    public string DescriptifSejour { get; set; } = null!;

    public string LieuDepartSejour { get; set; } = null!;

    public DateOnly DateDebutSejour { get; set; }

    public DateOnly DateFinSejour { get; set; }

    public string NomLieuSejour { get; set; } = null!;

    public decimal PrixSejour { get; set; }

    public int MinParticipantSejour { get; set; }

    public int MaxParticipantSejour { get; set; }

    public int? TotalParticipantActuelSejour { get; set; }
}
