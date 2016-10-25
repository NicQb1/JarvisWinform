using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDB.BusinessObjects
{
    public class POSTuplePairsX3BO:BOBase
    {
        private List<float> currentLevels;
        public int memoryLength;
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
