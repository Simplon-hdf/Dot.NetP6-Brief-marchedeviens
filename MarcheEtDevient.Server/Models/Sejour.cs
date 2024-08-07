using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarcheEtDevient.Server.Models;

public partial class Sejour
{
    [Key] public string id_sejour { get; set; }

    public string? nom_sejour { get; set; }

    public string? descriptif { get; set; }

    public DateTime? date_debut_sejour { get; set; }

    public DateTime? date_fin_sejour { get; set; }

    public string? nom_lieu_sejour { get; set; }

    public decimal? prix_sejour { get; set; }

    public string? type_sejour { get; set; }

    public int? total_participant { get; set; }
}
