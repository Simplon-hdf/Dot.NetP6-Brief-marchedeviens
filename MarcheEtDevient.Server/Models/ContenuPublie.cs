using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarcheEtDevient.Server.Models;
[Table("contenu_publie")]
public partial class ContenuPublie
{
    [Column("id_contenu_publie"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
    public int IdContenuPublie { get; set; }

    [Column("date_contenu_publie"), Required]
    public string DateContenuPublie { get; set; }

    [Column("theme_contenu_publie"), MaxLength(2000) , Required]
    public string ThemeContenuPublie { get; set; } = null!;

    [Column("commentaire_contenu_publie"), MaxLength(2000) , Required]
    public string CommentaireContenuPublie { get; set; } = null!;

    [Column("id_photo"), MaxLength(2000)]
    public int? IdPhoto { get; set; }
}
