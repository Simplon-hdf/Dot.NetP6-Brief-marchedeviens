using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcheEtDevient.Server.ModelsDTO
{
    public class UtilisateurDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Mail { get; set; }

        [Required, MaxLength(50)]
        public string? Prenom { get; set; }

        [Required, MaxLength(50)]
        public string? Nom { get; set; }

        // public int? DistanceParcourue { get; set; }

        [Required, DataType(DataType.Password), MaxLength(35)]
        public string Mdp { get; set; }

        [Required, MaxLength(2)]
        public Int16 Age { get; set; }

        [Required, MinLength(9), MaxLength(10)]
        public string Telephone { get; set; }
    }
}
