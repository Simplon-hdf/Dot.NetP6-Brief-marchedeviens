using System;
using System.Collections.Generic;

namespace MarcheEtDevient.Server.Models;

public partial class Photo
{
    public string IdPhoto { get; set; } = null!;

    public DateOnly? DatePhoto { get; set; }

    public byte[]? Photo1 { get; set; }

    public ulong? EstPublique { get; set; }
}
