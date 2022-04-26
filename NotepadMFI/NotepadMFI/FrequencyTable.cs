using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadMFI
{
    public class FrequencyTable
    {
        private string Data { get; set; }
        private Dictionary<char, int> Dictionary { get; set; }
        public FrequencyTable(string data)
        {
            Data = data;
            Dictionary = new Dictionary<char, int>();
            CreateFrequencyTable();
        }
        private void CreateFrequencyTable()
        {
            foreach (var ch in Data)
            {
                if (Dictionary.ContainsKey(ch))
                {
                    Dictionary[ch]++;
                }
                else
                {
                    Dictionary.Add(ch, 1);
                }
            }
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Dictionary); ;
        }
    }
}
