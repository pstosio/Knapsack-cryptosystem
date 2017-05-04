using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Knapsack_cryptosystem
{
    /// <summary>
    /// Algorytm szyfrujący plecakowy.
    /// </summary>
    public class Knapsack
    {
        /// <summary>
        /// Zawsze używamy 8-elementowego klucza, każdy element musi być większy niż suma poprzedników
        /// Wartości przykładowe ze strony: http://edu.pjwstk.edu.pl/wyklady/bdk/scb/main46.html
        /// </summary>
        private int[] privateKey = { 1, 3, 7, 13, 26, 65, 119, 267 };
        private int[] publicKey;

        /// <summary>
        /// Aby zakodować i zdekodować konieczna jest znajomość wartości 
        /// </summary>
        private BigInteger modValue;
        private BigInteger nValue;

        private static string divideSign = ":newBlock:";
        Encoding iso;

        public Knapsack()
        {
            iso = Encoding.GetEncoding("ISO-8859-1");
            modValue = new BigInteger(523); // <== Wartość modulo
            nValue = new BigInteger(467);   // <== Czynnik
            publicKey = this.getSequence(privateKey);
        }

        /// <summary>
        /// Tworzy klucz publiczny z prywatnego na podstawie wzoru: pubKey[i] = privKey[i] * (nValue % modValue)
        /// </summary>
        /// <param name="_seq"></param>
        /// <returns></returns>
        private int[] getSequence(int[] _seq)
        {
            int[] knapsack = new int[_seq.Length];

            for (int i = 0; i < _seq.Length; i++)
            {
                knapsack[i] = _seq[i] * (int)(nValue % modValue);
            }

            return knapsack;
        }

        private bool isBitSet(byte bt, int bit)
        {
            return (bt >> bit & 1) == 1;
        }

        /// <summary>
        /// Funkcja służąca do szyfrowania.
        /// Dane wejściowe zawsze dzielone są na bloki, które mają tyle bitów ile jest elementów klucza ( w tym przypadku zawsze 8).
        /// </summary>
        /// <param name="_plainText"></param>
        /// <returns></returns>
        public string encrypt(string _plainText)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(_plainText);
            StringBuilder stringBuilder = new StringBuilder();
            BigInteger[] encryptedBlocks = new BigInteger[bytes.Length];

            for (int i = 0; i < bytes.Length; i++)
            {
                encryptedBlocks[i] = new BigInteger();

                //Operowanie na bajtach
                for (int j = 0; j < 8; j++)
                {
                    // Sprawdzamy kolejno bity każdego bloku. 
                    if (isBitSet(bytes[i], j))
                    {
                        // Jeżeli n-ty bit jest ustawiony to dodajemy n-ty element klucza publicznego do zaszyfrowanego bloku
                        encryptedBlocks[i] += new BigInteger(publicKey[j]);
                    }
                }
            }

            for (int i = 0; i < encryptedBlocks.Length; i++)
            {
                stringBuilder.Append(encryptedBlocks[i]);
                stringBuilder.Append(divideSign);
            }

            byte[] isoBytes = iso.GetBytes(stringBuilder.ToString());
            string msg = iso.GetString(isoBytes);

            return BitConverter.ToString(isoBytes).Replace("-", string.Empty).ToLower();
        }

        /// <summary>
        /// Dekodowanie
        /// Zakodowany blok jest liczbą, jest on sumą kilku elementów klucza prywatnego.
        /// Indeks tych elementów klucza to indeksy bitów w bajcie które trzeba ustawić na 1 reszta na 0
        /// W ten sposób utworzone bajty tworzą odszyfrowaną wiadomość.
        /// </summary>
        /// <param name="_encrypted"></param>
        /// <returns></returns>
        public string decrypt(string _encrypted)
        {
            string[] splittedLine = Regex.Split(_encrypted, divideSign);
            BigInteger[] encryptedBlocks = new BigInteger[splittedLine.Length];

            for (int i = 0; i < splittedLine.Length - 1; i++)
            {
                encryptedBlocks[i] = new BigInteger(Convert.ToInt32(splittedLine[i]));
            }

            byte[] result = new byte[encryptedBlocks.Length - 1];

            for (int i = 0; i < encryptedBlocks.Length - 1; i++)
            {
                encryptedBlocks[i] /= (nValue % modValue);
                result[i] = 0;
                byte buffByte = 0;
                byte[] temp = new byte[8];

                for (int k = 0; k < 8; k++)
                {
                    temp[k] = 0;
                }

                for (int k = 7; k >= 0; k--)
                {
                    if (encryptedBlocks[i].CompareTo(new BigInteger(privateKey[k])) >= 0)
                    {
                        BigInteger buff = new BigInteger(privateKey[k]);
                        encryptedBlocks[i] -= buff;
                        temp[k] = 1;
                    }
                }

                for (int z = 0; z < 8; z++)
                {
                    buffByte = (byte)(int)(buffByte + Math.Pow(2.0d, z) * temp[z]);
                }
                result[i] = buffByte;
            }
            
            return iso.GetString(result);
        }

        public string cipherToString(string _cipher)
        {
            int NumberChars = _cipher.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(_cipher.Substring(i, 2), 16);

            return iso.GetString(bytes);
        }

        public string getPrivateKeyString()
        {
            StringBuilder ret = new StringBuilder();
            for(int i=0; i<privateKey.Length; i++)
            {
                ret.Append(privateKey[i]);
                ret.Append(" ");
            }
            return ret.ToString();
        }

        public string getPublicKeyString()
        {
            StringBuilder ret = new StringBuilder();
            for (int i = 0; i < publicKey.Length; i++)
            {
                ret.Append(publicKey[i]);
                ret.Append(" ");
            }
            return ret.ToString();
        }
    }
}
