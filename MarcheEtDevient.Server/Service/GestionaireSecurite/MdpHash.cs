using System.Security.Cryptography;
using System.Text;

namespace MarcheEtDevient.Server.Service.GestionaireSecurite
{
    public class loginAuthentification
    {
        public static string PassHash(string inputPassHash)
        {
            using (MD5 md5 = MD5.Create()) // utilisation de l'outil md5
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(inputPassHash); // hashage du string d'entré une premier fois
                byte[] hashBytes = md5.ComputeHash(inputBytes); // une deuxieme fois

                StringBuilder sb = new StringBuilder(); // instanciation d'une variable string builder
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2")); // transformation en string de chaque bytes (8 bit)
                }
                return sb.ToString(); // converti en le stringbuilder en string
            }

        }
    }
}
