using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarcheEtDevient.Server.Models;

public partial class Utilisateur
{
    [Key] public string id_utilisateur { get; set; }

    public string? mdp_utilisateur { get; set; }

    public string? nom_utilisateur { get; set; }

    public string? mail_utilisateur { get; set; }

    public string? prenom_utilisateur { get; set; }

    public string? tel_utilisateur { get; set; }

    public string age_utilisateur { get; set; } = null!;

    public string? permission_utilisateur { get; set; }
}
