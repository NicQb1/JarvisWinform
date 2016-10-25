using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDB.BusinessObjects
{
    public class SynonymBO
    {
        private List<float> currentLevels;
        public int memoryLength;
        private List<WordBO> synonyms;

        public List<WordBO> Synonyms
        {
            get
            {
                if (synonyms == null)
                    synonyms = new List<WordBO>();
                return synonyms;
            }

            set
            {
                synonyms = value;
            }
        }

        public void SetMemoryLength(int count)
        {
            memoryLength = count;
        }
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
    }
}
