using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDB.BusinessObjects
{
    public class WordBO : BOBase
    {
        public int memoryLength;
        public string text;

        public List<PartOfSpeechBO> POSList
        {
            get
            {
                if (pOSList == null)
                    pOSList = new List<PartOfSpeechBO>();
                return pOSList;
            }

            set
            {
                pOSList = value;
            }
        }
        private List<PartOfSpeechBO> pOSList;
        public void SetMemoryLength(int count)
        {
            memoryLength = count;
        }
    }
}
