using GraphDB.BusinessObjects;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDB.Nodes
{
    public class Synonym
    {
        public Session CurrentSession { get; set; }
        public GraphClient client;
        public string text;

        public Synonym(Session crntSession)
        {
            CurrentSession = crntSession;
            client = CurrentSession.client;
        }

        public  SynonymBO GetOrCreateSynonym(string word1, string word2)
        {
            if(word1.CompareTo(word2)>0)
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
               .Merge("(w:Synonym { Word1 = {word1}, Word2 ={word2})")
               .Create("w")
               .Return(w => w.As<SynonymBO>())
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
      .CreateUnique("word1<-[:SYNONYM]->word2")
      .ExecuteWithoutResults();

        }
    }
}
