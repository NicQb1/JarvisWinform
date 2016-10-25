using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDB.BusinessObjects
{
    public class POSTuplePairsX4BO:BOBase
    {
        public int memoryLength;
        public void SetMemoryLength(int count)
        {
            memoryLength = count;
        }
    }
}
