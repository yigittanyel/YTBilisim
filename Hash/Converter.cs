using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    public class Converter
    {
        public static string extEncrypt(string pValue, bool pEncrypt = false, string pKey = "*s*i*h*i*r*l*i*t*u*s*", string pEncoding = "iso-8859-9")
        {
            System.Text.StringBuilder xOut = new System.Text.StringBuilder();
            int xU = 0;
            string xTmp = "";
            int xLen = pValue.Length - 1;

            byte[] xKodBytes;
            byte[] xSifreBytes;

            try
            {
                switch (pEncoding)
                {
                    case "ascii":
                        xKodBytes = Encoding.ASCII.GetBytes(pValue);
                        xSifreBytes = Encoding.ASCII.GetBytes(pKey);
                        break;
                    case "utf8":
                        xKodBytes = Encoding.UTF8.GetBytes(pValue);
                        xSifreBytes = Encoding.UTF8.GetBytes(pKey);
                        break;
                    default:
                        xKodBytes = Encoding.GetEncoding("iso-8859-9").GetBytes(pValue);
                        xSifreBytes = Encoding.GetEncoding("iso-8859-9").GetBytes(pKey);
                        break;
                }

                for (int i = 0; i <= xLen; i++)
                {

                    int x = xKodBytes[i];
                    int y = xSifreBytes[xU];

                    int z = x ^ y;

                    xTmp = z.ToString("X2");

                    if (xTmp.Length == 1)
                    {
                        xTmp = "0" + xTmp;
                    }

                    xOut.Append(xTmp);

                    if (xU == pKey.Length - 1)
                    {
                        xU = 0;
                    }
                    else
                    {
                        xU = xU + 1;
                    }
                }
                return xOut.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        }
}

   
