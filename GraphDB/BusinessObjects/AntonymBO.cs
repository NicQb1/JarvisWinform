﻿using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDB.BusinessObjects
{
   public  class AntonymBO
    {
        private List<float> currentLevels;
        public int memoryLength;
        private List<WordBO> antonyms;
        public string text;

        public void SetMemoryLength(int count)
        {
            memoryLength = count;
        }
        public List<WordBO> Antonyms
        {
            get
            {
                if (antonyms == null)
                    antonyms = new List<WordBO>();
                return antonyms;
            }

            set
            {
                antonyms = value;
            }
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
