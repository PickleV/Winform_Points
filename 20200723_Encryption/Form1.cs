using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace _20200723_Encryption
{
    public partial class Form1 : Form
    {
        //Variable
        string sPublicKey = @"<RSAKeyValue><Modulus>vydkCLh2I8KXmzYPap0HVNLB0QGU7ebzTti6mgusC8fI/+jeJwhhQUjCt4QdxZ8EEEU0eBivVgI531QK0rxU4cQZTTV03RGCUGtcP30uVcuvXO5yZ4n32VAfL2XYA0GOEKdTYGCcDDhYLSyPS0zEBcpAXKeIQAQTvSPPYhr65L0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        string sPrivateKey = @"<RSAKeyValue><Modulus>vydkCLh2I8KXmzYPap0HVNLB0QGU7ebzTti6mgusC8fI/+jeJwhhQUjCt4QdxZ8EEEU0eBivVgI531QK0rxU4cQZTTV03RGCUGtcP30uVcuvXO5yZ4n32VAfL2XYA0GOEKdTYGCcDDhYLSyPS0zEBcpAXKeIQAQTvSPPYhr65L0=</Modulus><Exponent>AQAB</Exponent><P>2VoYMKnah/ytsJYb2uxu9K2j7a9nHY0rbohyXOMMsIJhmpiC6vmfSjw4jHHShbOqy689Lc1Z5UpFd6fUTH5Avw==</P><Q>4STBSJVLrqncuDri6gCApscUO0X4X3d7cPqIiV/8WHQBH8AeisFBgP2Ip9vLIy05Xjzn7dp7tpzkmvxHFV39gw==</Q><DP>dleCokRpEu+2Fla01e8zvo8omUqOh12Mz0MFmaOaDiT/RbBSX+QIIeBGHdn/eQLJNNu2INEVaC2XQz4i7n8zew==</DP><DQ>hvja6uGd6osoqEWdLX25osIsbdBnswvVNAjt+7VQedKprdgmNzbeRy83UrJgmKkPAGDxBdX6XqK2JffhwXyEcw==</DQ><InverseQ>wp7zShm3Xt+CcViguNJu7tKWpFLD/ig70TjjkpETAOkBkjhtCQRP8PU+24MmUUhC9aMxN9DIYiNgOUduRvfFcQ==</InverseQ><D>NNep0rNTjV0s1e5i4qEYNr2wcJvUVNPkbOaC5zTU0cjf6sawKvApGogHs/2k0U29LNZEw/Jm/grNfsxX1ZvUhr6A4P+lhbAI0zs+zZxiD+LDQ2uIveH+lPIGbIjcYTOl0qHRS1fY+U1H/Kb7WQoWLuSIg3Z6ik/UCq/TW9CvBW0=</D></RSAKeyValue>";
        RSAParameters rsaKeyPublic;
        RSAParameters rsaKeyPrivate;
        Aes aesMain = Aes.Create();
        byte[] AESKey;
        byte[] AESVector;



        public Form1()
        {
            InitializeComponent();
        }

        private void bEnMD5_Click(object sender, EventArgs e)
        {
            if (tbInput.Text.Length > 1)
            {
                tbOutput.AppendText("\r\nResult MD5 of (" + tbInput.Text + "):\r\n" + EncryptMD5(tbInput.Text));
            }
        }

        private string EncryptMD5(string RawText)
        {
            MD5 md5Hash = MD5.Create();//Create a md5
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(RawText));
            string s = BitConverter.ToString(data).Replace('-', ' ');
            md5Hash.Dispose();//release memory
            return s;
        }

        private void bEnSha512_Click(object sender, EventArgs e)
        {
            if (tbInput.Text.Length > 1)
            {
                tbOutput.AppendText("\r\nResult SHA512 of (" + tbInput.Text + "):\r\n" + EncryptSHA512(tbInput.Text));
            }
        }

        private string EncryptSHA512(string RawText)
        {
            SHA512 sha512 = new SHA512Managed();
            byte[] data = sha512.ComputeHash(Encoding.UTF8.GetBytes(RawText));
            string s = BitConverter.ToString(data).Replace('-', ' ');
            sha512.Dispose();//release memory
            return s;
        }

        private void bEnSha256_Click(object sender, EventArgs e)
        {
            if (tbInput.Text.Length > 1)
            {
                tbOutput.AppendText("\r\nResult SHA256 of (" + tbInput.Text + "):\r\n" + EncryptSHA256(tbInput.Text));
            }
        }

        private string EncryptSHA256(string RawText)
        {
            SHA256 sha256 = new SHA256Managed();
            byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(RawText));
            string s = BitConverter.ToString(data).Replace('-', ' ');
            sha256.Dispose();//release memory
            return s;
        }

        private void bRSA_Click(object sender, EventArgs e)
        {

            //生成Key
            //RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //string KeyPublic = rsa.ToXmlString(false);
            //string KeyPrivate = rsa.ToXmlString(true);   
            //Console.WriteLine(KeyPublic);
            //Console.WriteLine(KeyPrivate);
            //rsa.Dispose();

            //生成key2
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsaKeyPrivate = rsa.ExportParameters(true);
            rsaKeyPublic = rsa.ExportParameters(false);
            // rsa.Dispose();



            if (tbInput.Text.Length > 1)
            {
                tbOutput.AppendText("\r\nResult RSA of (" + tbInput.Text + "):\r\n" + EncryptRSA(tbInput.Text));
            }

        }

        private string DecryptRSA(string RawText)
        {
            //Define an rsa
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            //Get key
            //rsa.FromXmlString(sPrivateKey);
            rsa.ImportParameters(rsaKeyPrivate);
            byte[] cipherbytes = rsa.Decrypt(Encoding.Unicode.GetBytes(RawText), false);
            rsa.Dispose();
            return Encoding.Unicode.GetString(cipherbytes); //这样出来的是乱码
                                                            // return Convert.ToBase64String(cipherbytes); //这样就是编码

        }


        private string EncryptRSA(string RawText)
        {
            //Define an rsa
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //Get key
            //rsa.FromXmlString(sPrivateKey);
            rsa.ImportParameters(rsaKeyPublic);
            //
            byte[] cipherbytes = rsa.Encrypt(Encoding.Unicode.GetBytes(RawText), false);

            rsa.Dispose();
            return Encoding.Unicode.GetString(cipherbytes); //这样出来的是乱码
            //return Convert.ToBase64String(cipherbytes); //这样就是编码

        }

        private void bRSADe_Click(object sender, EventArgs e)
        {
            if (tbInput.Text.Length > 1)
            {
                tbOutput.AppendText("\r\nResult RSA of (" + tbInput.Text + "):\r\n" + DecryptRSA(tbInput.Text));
            }

        }


       
        private void bAESEncrypt_Click(object sender, EventArgs e)
        {
            if (tbInput.Text.Length > 1)
            {
                tbOutput.AppendText("\r\nResult AES of (" + tbInput.Text + "):\r\n" + EncryptAES(tbInput.Text,AESKey,AESVector));
            }
        }

        static string EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

           


                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return  Convert.ToBase64String(encrypted);
            //Only Base64 format can be seeing as normal text.

        }


        static string DecryptStringFromBytes_Aes(string cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);




                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }

        private string EncryptAES(string Input, byte[] Key, byte[] Vector)
        {
            //Init variables
            byte[] bResult;
            string sResult;
            Aes theAES = Aes.Create();

            //Set values
            theAES.Key = Key;
            theAES.IV = Vector;

            // Create an encryptor to perform the stream transform.
            ICryptoTransform encryptor = theAES.CreateEncryptor(theAES.Key, theAES.IV);

            //Create stream for encryption
            MemoryStream msAES = new MemoryStream();
            CryptoStream csAES = new CryptoStream(msAES, encryptor, CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(csAES);
            sw.Write(Input); //Write to Stream
            sw.Close(); //Important, this makes sure stream actually write in device out of the cache.

            //Get result
            bResult = msAES.ToArray(); //to byte array
            sResult = Convert.ToBase64String(bResult);

            //Free memory
            sw.Dispose();
            csAES.Dispose();
            msAES.Dispose();
            theAES.Dispose(); 
            
            //Return result
            return sResult;
        }

        private string DecryptAES(string Input, byte[] Key, byte[] Vector)
        {
            //variables
            byte[] bData = Convert.FromBase64String(Input);
            Aes theAES = Aes.Create();
            string sResult = null;

            //set values
            theAES.Key = Key;
            theAES.IV = Vector;

            // Create an encryptor to perform the stream transform.
            ICryptoTransform decryptor = theAES.CreateDecryptor(theAES.Key, theAES.IV);

            //Create stream for encryption
            using (MemoryStream msAES = new MemoryStream(bData))
            {
                using (CryptoStream csAES = new CryptoStream(msAES, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srAES = new StreamReader(csAES))
                    {
                        sResult=srAES.ReadToEnd();//Get result  
                    }
                }
            }

            //release memory
            theAES.Dispose();
            return sResult;
        }

            private void bAESDecrypt_Click(object sender, EventArgs e)
        {
            //string s = tbInput.Text;
            //byte[] bS = Encoding.UTF8.GetBytes(s);
            //string s1 = Encoding.UTF8.GetString(bS);
            
           if (tbInput.Text.Length > 1)
            {
                tbOutput.AppendText("\r\nResult AES Decryption of (" + tbInput.Text + "):\r\n" + DecryptAES(tbInput.Text,AESKey,AESVector));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string Key = Convert.ToBase64String(aesMain.Key);
            string VI = Convert.ToBase64String(aesMain.IV); //Initial Vector
            Console.WriteLine("AES Key is:\r\n"+Key);
            Console.WriteLine("AES Vector is:\r\n"+VI);
            aesMain.Dispose();

            AESKey = Convert.FromBase64String("RI8P77rIqn8vfbWV1Ksodbbh60iXMhecDK4wWtJ+oQ0=");
            AESVector = Convert.FromBase64String("Y03CvMsOhXI7OzWw+9grYw==");
        }
    }
}
