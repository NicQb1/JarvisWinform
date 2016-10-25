using GraphDB.BusinessObjects;
using GraphDB.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDB
{
    public class Graph
    {
        private Session session;
        private Word wordAccess;

        private List<WordBO> wordList;
        private List<PartOfSpeechBO> POSList;
        private List<POSTupleBO> POSTuple;
        private List<POSTuplePairsBO> POSTuplePairs;
        private List<POSTuplePairsX2BO> POSTuplePairs2;
        private List<POSTuplePairsX3BO> POSTuplePairs3;
        private List<POSTuplePairsX4BO> POSTuplePairs4;
        private List<SynonymBO> synonyms;
        private List<AntonymBO> antonyms;

        public Session Session
        {
            get
            {
                if (session == null)
                    session = new Session();
                return session;
            }

            set
            {
                session = value;
            }
        }

        public Word WordAccess
        {
            get
            {
                if(wordAccess == null)
                    wordAccess = new Word(Session);
                return wordAccess;
            }

            set
            {
                wordAccess = value;
            }
        }
        public List<WordBO> WordList
        {
            get
            {
                if (wordList == null)
                    wordList = new List<WordBO>();
                return wordList;
            }

            set
            {
                wordList = value;
            }
        }



        public void inputWord(string[] words, int count)
        {
            for (int i = 0; i < words.Length; i++)
            {
               
                WordBO tmp = wordList.Where(e => e.text == words[i]).SingleOrDefault();
                if(tmp == null)
                {
                    tmp= WordAccess.GetOrCreateWord(words[i]);
                    tmp.SetMemoryLength(words.Length - i);
                    wordList.Add(tmp);

                }

                if(i >0)
                {
                    for(int c = 0; c <i; c++)
                    {

                    }

                    for (int c = i; c >0; c--)
                    {

                    }
                }

            }
            
           
        }
    }
}
