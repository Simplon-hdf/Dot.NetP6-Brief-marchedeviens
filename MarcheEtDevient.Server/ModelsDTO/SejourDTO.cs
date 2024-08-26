using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcheEtDevient.Server.ModelsDTO
{
    public class SejourDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required, MaxLength(50)] 
        public string Nom { get; set; }

        [Required, MaxLength(50)]
        public string Descriptif { get; set; }

        [Required, MaxLength(50)]
        public string LieuDepart { get; set; }

        [Required]
        public DateOnly DateDebut { get; set; }

        [Required]
        public DateOnly DateFin {  get; set; }

        [Required, MaxLength(50)]
        public string NomLieu { get; set; }

        [Required]
        public decimal Prix { get; set; }

    }
}
