using System;
using System.Collections.Generic;

namespace MarcheEtDevient.Server.Models;

public partial class Reservation
{
    public string IdUtilisateur { get; set; } = null!;

    public string IdSejour { get; set; } = null!;

    public int? NombrePlacesDemandee { get; set; }

    public DateOnly? DatePaiement { get; set; }

    public ulong? ValidationReservation { get; set; }

    public string? NumeroReservation { get; set; }

    public int? MinParticipant { get; set; }

    public int? MaxParticipant { get; set; }
}
