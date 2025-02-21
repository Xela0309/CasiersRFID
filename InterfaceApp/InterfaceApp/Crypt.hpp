#ifndef _CRYPT_HPP_
#define _CRYPT_HPP_

#include <string>
#include <vector>

class Crypt {

	private:
        std::vector<unsigned char> m_key; // Cl� secr�te

        // G�n�re une cl� � partir d'un mot de passe
        void generateKey(const std::string& password) {
            m_key.resize(32); // 256 bits
            for (size_t i = 0; i < 32; ++i) {
                m_key[i] = static_cast<unsigned char>(password[i % password.size()] + i);
            }
        }

    public:
        // Constructeur avec mot de passe
        Crypt(const std::string& password) {
            generateKey(password);
        }

        // Fonction de chiffrement
        std::string crypter(const std::string input) {
            std::string output = input;

            for (size_t i = 0; i < input.size(); ++i) {
                output[i] = input[i] ^ m_key[i % m_key.size()] ^ (i % 256); // XOR + D�calage
            }

            return output;
        }

        // Fonction de d�chiffrement (identique au chiffrement)
        std::string decrypt(const std::string input) {
            return crypter(input); // XOR �tant r�versible, on applique la m�me fonction
        }

};

#endif // !_CRYPT_HPP_