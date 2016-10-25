using GraphDB.BusinessObjects;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDB.Nodes
{
    public class POSTuple
    {
        public Session CurrentSession { get; set; }
        public GraphClient client;
        

        public POSTuple(Session crntSession)
        {
            CurrentSession = crntSession;
            client = CurrentSession.client;
        }

        public POSTupleBO GetOrCreatePOSTuple(string pos1, string pos2)
        {
            if (pos1.CompareTo(pos2) > 0)
            {
                string temp = pos1;
                pos1 = pos2;
                pos2 = temp;
            }
            string name = pos1 + ":" + pos2;
            return client.Cypher
                .WithParams(new
                {
                    pos1,
                    pos2,
                    name
                })
                .Merge("(w:POSTupleBO { POS1 = {pos1}, POS2 ={pos2}, Name ={name})")
                .Create("w")
                .Return(w => w.As<POSTupleBO>())
                .Results
                .Single();
        }


        public void RelateIfNotAlready(string pos1, string pos2)
        {
            if (pos1.CompareTo(pos2) > 0)
            {
                string temp = pos1;
                pos1 = pos2;
                pos2 = temp;
            }
            string name = pos1 + ":" + pos2;
            client.Cypher
      .Match("(name:POSTuple)", "(pos1:PartOfSpeech), (pos2: PartOfSpeech)")
      .Where((POSTupleBO p1) => p1.partOfSpeech == pos1)
      .AndWhere((PartOfSpeechBO ps) => ps.partOfSpeech == pos2)
      .CreateUnique("pos1-[:WORD_POS]->pos")
      .ExecuteWithoutResults();
        }

    }
}
