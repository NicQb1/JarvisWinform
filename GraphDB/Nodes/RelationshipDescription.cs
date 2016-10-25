using GraphDB.BusinessObjects;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDB.Nodes
{
    public class RelationshipDescription
    {
        public Session CurrentSession { get; set; }
        public GraphClient client;
        public string type;

        public RelationshipDescription(Session crntSession)
        {
            CurrentSession = crntSession;
            client = CurrentSession.client;
        }

        public RelationshipDescriptionBO GetRelationShip(string word1, string word2)
        {
            RelationshipDescriptionBO relNode = client.Cypher.Merge("(p:RelationshipDescription ")
                 .WithParam("jim", new RelationshipDescriptionBO { node1 = "word1", node2 = "word2" })
                 .Return(p => p.As<RelationshipDescriptionBO>())
                 .Results
                 .Single()
                 ;
            if(relNode== null)
            {
                return client.Cypher
               .WithParams(new
               {
                   word1,
                   word2
               })
               .Merge("(w:RelationshipDescription { node1 = {word1}, node2 = {word2})")
               .Create("w")
               .Return(w => w.As<RelationshipDescriptionBO>())
               .Results
               .Single();

            }
            return relNode;
        }
    }
}
