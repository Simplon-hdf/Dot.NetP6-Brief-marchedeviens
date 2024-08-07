using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarcheEtDevient.Server.Models;

public partial class Video
{
    [Key]public string id_video { get; set; }

    public string? lien_video { get; set; }

    public string? titre_video { get; set; }

    public DateTime? date_sortie { get; set; }

    public string id_sejour { get; set; } = null!;
}
