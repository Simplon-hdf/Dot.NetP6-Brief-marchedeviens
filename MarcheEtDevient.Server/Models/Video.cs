using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Video
{
    public int IdVideo { get; set; }

    public string LienVideo { get; set; } = null!;

    public string TitreVideo { get; set; } = null!;

    public DateOnly DateSortieVideo { get; set; }

    public string? DescriptifVideo { get; set; }

    public int? IdSejour { get; set; }
}
