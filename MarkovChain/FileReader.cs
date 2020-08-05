using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MarkovChain
{
    class FileReader : IReader
    {
        public string ReadText(string str, bool isLower = false)
        {
            var text = "";
            using (var fs = new StreamReader(str))
            {
                text = fs.ReadLine();
            }
            if (isLower)
            {
                text = text.ToLower();
            }
            return text;
        }
    }
}
