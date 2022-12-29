using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    public class Sifreleme
    {
        public static string sha1(string pValue, bool pEncrypt = false, string pKey = "*s*i*h*i*r*l*i*t*u*s*", string pEncoding = "iso-8859-9")
        {
            System.Security.Cryptography.SHA1 hash = System.Security.Cryptography.SHA1.Create();
            byte[] data = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pValue));
            System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();
            int i;
            for (i = 0; i <= data.Length - 1; i++)
                sBuilder.Append(data[i].ToString("x2"));

            if (pEncrypt)
                return Converter.extEncrypt(sBuilder.ToString(), pEncrypt, pKey, pEncoding);

            return sBuilder.ToString();
        }
        public static bool sha1Verify(string pValue, string pHashValue)
        {
            string hashOfInput = sha1(pValue);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(hashOfInput, pHashValue))
                return true;
            else
                return false;
        }

    }

}
