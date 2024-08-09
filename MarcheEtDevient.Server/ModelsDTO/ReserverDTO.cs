using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcheEtDevient.Server.ModelsDTO
{
    public class ReserverDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public int IdUtilisateur { get; set; }

        [Required]
        public int IdSejour { get; set; }

        [Required]
        public short NbPlaceReserver { get; set; }
    }
}
