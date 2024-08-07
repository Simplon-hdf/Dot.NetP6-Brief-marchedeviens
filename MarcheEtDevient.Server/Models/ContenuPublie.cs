using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarcheEtDevient.Server.Models;

public partial class ContenuPublie
{
    [Key]public string id_publication { get; set; }

    public DateTime? date_cslv { get; set; }

    public string? theme { get; set; }

    public string? commentaire { get; set; }
}
