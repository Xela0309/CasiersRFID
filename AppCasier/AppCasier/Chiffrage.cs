using System;
using System.Text;

namespace AppCasier
{
    public class ChiffrageXOR
    {
        private byte[] _key; // Clé générée à partir du mot de passe

        public ChiffrageXOR(string password)
        {
            _key = GenerateKey(password, 256); // Génération de la clé à partir du mot de passe
        }

        // Génère une clé pseudo-aléatoire basée sur un mot de passe (PRNG)
        private byte[] GenerateKey(string password, int length)
        {
            byte[] key = new byte[length];
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            int seed = 0;

            // Création d’un "seed" en XORant les bytes du mot de passe
            foreach (byte b in passwordBytes)
                seed ^= b;

            Random random = new Random(seed); // Initialisation du PRNG

            for (int i = 0; i < length; i++)
                key[i] = (byte)random.Next(0, 256); // Génération de bytes pseudo-aléatoires

            return key;
        }

        // Fonction de chiffrement XOR avancé
        public string Encrypt(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] outputBytes = new byte[inputBytes.Length];

            for (int i = 0; i < inputBytes.Length; i++)
            {
                outputBytes[i] = (byte)(inputBytes[i] ^ _key[i % _key.Length]); // XOR avec la clé
            }

            return BytesToHex(outputBytes); // Encodage en Hexadécimal
        }

        // Fonction de déchiffrement
        public string Decrypt(string input)
        {
            byte[] inputBytes = HexToBytes(input);
            byte[] outputBytes = new byte[inputBytes.Length];

            for (int i = 0; i < inputBytes.Length; i++)
            {
                outputBytes[i] = (byte)(inputBytes[i] ^ _key[i % _key.Length]); // XOR avec la clé
            }

            return Encoding.UTF8.GetString(outputBytes);
        }

        // Encodage en Hexadécimal
        private string BytesToHex(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        // Décodage Hexadécimal vers byte[]
        private byte[] HexToBytes(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            return bytes;
        }
    }
}
