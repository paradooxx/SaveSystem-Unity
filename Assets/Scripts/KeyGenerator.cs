
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public static class KeyGenerator
{
    public static string GenerateKey()
    {
        string combined = SystemInfo.deviceUniqueIdentifier;

        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(combined));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString().Substring(0, 32);
        }
    }
}
