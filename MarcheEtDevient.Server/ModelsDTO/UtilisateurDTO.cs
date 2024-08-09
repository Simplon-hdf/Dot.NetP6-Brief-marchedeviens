using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcheEtDevient.Server.ModelsDTO
{
    public class UtilisateurDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required, MaxLength(50)]
        public string Mail { get; set; }

        [MaxLength(50)]
        public string? Prenom { get; set; }

        [MaxLength(50)]
        public string? Nom { get; set; }

        public int? DistanceParcourue { get; set; }
    }
}
