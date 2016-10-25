using GraphDB.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDB.BusinessObjects
{
    public class RelationshipDescriptionBO
    {
        private List<float> currentLevels;
        public int memoryLength;
        public List<RelationshipDataStruct> relationships;
        public string type;
        public string node1;
        public string node2;
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
