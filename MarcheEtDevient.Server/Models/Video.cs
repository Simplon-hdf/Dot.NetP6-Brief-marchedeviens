using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarcheEtDevient.Server.Models;

public partial class Video
{
    [Column("id_video"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
    public int IdVideo { get; set; }

    [Column("lien_video"), MaxLength(75), Required]
    public string LienVideo { get; set; } = null!;

    [Column("titre_video"), MaxLength(50), Required]
    public string TitreVideo { get; set; } = null!;

    [Column("date_sortie_video"), Required]
    public string DateSortieVideo { get; set; }

    [Column("descriptif_video"), MaxLength(50)]
    public string? DescriptifVideo { get; set; }

    [Column("id_sejour")]
    public int? IdSejour { get; set; }
}
