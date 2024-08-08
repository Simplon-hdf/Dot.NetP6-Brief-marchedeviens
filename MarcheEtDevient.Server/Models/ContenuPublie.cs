using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class ContenuPublie
{
    public int IdContenuPublie { get; set; }

    public DateOnly DateContenuPublie { get; set; }

    public string ThemeContenuPublie { get; set; } = null!;

    public string CommentaireContenuPublie { get; set; } = null!;

    public int? IdPhoto { get; set; }
}
