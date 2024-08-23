using System.ComponentModel.DataAnnotations;

namespace MarcheEtDevient.Server.ModelsDTO
{
    public class InscriptionDTO
    {
        public string mailUtilisateur { get; set; } = string.Empty;
        public string prenomUtilisateur { get; set; }
        public string nomUtilisateur { get; set; }

        [DataType(DataType.Password)]
        public string motDePasse { get; set; }
        public Int16 ageUtilisateur { get; set; }
        public string nTelephoneUtilisateur { get; set; }
    }
}
