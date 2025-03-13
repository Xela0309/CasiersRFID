using System;
using System.Text;

namespace AppCasier
{
    public class Chiffrage
    {
        private byte[] _key; // Clé secrète

        // Génère une clé à partir d'un mot de passe
        private void GenerateKey(string password)
        {
            _key = new byte[32]; // 256 bits

            for (int i = 0; i < _key.Length; i++)
            {
                _key[i] = (byte)(password[i % password.Length] + i);
            }
        }

        // Constructeur avec mot de passe
        public Chiffrage(string password)
        {
            GenerateKey(password);
        }

        // Fonction de chiffrement
        public string Encrypt(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] outputBytes = new byte[inputBytes.Length];

            for (int i = 0; i < inputBytes.Length; i++)
            {
                outputBytes[i] = (byte)(inputBytes[i] ^ _key[i % _key.Length] ^ (i % 256)); // XOR + Décalage
            }

            return Convert.ToBase64String(outputBytes); // Encodage en Base64 pour éviter les caractères illisibles
        }

        // Fonction de déchiffrement
        public string Decrypt(string input)
        {
            byte[] inputBytes = Convert.FromBase64String(input);
            byte[] outputBytes = new byte[inputBytes.Length];

            for (int i = 0; i < inputBytes.Length; i++)
            {
                outputBytes[i] = (byte)(inputBytes[i] ^ _key[i % _key.Length] ^ (i % 256)); // XOR + Décalage inverse
            }

            return Encoding.UTF8.GetString(outputBytes);
        }
    }
}
