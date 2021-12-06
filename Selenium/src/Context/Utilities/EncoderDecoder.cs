using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FmsDbContext.Utils
{
    public static class EncoderDecoder
    {
        /// <summary>
        /// Decryption of a "base 64 encoded" and "AES 256 encrypted" text.
        /// </summary>
        /// <param name="data">The base 64 string representing the IV + CipherText</param>
        /// <param name="key">Text representing the Secret key used for the symmetric algorithm in base 64 format</param>
        /// <returns>The decrypted result</returns>
        public static string DecryptAes256(string data, string key)
        {
            // Check arguments.
            if (!string.IsNullOrEmpty(data) && !string.IsNullOrEmpty(key))
            {
                // Decode from Base 64 text to bytes
                byte[] bytesdata = Convert.FromBase64String(data);

                //Split the bytes of data into the IV and the Ciphered bytes
                Tuple<byte[], byte[]> splitResult = SplitByteArray(bytesdata);
                byte[] iv = splitResult.Item1;
                byte[] bytesCipherText = splitResult.Item2;
                byte[] bytesKey = Convert.FromBase64String(key);
                string plainText = null;

                // Create an AesManaged object with the specified key and IV.
                using (AesManaged aesAlg = new AesManaged())
                {
                    aesAlg.Key = bytesKey;
                    aesAlg.Mode = CipherMode.CBC;
                    aesAlg.IV = iv;

                    // Create a decryptor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    // Create the streams used for decryption.
                    using (MemoryStream memoryStream = new MemoryStream(bytesCipherText))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader(cryptoStream))
                            {
                                // Read the decrypted bytes from the decrypting stream and place them in a string.
                                plainText = streamReader.ReadToEnd();
                            }
                        }
                    }
                }

                return plainText;
            }
            else
            {
                throw new ArgumentNullException("The arguments must not be null or empty");
            }
        }

        /// <summary>
        /// AES 256 Encryption of an input text and the result is Base 64 encoded
        /// </summary>
        /// <param name="plainText">Bytes to be encrypted</param>
        /// <param name="key">Text representing the Secret key used for the symmetric algorithm in base64 format</param>
        /// <returns>Base64 text of the bytes representing the IV + encrypted data</returns>
        public static string EncryptAes256(string plainText, string key)
        {
            // Check arguments.
            if (!string.IsNullOrEmpty(plainText) && !string.IsNullOrEmpty(key))
            {
                byte[] bytesInputText = Encoding.UTF8.GetBytes(plainText);
                byte[] bytesKey = Convert.FromBase64String(key);
                byte[] data;

                // Create an AesManaged object with the specified key and IV.
                using (AesManaged aesAlg = new AesManaged())
                {
                    aesAlg.Key = bytesKey;
                    aesAlg.Mode = CipherMode.CBC;

                    // Create a decryptor to perform the stream transform.
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                    byte[] encrypted;

                    // Create the streams used for encryption.
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                            {
                                streamWriter.Write(plainText);
                            }

                            encrypted = memoryStream.ToArray();
                        }
                    }

                    //Prepend the Initialization Vector to the encrypted bytes.
                    data = CombineByteArrays(aesAlg.IV, encrypted);
                }

                return Convert.ToBase64String(data);
            }
            else
            {
                throw new ArgumentNullException("The arguments must not be null or empty");
            }
        }

        /// <summary>
        /// Combines two arrays of bytes into one.
        /// http://jonphaywood.com/blog/post/aes-256-symmetric-encryption-and-decryption-with-c
        /// </summary>
        /// <param name="first">First Array of bytes to be combined</param>
        /// <param name="second">Second Array of bytes to be combined</param>
        /// <returns>The combination of the two arrays [first, second]</returns>
        private static byte[] CombineByteArrays(byte[] first, byte[] second)
        {
            byte[] data = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, data, 0, first.Length);
            Buffer.BlockCopy(second, 0, data, first.Length, second.Length);
            return data;
        }

        /// <summary>
        /// Splits one array of bytes into two. It uses the first 16 bytes for the first array, and the rest for the second
        /// </summary>
        /// <param name="data">The data stored in one array of bytes</param>
        /// <returns>A tuple with two array of bytes</returns>
        private static Tuple<byte[], byte[]> SplitByteArray(byte[] data)
        {
            byte[] first = new byte[16];
            Buffer.BlockCopy(data, 0, first, 0, first.Length);
            byte[] second = new byte[data.Length - first.Length];
            Buffer.BlockCopy(data, first.Length, second, 0, second.Length);
            return Tuple.Create(first, second);
        }
    }
}