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
                while (!fs.EndOfStream)
                {
                    var curStr = "";
                    curStr = fs.ReadLine();
                    if (curStr == "")
                        continue;
                    text += " " + curStr;
                }
                //text = fs.ReadLine();
            }
            if (isLower)
            {
                text = text.ToLower();
            }
            return text;
        }
    }
}
