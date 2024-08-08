using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Utilisateur
{
    public int IdUtilisateur { get; set; }

    public DateTime DateCreationUtilisateur { get; set; }

    public string MailUtilisateur { get; set; } = null!;

    public string MdpUtilisateur { get; set; } = null!;

    public string NomUtilisateur { get; set; } = null!;

    public string PrenomUtilisateur { get; set; } = null!;

    public string TelUtilisateur { get; set; } = null!;

    public short AgeUtilisateur { get; set; }

    public string PermissionUtilisateur { get; set; } = null!;

    public int? TotalDistanceParcourueUtilisateur { get; set; }
}
