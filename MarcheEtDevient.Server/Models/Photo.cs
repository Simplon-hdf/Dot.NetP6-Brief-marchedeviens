using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarcheEtDevient.Server.Models;

public partial class Photo
{
    [Key] public string id_photo { get; set; }

    public DateTime? date_photo { get; set; }

    public byte[]? photo { get; set; }

    public ulong? est_publique { get; set; }
}
