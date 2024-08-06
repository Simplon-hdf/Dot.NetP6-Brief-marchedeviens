using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarcheEtDevient.Server.Models;

public partial class PublicationActu
{
    [Key]public string id_publication_actu { get; set; } 

    public DateTime? date_publication { get; set; }

    public string id_publication { get; set; } = null!;

    public string id_video { get; set; } = null!;
}
