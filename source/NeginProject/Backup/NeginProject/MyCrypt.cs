//My Crypt By Omid55
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace NeginProject
{
    public class MyCrypt
    {
        public MyCrypt() { }

        public static String encrypt(String text, String pass, String salt, String hash, int passit, String initvector, int keysize)  // passit == pass iterator
        {
            //text=faToEn(text);
            byte[] initvectorbytes = Encoding.ASCII.GetBytes(initvector);
            byte[] saltbytes = Encoding.ASCII.GetBytes(salt);
            byte[] textbytes = Encoding.ASCII.GetBytes(text);
            PasswordDeriveBytes passw = new PasswordDeriveBytes(pass, saltbytes, hash, passit);
            byte[] keybytes = passw.GetBytes(keysize / 8);
            RijndaelManaged symmetrickey = new RijndaelManaged();
            symmetrickey.Mode = CipherMode.CBC;       // It is reasonable to set encryption mode to Cipher Block Chaining (CBC). Use default options for other symmetric key parameters.
            ICryptoTransform encryptor = symmetrickey.CreateEncryptor(keybytes, initvectorbytes);
            MemoryStream mem = new MemoryStream();
            CryptoStream cs = new CryptoStream(mem, encryptor, CryptoStreamMode.Write);
            cs.Write(textbytes, 0, textbytes.Length);
            cs.FlushFinalBlock();
            byte[] ciphertextbytes = mem.ToArray();
            mem.Close();
            cs.Close();
            String ciphertext = Convert.ToBase64String(ciphertextbytes);
            return ciphertext;
        }

        public static String decrypt(String ciphertext, String pass, String salt, String hash, int passit, String initvector, int keysize)
        {
            byte[] initvectorbytes = Encoding.ASCII.GetBytes(initvector);
            byte[] saltbytes = Encoding.ASCII.GetBytes(salt);
            byte[] ciphertextbytes = Convert.FromBase64String(ciphertext);
            PasswordDeriveBytes passw = new PasswordDeriveBytes(pass, saltbytes, hash, passit);
            byte[] keybytes = passw.GetBytes(keysize / 8);
            RijndaelManaged symmetrickey = new RijndaelManaged();
            symmetrickey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetrickey.CreateDecryptor(keybytes, initvectorbytes);
            MemoryStream mem = new MemoryStream(ciphertextbytes);
            CryptoStream cs = new CryptoStream(mem, decryptor, CryptoStreamMode.Read);
            byte[] textbytes = new byte[ciphertextbytes.Length];
            int decryptedbyteslen = cs.Read(textbytes, 0, textbytes.Length);
            mem.Close();
            cs.Close();
            String text = Encoding.UTF8.GetString(textbytes, 0, decryptedbyteslen);
            //text = enToFa(text);
            return text;
        }

        // for begining of use of database
        // 0000 <-> rpc8S8DweL10d9ZCdC5Ddg==
        public static String encryptWithDefaultValues(String text)
        {
            String ha = "MD5";
            string p = "e@3P-x8!`e^T&";
            string sa = "wB4(/0E,M5's";
            int pi = 2;
            string iv = "u1F[7_}$6x%q$L4O";  // it must be 16 bytes
            int ks = 256;
            return encrypt(text, p, sa, ha, pi, iv, ks);
        }

        public static String decryptWithDefaultValues(String ciphertext)
        {
            String ha = "MD5";
            string p = "e@3P-x8!`e^T&";
            string sa = "wB4(/0E,M5's";
            int pi = 2;
            string iv = "u1F[7_}$6x%q$L4O";  // it must be 16 bytes
            int ks = 256;
            return decrypt(ciphertext, p, sa, ha, pi, iv, ks);
        }

        private static char convertCharToAnotherLang(char ch,int lang)  // lang==0 -> fa  lang==1 -> en
        {
            String fa = "اآبپتثجچحخدذرزژسشصضطظعغفقکگلمنوهیئء";
            String en = "abcdefghijklmnopqrstuvwxyz123456789";
            switch (lang)
            {
                case 0:  // fa
                    for (int i = 0; i < fa.Length; i++)
                    {
                        if (fa[i] == ch)
                        {
                            return en[i];
                        }
                    }
                    break;

                case 1:  // en
                    for (int i = 0; i < en.Length; i++)
                    {
                        if (en[i] == ch)
                        {
                            return fa[i];
                        }
                    }
                    break;

                default:
                    return '#';  // it means error
            }
            return ch;
        }

        private static String faToEn(String str)
        {
            String result="";
            int l=str.Length;
            for (int i = 0; i < l; i++)
            {
                result = result + convertCharToAnotherLang(str[i], 0);
            }
            if (result != str)
            {
                result = "@$%&]" + result;
            }
            return result;
        }

        private static String enToFa(String str)
        {
            if (str.Length <= 5)
            {
                return str;
            }
            String prefix = str.Substring(0, 5);
            if (prefix.CompareTo("@$%&]") != 0)
            {
                return str;
            }
            int l = str.Length;
            str = str.Substring(5, l - 5);
            String result = "";
            l = str.Length;
            for (int i = 0; i < l; i++)
            {
                result = result + convertCharToAnotherLang(str[i], 1);
            }
            return result;
        }

    }
}
