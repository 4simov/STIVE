using System.Security.Cryptography;

namespace Infrastructure.Services.NewFolder
{
    public class MyEncryption
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iteration = 10000;

        private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA256;

        public static string Hash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iteration, Algorithm, HashSize );
            return ($"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}");
        }

        public static bool Verify(string password, string passwordHashed)
        {
            string[] parts = passwordHashed.Split('-');
            byte[] hash = Convert.FromHexString(parts[0]);
            byte[] salt = Convert.FromHexString(parts[1]);

            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iteration, Algorithm, HashSize);

            return hash.SequenceEqual(inputHash);
        }
    }
}
