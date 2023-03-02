using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MuisBlogg23.Models
{
    public class Muis
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

         public string Namn{ get; set; }   
    }
}
