using System;
using System.Collections.Generic;

namespace MarcheEtDevient.Server.Models;

public partial class Utilisateur
{
    public string IdUtilisateur { get; set; } = null!;

    public string? MdpUtilisateur { get; set; }

    public string? NomUtilisateur { get; set; }

    public string? MailUtilisateur { get; set; }

    public string? PrenomUtilisateur { get; set; }

    public string? TelUtilisateur { get; set; }

    public string AgeUtilisateur { get; set; } = null!;

    public string? PermissionUtilisateur { get; set; }
}
