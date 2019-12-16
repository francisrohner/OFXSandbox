using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OFX_Sandbox.Utilities
{
    public static class Utils
    {
        private const string IDENTIFIER_CHARS_STRING = "0123456789";
        private static readonly char[] IDENTIFIER_CHARS = IDENTIFIER_CHARS_STRING.ToCharArray();

        public static string GenerateRandomString(int length)
        {
            return GenerateRandomString(IDENTIFIER_CHARS, length);
        }
        public static string GenerateRandomString()
        {
            return GenerateRandomString(IDENTIFIER_CHARS, 8);
        }
        public static string GenerateRandomString(char[] allowedCharacters, int length)
        {
            string newCode = null;
            byte[] randomBytes = new byte[length];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);
            char[] chars = new char[length];
            int countAllowedCharacters = allowedCharacters.Length;
            for (int i = 0; i < length; i++)
            {
                int currentRandomNumber = Convert.ToInt32(randomBytes[i]);
                chars[i] = allowedCharacters[currentRandomNumber % countAllowedCharacters];
            }
            newCode = new string(chars);
            return newCode;
        }

        public static string NewUUID() => Guid.NewGuid().ToString().Replace("-", "");        

        public static readonly List<Institution> Institutions = new List<Institution>() //TODO fetch from some website
        {
            new Institution("Chase", "B1", "10898", "https://ofx.chase.com")
        };

        public static string GetInstitutionEndpoint(string organization, string financialId)
        {
            return Institutions
                .FirstOrDefault(inst => inst.Equals(
                    new Institution(organization, financialId)))?.Endpoint ?? string.Empty;            
        }
        public static Institution GetInstitution(string displayName)
        {
            return Institutions.FirstOrDefault(inst => inst.DisplayName.Equals(displayName));
        }

        public static bool StoreEncryptedObject(string filePath, object obj) 
            => StoreObject(filePath, obj, true);

        public static T LoadEncryptedObject<T>(string filePath)
            => LoadObject<T>(filePath, true);

        public static bool StoreObject(string filePath, object obj, bool encrypted = false)
        {
            try
            {
                string json = JsonConvert.SerializeObject(obj);
                if(encrypted)
                {
                    json = Encrypt(json);
                }
                File.WriteAllText(filePath, json);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }
        public static T LoadObject<T>(string filePath, bool encrypted = false)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                if(encrypted)
                {
                    //decrypt json here
                    json = Decrypt(json);
                }
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return default(T);
        }

        //TODO generate these on first run and store somewhere in registry
        //128bit
        //https://www.allkeysgenerator.com/Random/Security-Encryption-Key-Generator.aspx
        private static readonly string PasswordHash = "d41d8cd98f00b204e9800998ecf8427e";
        private static readonly string SaltKey = "482B4D6251655468566D597133743677";
        private static readonly string IV = "34743777217A25432A462D4A614E6452";

        //Original: https://stackoverflow.com/a/311179
        public static string ToHex(byte[] arr)
        {
            return BitConverter.ToString(arr).Replace("-", "");
        }
        public static byte[] FromHex(string hex, int? cutoff = null)
        {            
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            if(cutoff.HasValue)
            {
                byte[] ret = new byte[cutoff.Value > bytes.Length ? bytes.Length : cutoff.Value];
                Array.Copy(bytes, 0, ret, 0, ret.Length);
                bytes = ret;
            }
            return bytes;
        }

        public static string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);            
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, FromHex(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, FromHex(IV));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }
        public static string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, FromHex(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, FromHex(IV));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
        public static string GetDateTimeStr() => DateTime.Now.ToString("yyyyMMddHHmmss.fff");
    }
    public class Institution : IEquatable<Institution>
    {
        public string DisplayName;
        public string Organization;
        public string FinancialId;
        public string Endpoint;
        public Institution(string org, string fid)
        {
            Organization = org;
            FinancialId = fid;
        }
        public Institution(string dispName, string org, string fid, string endpoint) : this(org, fid)
        {
            DisplayName = dispName;
            Endpoint = endpoint;
        }        
        public bool Equals(Institution other) =>
             other != null &&
                Organization.Equals(other.Organization) &&
                FinancialId.Equals(other.FinancialId);
        public override string ToString() => DisplayName ?? string.Empty;
    }
}
