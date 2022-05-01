using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadMFI
{
    public class Vinezher
    {
        public Vinezher()
        {
        }

        public string Decrypt(string text, string gamma)
        {
            var result = "";
            for (var i = 0; i < text.Length; ++i)
            {
                result += (char)(text[i] - gamma[i % gamma.Length]);
            }
            return result;
        }

        public string Encrypt(string text, string gamma)
        {
            var result = "";
            for (var i = 0; i < text.Length; ++i)
            {
                result += (char)(text[i] + gamma[i % gamma.Length]);
            }
            return result;
        }
    }
}
