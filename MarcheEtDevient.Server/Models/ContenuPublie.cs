using System;
using System.Collections.Generic;

namespace MarcheEtDevient.Server.Models;

public partial class ContenuPublie
{
    public string IdPublication { get; set; } = null!;

    public DateOnly? DateCslv { get; set; }

    public string? Theme { get; set; }

    public string? Commentaire { get; set; }
}
