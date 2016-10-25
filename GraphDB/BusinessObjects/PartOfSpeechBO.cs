using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDB.BusinessObjects
{
    public class PartOfSpeechBO : BOBase
    {
        public int memoryLength;
        public string partOfSpeech { get; internal set; }
        public void SetMemoryLength(int count)
        {
            memoryLength = count;
        }
    }
}
