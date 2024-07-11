using Microsoft.AspNetCore.Identity;

namespace Store_Dashboard.Utills
{
    public class EncryptionDecryption
    {
        public static string Encrypt(string pass)
        {
            return new PasswordHasher<object>().HashPassword(null, pass);
        }

        public static bool Match(string pass, string hash)
        {
            int result = (int)new PasswordHasher<object>().VerifyHashedPassword(null, hash, pass);
            return !(result == 0);
        }

    }
}
