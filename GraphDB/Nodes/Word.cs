using GraphDB.BusinessObjects;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDB.Nodes
{
    public class Word
    {
        public Session CurrentSession { get; set; }
        public GraphClient client;
        public string text;

        public Word(Session crntSession)
        {
            CurrentSession = crntSession;
            client = CurrentSession.client;
        }

        public WordBO GetOrCreateWord(string word)
        { 
            return client.Cypher
                .WithParams(new
                {
                    word
                })
                .Merge("(w:Word { Word = {word})")
                .Create("w")
                .Return(w => w.As<WordBO>())
                .Results
                .Single();
        }

        public void RelateIfNotAlready(string word, string pos)
        {
            client.Cypher
      .Match("(word:Word)", "(pos:PartOfSpeech)")
      .Where((WordBO wd) => wd.text == word)
      .AndWhere((PartOfSpeechBO ps) => ps.partOfSpeech == pos)
      .CreateUnique("word<-[:WORD_POS]->pos")
      .ExecuteWithoutResults();

        }

        public void AddSynonymRelationships(List<string> synonyms)
        {
            Synonym syn = new Synonym(CurrentSession);

            foreach(string synonym in synonyms)
            {
                syn.GetOrCreateSynonym(text, synonym);
            }
        }

        public void AddAntonymRelationships(List<string> antonyms)
        {
            Antonym syn = new Antonym(CurrentSession);

            foreach (string antonym in antonyms)
            {
                syn.GetOrCreateAntonym(text, antonym);
            }
        }

        public void CreateRelationshipWordPOS(WordBO word, PartOfSpeechBO pos)
        {
            RelationshipDescription rd = new RelationshipDescription(CurrentSession);
            RelationshipDescriptionBO rdBO = rd.GetRelationShip(word.text, pos.partOfSpeech);

            client.Cypher
  .Match("(word:Word)", "(rdBO:RelationshipDescription)")
  .Where((WordBO wd) => wd.text == word.text)
  .AndWhere((RelationshipDescriptionBO ps) => ps.node1 == word.text && ps.node2 == pos.partOfSpeech)
  .CreateUnique("word<-[:WORD_REL_P]->rdBO")
  .ExecuteWithoutResults();

            client.Cypher
.Match(  "(rdBO:RelationshipDescription)", "(pos:PartOfSpeech)")
.Where((RelationshipDescriptionBO ps) => ps.node1 == word.text && ps.node2 == pos.partOfSpeech)
.AndWhere((PartOfSpeechBO pss) => pss.partOfSpeech == pos.partOfSpeech  )
.CreateUnique("rdBO<-[:W_REL_POS]->pos")
.ExecuteWithoutResults();
        }

    }
}
