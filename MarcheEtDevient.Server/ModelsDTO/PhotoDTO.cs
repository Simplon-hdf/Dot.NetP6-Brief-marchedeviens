using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcheEtDevient.Server.ModelsDTO
{
    public class PhotoDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public DateOnly? Date {  get; set; }

        [Required]
        public byte[]? Donnee { get; set; }
    }
}
