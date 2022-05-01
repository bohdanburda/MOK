using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadMFI
{
    public class Gamma
    {
        private readonly string AlphabetENB = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly string AlphabetENS = "abcdefghijklmnopqrstuvwxyz";
        private readonly string AlphabetUkB = "АБВГДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";
        private readonly string AlphabetUkS = "абвгдеєжзиіїйклмнопрстуфхцчшщьюя";
        private string Alphabet { get; set; }
        private int N { get; set; }
        public string GammaValue { get; set; }
        public Gamma()
        {
            GammaValue = "";
            Alphabet = AlphabetENB + AlphabetENS + AlphabetUkB + AlphabetUkS;
            N = Alphabet.Length;
        }
        private void CreateGamma(int n)
        {
            var rand = new Random();
            while (GammaValue.Length < n)
            {
                var index = rand.Next(0, N);
                GammaValue += Alphabet[index];
            }
        }

        public string Decrypt(string text)
        {
            var result = "";
            for (var i = 0; i < text.Length; ++i)
            {
                result += (char)(text[i] - GammaValue[i]);
            }
            return result;
        }

        public string Encrypt(string text)
        {
            var result = "";
            CreateGamma(text.Length);
            for (var i = 0; i < text.Length; ++i)
            {
                result += (char)(text[i] + GammaValue[i]);
            }
            return result;
        }
    }
}
