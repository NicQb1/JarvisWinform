using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDB.BusinessObjects
{
   public  class AntonymBO
    {
        private List<WordBO> antonyms;
        public Session CurrentSession { get; set; }
        public GraphClient client;
        public string text;

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


        public AntonymBO GetOrCreateAntonym(string word1, string word2)
        {

            if (word1.CompareTo(word2)>0)
            {
                string temp = word1;
                word1 = word2;
                word2 = temp;
            }
            return client.Cypher
               .WithParams(new
               {
                   word1,
                   word2
})
               .Merge("(w:Antonym { Word1 = {word1}, Word2 ={word2})")
               .Create("w")
               .Return(w => w.As<AntonymBO>())
               .Results
               .Single();
        }

        public void RelateIfNotAlready(string word1, string word2)
{
    if (word1.CompareTo(word2) > 0)
    {
        string temp = word1;
        word1 = word2;
        word2 = temp;
    }
    client.Cypher
.Match("(word1:Word1)", "(word2:Word2)")
.Where((WordBO wd1) => wd1.text == word1)
.AndWhere((WordBO wd2) => wd2.text == word2)
.CreateUnique("word1<-[:ANTONYM]->word2")
.ExecuteWithoutResults();

}
    }
}
