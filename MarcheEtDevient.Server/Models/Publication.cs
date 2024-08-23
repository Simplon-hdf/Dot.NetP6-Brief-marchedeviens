using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarcheEtDevient.Server.Models;

public partial class Publication
{
    [Column("id_publication"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
    public int IdPublication { get; set; }

    [Column("date_publication"), Required]
    public string DatePublication { get; set; }

    [Column("id_contenu_publie"), Required]
    public int IdContenuPublie { get; set; }

    [Column("id_video"), Required]
    public int IdVideo { get; set; }
}
