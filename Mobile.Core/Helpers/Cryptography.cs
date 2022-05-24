
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Mobile.Core
    Sub_Module  -   

    Copyright   -  Cardiff Metropolitan University 
 
 Modification History:
 ==================================================================================================================================================
 Date              Version      Modify by              Description
 --------------------------------------------------------------------------------------------------------------------------------------------------
19/02/2022          1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
#endregion	  


namespace Mobile.Core.Helpers
{
    /// <summary>
    /// Class used to encrypt,decrypt given text
    /// </summary>
    /// <remarks></remarks>
    public class Cryptography {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Cryptography));
        private readonly static Cryptography _Cryptography = new Cryptography();
        /// <summary>
        /// Creating Rijndael object to encrypt and decrypt string.
        /// </summary>
        /// <remarks></remarks>
        private Rijndael RajindaelAlg = Rijndael.Create();
        private Cryptography() {
            CreateEncryptionDecryption();
        }

        #region Properties
        public static Cryptography Instance {
            get {
                return _Cryptography;
            }
        }
        #endregion

        /// <summary>
        /// Converts Byte Array to Unicode String
        /// </summary>
        /// <param name="value">Byte Array</param>
        /// <returns>Unicode String</returns>
        /// <remarks></remarks>
        private string ByteArrayToUStr(byte[] value) {
            return System.Text.Encoding.Unicode.GetString(value, 0, value.Length);
        }
        /// <summary>
        /// Creates Key for encryption/Decryption
        /// </summary>
        /// <remarks></remarks>
        private void CreateEncryptionDecryption() {
            try {
                MD5 md5Hasher = MD5.Create();
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hasher.ComputeHash(System.Text.Encoding.Default.GetBytes("ALPDT"));
                // Encrypt text to a file using the file name, key, and IV.
                RajindaelAlg.Key = data;
                RajindaelAlg.IV = data;
            } catch (Exception) {
                //log.Error("CreateEncryptionDecryption", ex);
                RajindaelAlg = null;
            }

        }
        /// <summary>
        /// Public method to encrypt string
        /// </summary>
        /// <param name="Value">String value to be encrypted</param>
        /// <returns>Encrypted string</returns>
        /// <remarks></remarks>
        public string EncryptString(string Value) {
            string strEncryptedText = null;
            if (( RajindaelAlg == null )) {
                throw new Exception("Rajindael Object is Empty");
            }
            strEncryptedText = EncryptData(RajindaelAlg.Key, Value);
            return strEncryptedText;
        }
        /// <summary>
        /// public method to Decrypt the encrypted text
        /// </summary>
        /// <param name="Value">Encrypted String value</param>
        /// <returns>Decrypted value</returns>
        /// <remarks></remarks>
        public string DecryptString(string Value) {
            string decryptedString = null;
            decryptedString = DecryptData(RajindaelAlg.Key, Value);
            return decryptedString;
        }
        /// <summary>
        /// Encrypts the string
        /// </summary>
        /// <param name="key">Key to encrypt</param>
        /// <param name="plainText">text to encrypt</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private string EncryptData(byte[] key, string plainText) {
            // Get the bytes to encrypt
            byte[] plaintextByte = System.Text.Encoding.Unicode.GetBytes(plainText);

            // Create a Rijndael instance - automatically generates symmetric key
            // and an initialization vector
            RijndaelManaged rijndael = new RijndaelManaged();

            // Set encryption mode 
            rijndael.Mode = CipherMode.ECB;
            rijndael.Padding = PaddingMode.PKCS7;

            // Create a random initialization vector
            rijndael.GenerateIV();
            byte[] iv = rijndael.IV;

            string encodedText = "";

            // Define memory stream which will be used to hold encrypted data.
            MemoryStream memStrm = new MemoryStream();

            // Write the IV length and the IV
            memStrm.Write(BitConverter.GetBytes(iv.Length), 0, 4);
            memStrm.Write(iv, 0, iv.Length);

            // Create a symmetric encryptor
            using (ICryptoTransform encryptor = rijndael.CreateEncryptor(key, iv)) {
                // Create a CryptStream to write to the output file
                CryptoStream cryptStrm = new CryptoStream(memStrm, encryptor, CryptoStreamMode.Write);

                // Write the content to be encrypted
                cryptStrm.Write(plaintextByte, 0, plaintextByte.Length);
                cryptStrm.FlushFinalBlock();

                // Convert encrypted data from a memory stream into a byte array.
                byte[] cipherTextBytes = memStrm.ToArray();

                // Close the treams
                memStrm.Close();
                cryptStrm.Close();

                // Convert encrypted data into a base64-encoded string.
                encodedText = Convert.ToBase64String(cipherTextBytes);
            }

            return encodedText;
        }
        /// <summary>
        /// Decrypting the encrypted string
        /// </summary>
        /// <param name="key"></param>
        /// <param name="encryptedData">encrypted string</param>
        /// <returns>decrypted string</returns>
        /// <remarks></remarks>
        private string DecryptData(byte[] key, string encryptedData) {
            string strRet = "";

            // Create a symmetric decryptor
            RijndaelManaged Rijndael = new RijndaelManaged();
            Rijndael.Mode = CipherMode.ECB;
            Rijndael.Padding = PaddingMode.PKCS7;

            // Convert our ciphertext into a byte array.
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedData);
            // Define memory stream to use to read encrypted data.
            MemoryStream inStream = new MemoryStream(cipherTextBytes);

            // Read the IV length from the buffer
            int ivLength = BitConverter.ToInt32(cipherTextBytes, 0);
            // Reposition to after 'length' bytes in stream
            inStream.Position = 4;

            // Read the IV from the input stream 
            byte[] iv = new byte[ivLength + 1];
            inStream.Read(iv, 0, ivLength);

            using (ICryptoTransform decryptor = Rijndael.CreateDecryptor(key, iv)) {
                // Create a CryptStream to read from the file
                CryptoStream cryptStrm = new CryptoStream(inStream, decryptor, CryptoStreamMode.Read);

                // Create another MemoryStream for the output
                MemoryStream memStrm = new MemoryStream();
                byte[] buffer = new byte[2049];
                int totalbytes = 0;
                do {
                    int bytesRead = cryptStrm.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) {
                        break; // TODO: might not be correct. Was : Exit Do
                    }
                    memStrm.Write(buffer, 0, bytesRead);
                    totalbytes += bytesRead;
                } while (true);

                // Write the content to be encrypted
                memStrm.Flush();
                memStrm.Seek(0, SeekOrigin.Begin);

                // Get the string from the bytes we read 
                strRet = System.Text.Encoding.Unicode.GetString(memStrm.GetBuffer(), 0, totalbytes);
                cryptStrm.Close();
            }

            return strRet;
        }

    }
}
