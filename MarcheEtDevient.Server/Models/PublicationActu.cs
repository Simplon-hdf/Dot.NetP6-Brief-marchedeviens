using System;
using System.Collections.Generic;

namespace MarcheEtDevient.Server.Models;

public partial class PublicationActu
{
    public string IdPublicationActu { get; set; } = null!;

    public DateOnly? DatePublication { get; set; }

    public string IdPublication { get; set; } = null!;

    public string IdVideo { get; set; } = null!;
}
