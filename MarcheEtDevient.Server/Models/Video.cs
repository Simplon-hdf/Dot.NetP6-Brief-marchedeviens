using System;
using System.Collections.Generic;

namespace MarcheEtDevient.Server.Models;

public partial class Video
{
    public string IdVideo { get; set; } = null!;

    public string? LienVideo { get; set; }

    public string? TitreVideo { get; set; }

    public DateOnly? DateSortie { get; set; }

    public string IdSejour { get; set; } = null!;
}
