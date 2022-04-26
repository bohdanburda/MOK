using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadMFI
{
    public class CaesarCipher
    {
        private int Key { get; set; }
        public CaesarCipher(int key) 
        {
            Key = key;
        }
        private string CodeEncode(string text, int key)
        {
            var result = "";
            for (int i = 0; i < text.Length; i++)
            {
                result += (char)((int)text[i] + key);
            }

            return result;
        }
        public string Encrypt(string plainMessage)
            => CodeEncode(plainMessage, Key);

        public string Decrypt(string encryptedMessage)
            => CodeEncode(encryptedMessage, -Key);
    }
}
