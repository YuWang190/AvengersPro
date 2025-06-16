using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace JW
{
    public static class AESTools
    {
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string JieMi(string key,string iv,string content) 
        {
            char[] ivs = iv.ToCharArray();
            byte[] tempIV = new byte[16];
            for (int i = 0; i < ivs.Length; i++)
            {
                tempIV[i] = (byte)ivs[i];
            }
           return Encoding.UTF8.GetString(  DecryptAES(Encoding.UTF8.GetBytes(content), Convert.FromBase64String(key), tempIV));
        }

        public static byte[] DecryptAES(byte[] cipherText, byte[] key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                Debug.Log(iv.Length);
                aesAlg.IV = iv;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (MemoryStream resultStream = new MemoryStream())
                        {
                            csDecrypt.CopyTo(resultStream);
                            return resultStream.ToArray();
                        }
                    }
                }
            }
        }

    }
}
