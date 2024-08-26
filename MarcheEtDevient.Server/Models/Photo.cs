using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarcheEtDevient.Server.Models;

public partial class Photo
{
    [Column("id_photo"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
    public int IdPhoto { get; set; }

    [Column("date_photo"), Required]
    public string? DatePhoto { get; set; }

    [Column("est_publique_photo"), Required]
    public bool? EstPubliquePhoto { get; set; }

    [Column("donnee_photo"), Required]
    public string? DonneePhoto { get; set; }

    [Column("id_sejour"), Required]
    public int? IdSejour { get; set; }
}
