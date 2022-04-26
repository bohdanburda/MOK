using System.Linq;

namespace NotepadMFI
{
    public abstract class TrithemiusCipher
    {
        private readonly string AlphabetENB = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly string AlphabetENS = "abcdefghijklmnopqrstuvwxyz";
        private readonly string AlphabetUkB = "АБВГДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";
        private readonly string AlphabetUkS = "абвгдеєжзиіїйклмнопрстуфхцчшщьюя";
        private string Alphabet { get; set; }
        private int N { get; set; }

        protected TrithemiusCipher()
        {
            Alphabet = AlphabetENB + AlphabetENS + AlphabetUkB + AlphabetUkS;
            N = Alphabet.Length;
        }
        public string Encrypt(string text)
        {
            var result = "";

            for (int i = 0; i < text.Length; i++)
            {
                char x = text[i];
                if (Alphabet.Contains(x))
                {
                    var pos = Alphabet.IndexOf(x);
                    var k = GetK(i);
                    result += Alphabet[((pos + k) % N)];
                }
                else
                {
                    result += x;
                }
            }

            return result;
        }

        public string Decrypt(string text)
        {
            var result = "";

            for (int i = 0; i < text.Length; i++)
            {
                char y = text[i];
                if (Alphabet.Contains(y))
                {
                    var pos = Alphabet.IndexOf(y);
                    var k = GetK(i);
                    result += Alphabet[((pos + N - (k % N)) % N)];
                }
                else
                {
                    result += y;
                }
            }

            return result;
        }

        protected abstract int GetK(int p);
    }

    public class LiniarTrithemiusCipher : TrithemiusCipher
    {
        public int A { get; private set; }
        public int B { get; private set; }
        public LiniarTrithemiusCipher(int a, int b)
        {
            A = a;
            B = b;
        }
        protected override int GetK(int p)
        {
            return (A * p + B);
        }
    }

    public class NoLiniarTrithemiusCipher : TrithemiusCipher
    {
        public int A { get; private set; }
        public int B { get; private set; }
        public int C { get; private set; }
        public NoLiniarTrithemiusCipher(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }
        protected override int GetK(int p)
        {
            return (A * p * p + B * p + C);
        }
    }

    public class HasloTrithemiusCipher : TrithemiusCipher
    {
        public string Haslo { get; private set; }
        public HasloTrithemiusCipher(string s)
        {
            Haslo = s;
        }
        protected override int GetK(int p)
        {
            return Haslo[p % Haslo.Length];
        }
    }
}
