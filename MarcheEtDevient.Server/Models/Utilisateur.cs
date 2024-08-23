using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarcheEtDevient.Server.Models;

public partial class Utilisateur
{
    [Column("id_utilisateur"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
    public int IdUtilisateur { get; set; }

    [Column("date_creation_utilisateur"), Required]
    public string DateCreationUtilisateur { get; set; }

    [Column("mail_utilisateur"), MaxLength(50), Required]
    public string MailUtilisateur { get; set; } = null!;

    [Column("mdp_utilisateur"), MaxLength(35), Required, DataType(DataType.Password)]
    public string MdpUtilisateur { get; set; } = null!;

    [Column("nom_utilisateur"), MaxLength(50), Required]
    public string NomUtilisateur { get; set; } = null!;

    [Column("prenom_utilisateur"), MaxLength(50), Required]
    public string PrenomUtilisateur { get; set; } = null!;

    [Column("tel_utilisateur"), MaxLength(50), Required]
    public string TelUtilisateur { get; set; } = null!;

    [Column("age_utilisateur"), Required]
    public Int16 AgeUtilisateur { get; set; }

    [Column("permission_utilisateur"), MaxLength(50), Required]
    public string PermissionUtilisateur { get; set; } = null!;

    [Column("total_distance_parcourue_utilisateur"), Required]
    public int? TotalDistanceParcourueUtilisateur { get; set; }
}
