using GraphDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSpeech
{
    public class SpeechProcessor
    {
        private Graph graphdb;

      
        public Graph Graphdb
        {
            get
            {
                if (graphdb == null)
                    graphdb = new Graph();
                return graphdb;
            }

            set
            {
                graphdb = value;
            }
        }
        public SpeechProcessor()
        {
           
        }


        public void Input_text(string text)
        {
            string[] wordList = text.Split(' ');
            int count = wordList.Length;
            

             

        }
    }
}
