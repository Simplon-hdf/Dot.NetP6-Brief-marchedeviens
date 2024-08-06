using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MarcheEtDevient.Server.Models;
[Keyless]
public partial class AppartenirGalerie
{
    
    public string id_sejour { get; set; } = null!;

    public string id_photo { get; set; } = null!;
}
