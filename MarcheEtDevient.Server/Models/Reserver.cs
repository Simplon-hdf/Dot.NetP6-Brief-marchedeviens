using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarcheEtDevient.Server.Models;

public partial class Reserver
{
    [Column("id_utilisateur"), Required]
    public int IdUtilisateur { get; set; }

    [Column("id_sejour"), Required]
    public int IdSejour { get; set; }

    [Column("id_reserver"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
    public int IdReserver { get; set; }

    [Column("nombre_place_reserver"), Required]
    public short NombrePlaceReserver { get; set; }

    [Column("validation_reserver")]
    public bool? ValidationReserver { get; set; }

    [Column("date_paiement_reserver")]
    public DateTime? DatePaiementReserver { get; set; }
}
