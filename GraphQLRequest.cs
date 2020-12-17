using GraphQL.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameStoreGraphQL
{
    public class GraphQLRequest
    {
        public string Query { get; set; }

        [JsonConverter(typeof(ObjectDictionaryConverter))]
        public Dictionary<string,object> Variables { get; set; }
    }
}
