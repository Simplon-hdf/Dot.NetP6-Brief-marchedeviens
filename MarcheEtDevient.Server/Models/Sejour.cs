using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarcheEtDevient.Server.Models;

public partial class Sejour
{
    [Column("id_sejour"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
    public int IdSejour { get; set; }

    [Column("nom_sejour"), MaxLength(50), Required]
    public string NomSejour { get; set; } = null!;

    [Column("descriptif_sejour"), MaxLength(50), Required]
    public string DescriptifSejour { get; set; } = null!;

    [Column("lieu_depart_sejour"), MaxLength(50), Required]
    public string LieuDepartSejour { get; set; } = null!;

    [Column("date_debut_sejour"), Required]
    public string DateDebutSejour { get; set; }

    [Column("date_fin_sejour"), Required]
    public string DateFinSejour { get; set; }

    [Column("nom_lieu_sejour"), MaxLength(50), Required]
    public string NomLieuSejour { get; set; } = null!;

    [Column("prix_sejour"), Required]
    public decimal PrixSejour { get; set; }

    [Column("min_participant_sejour"), Required]
    public int MinParticipantSejour { get; set; }

    [Column("max_participant_sejour"), Required]
    public int MaxParticipantSejour { get; set; }

    [Column("total_participant_actuel_sejour")]
    public int? TotalParticipantActuelSejour { get; set; }
}
