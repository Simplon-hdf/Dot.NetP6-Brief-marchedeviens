namespace MarcheEtDevient.Server.ModelsDTO
{
    public class LoginDTO
    {
        public class UserDto
        {
            public string mailUtilisateur { get; set; } = string.Empty;
            public string motDePasse { get; set; } = string.Empty;
        }
    }
}
