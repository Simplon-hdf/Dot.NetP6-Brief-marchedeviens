using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MarcheEtDevient.Server.ModelsDTO
{
    public class LoginDTO
    {
            public string mailUtilisateur { get; set; }
            [DataType(DataType.Password)]
            public string motDePasse { get; set; }
    }
}
