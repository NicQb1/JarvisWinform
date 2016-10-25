using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDB.BusinessObjects
{
    public class WordBO : BOBase
    {
        private List<float> currentLevels;
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
        public List<float> CurrentLevel
        {
            get
            {
                if (currentLevels == null)
                    currentLevels = new List<float>();
                return currentLevels;
            }

            set
            {
                currentLevels = value;
            }
        }
        public void SetMemoryLength(int count)
        {
            memoryLength = count;
        }
    }
}
