using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using ERPSYS.Members;


namespace ERPSYS.Helpers
{
    public class ClsSecurity
    {
        private const string EncryptionKey = "FTMCSYSTEMENCRYPTION";
        private const string InitialVictor = "FTMCSYSTEM";

        public static string Encrypt(string plainText, string passPhrase = "")
        {
            try
            {
                if(passPhrase == string.Empty)
                {

                    passPhrase = EncryptionKey;
                }
                else
                {
                    passPhrase = passPhrase.ToUpper();
                }
                string saltValue = passPhrase;
                const string hashAlgorithm = "SHA1";
                const string initVector = InitialVictor;
                const int passwordIterations = 1;
                const int keySize = 256;

                return Encrypt(plainText, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string Decrypt(string plainText, string passPhrase = "")
        {
            try
            {
                if(passPhrase == string.Empty)
                {
                    passPhrase = EncryptionKey;
                }
                else
                {
                    passPhrase = passPhrase.ToUpper();
                }
                string saltValue = passPhrase;
                const string hashAlgorithm = "SHA1";
                const string initVector = InitialVictor;
                const int passwordIterations = 1;
                const int keySize = 256;

                return Decrypt(plainText, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string Encrypt(string plainText,// original plaintext
                                     string passPhrase,
                                     string saltValue,
                                     string hashAlgorithm,
                                     int passwordIterations,
                                     string initVector,
                                    int keySize)
        {
            try
            {
                // Convert strings into byte arrays.
                // Let us assume that strings only contain ASCII codes.
                // If strings include Unicode characters, use Unicode, UTF7, or UTF8 
                // encoding.
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
                // Convert our plaintext into a byte array.
                // Let us assume that plaintext contains UTF8-encoded characters.
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                // First, we must create a password, from which the key will be derived.
                // This password will be generated from the specified passphrase and 
                // salt value. The password will be created using the specified hash 
                // algorithm. Password creation can be done in several iterations.
                PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
                // Use the password to generate pseudo-random bytes for the encryption
                // key. Specify the size of the key in bytes (instead of bits).
                byte[] keyBytes = passwordDeriveBytes.GetBytes(keySize / 8);
                // Create uninitialized Rijndael encryption object.
                RijndaelManaged symmetricKey = new RijndaelManaged();
                // It is reasonable to set encryption mode to Cipher Block Chaining
                // (CBC). Use default options for other symmetric key parameters.
                symmetricKey.Mode = CipherMode.CBC;
                // Generate encryptor from the existing key bytes and initialization 
                // vector. Key size will be defined based on the number of the key 
                // bytes.
                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
                // Define memory stream which will be used to hold encrypted data.
                MemoryStream memoryStream = new MemoryStream();
                // Define cryptographic stream (always use Write mode for encryption).
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                // Start encrypting.
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                // Finish encrypting.
                cryptoStream.FlushFinalBlock();
                // Convert our encrypted data from a memory stream into a byte array.
                byte[] cipherTextBytes = memoryStream.ToArray();
                // Close both streams.
                memoryStream.Close();
                cryptoStream.Close();
                // Convert encrypted data into a base64-encoded string.
                string cipherText = Convert.ToBase64String(cipherTextBytes);
                // Return encrypted string.
                return cipherText;
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string Decrypt(string cipherText,
                                     string passPhrase,
                                     string saltValue,
                                     string hashAlgorithm,
                                     int passwordIterations,
                                     string initVector,
                                     int keySize)
        {
            try
            {
                string plainText = string.Empty;

                if(cipherText != string.Empty)
                {
                    // Convert strings defining encryption key characteristics into byte
                    // arrays. Let us assume that strings only contain ASCII codes.
                    // If strings include Unicode characters, use Unicode, UTF7, or UTF8
                    // encoding.
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                    byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
                    // Convert our ciphertext into a byte array.
                    byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                    // First, we must create a password, from which the key will be 
                    // derived. This password will be generated from the specified 
                    // passphrase and salt value. The password will be created using
                    // the specified hash algorithm. Password creation can be done in
                    // several iterations.
                    PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                                    passPhrase,
                                                                    saltValueBytes,
                                                                    hashAlgorithm,
                                                                    passwordIterations);

                    // Use the password to generate pseudo-random bytes for the encryption
                    // key. Specify the size of the key in bytes (instead of bits).
                    byte[] keyBytes = password.GetBytes(keySize / 8);
                    // Create uninitialized Rijndael encryption object.
                    RijndaelManaged symmetricKey = new RijndaelManaged();
                    // It is reasonable to set encryption mode to Cipher Block Chaining
                    // (CBC). Use default options for other symmetric key parameters.
                    symmetricKey.Mode = CipherMode.CBC;
                    // Generate decryptor from the existing key bytes and initialization 
                    // vector. Key size will be defined based on the number of the key 
                    // bytes.
                    ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                    // Define memory stream which will be used to hold encrypted data.
                    MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
                    // Define cryptographic stream (always use Read mode for encryption).
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                    // Since at this point we don't know what the size of decrypted data
                    // will be, allocate the buffer long enough to hold ciphertext;
                    // plaintext is never longer than ciphertext.
                    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                    // Start decrypting.
                    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                    // Convert decrypted data into a string. 
                    // Let us assume that the original plaintext string was UTF8-encoded.
                    try
                    {
                        plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                        // Close both streams.
                        memoryStream.Close();
                        cryptoStream.Close();
                    }
                    catch { }
                    // Return decrypted string.   
                }
                return plainText;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}