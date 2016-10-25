using GraphDB.BusinessObjects;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDB.Nodes
{
    public class PartOfSpeech
    {
        public Session CurrentSession { get; set; }
        public string partOfSpeech { get; internal set; }

        public GraphClient client;

        public PartOfSpeech(Session crntSession)
        {
            CurrentSession = crntSession;
            client = CurrentSession.client;
        }

        public PartOfSpeechBO GetOrCreatePartOfSpeech(string pos)
        {
            return client.Cypher
                .WithParams(new
                {
                    pos
                })
                .Merge("(w:PartOfSpeech { PartOfSpeech = {pos})")
                .Create("w")
                .Return(w => w.As<PartOfSpeechBO>())
                .Results
                .Single();
        }

    }
}
