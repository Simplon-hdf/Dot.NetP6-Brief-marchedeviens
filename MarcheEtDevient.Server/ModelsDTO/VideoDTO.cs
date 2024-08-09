using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcheEtDevient.Server.ModelsDTO
{
    public class VideoDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required, MaxLength(75)]
        public string Lien { get; set; }

        [Required, MaxLength(50)]
        public string Titre { get; set; }

        [MaxLength(50)]
        public string? Descriptif { get; set; }
    }
}
