using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcheEtDevient.Server.ModelsDTO
{
    public class ContenuPublieDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public DateOnly DateContenu { get; set; }

        [Required, MaxLength(2000)]
        public string Theme { get; set; }

        [Required, MaxLength(2000)]
        public string Commentaire { get; set; }
    }
}
