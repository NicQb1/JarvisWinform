using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDB
{
    public class Session
    {
        private GraphClient _client;
        public virtual GraphClient client
        {
            get
            {
                if (_client == null)
                {
                    _client = new GraphClient(new Uri("http://localhost:7474/db/data"));
                }
                if (!_client.IsConnected)
                    _client.Connect();
                return _client;

            }

        }
    }
}
