using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Publication
{
    public int IdPublication { get; set; }

    public DateOnly DatePublication { get; set; }

    public int IdContenuPublie { get; set; }

    public int IdVideo { get; set; }
}
