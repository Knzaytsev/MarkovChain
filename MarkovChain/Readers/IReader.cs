using System;
using System.Collections.Generic;
using System.Text;

namespace MarkovChain
{
    interface IReader
    {
        string ReadText(string str, bool isLower);
    }
}
