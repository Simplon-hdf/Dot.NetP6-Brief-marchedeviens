using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarcheEtDevient.Server.Models;

public partial class Reservation
{
    [Key] public string id_utilisateur { get; set; }

    public string id_sejour { get; set; } = null!;

    public int? nombre_places_demandee { get; set; }

    public DateTime? date_paiement { get; set; }

    public string? total_reservation { get; set; }

    public ulong? validation_reservation { get; set; }

    public string? numero_reservation { get; set; }

    public int? min_participant { get; set; }

    public int? max_participant { get; set; }
}
