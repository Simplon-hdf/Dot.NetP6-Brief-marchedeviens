using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Photo
{
    public int IdPhoto { get; set; }

    public DateOnly? DatePhoto { get; set; }

    public bool? EstPubliquePhoto { get; set; }

    public byte[]? DonneePhoto { get; set; }

    public int? IdSejour { get; set; }
}
