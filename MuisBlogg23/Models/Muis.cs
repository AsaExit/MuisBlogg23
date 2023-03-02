using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MuisBlogg23.Models
{
    public class Muis
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Namn { get; set; }
        public string CowType { get; private set; } = Random.Shared.Next(12) switch
        {
              0 => "Angus",
            < 1 => "Hereford",
            < 2 => "Highland Cattle",
            < 3 => "Rödkulla",
            < 4 => "Blonde d’Aquitaine",
            < 5 => "Charolais",
            < 6 => "Limousin",
            < 7 => "Simmental",
            < 8 => "Svensk Röd och vit boskap",
            < 9 => "Svensk Låglandsboskap",
            < 10 => "Svensk kullig boskap",
            < 11 => "Svensk Jersey-boskap",
            < 12 => "SUPER MUIS",
            _=>"SOMETHING WRONG ERROR ERROR"
        };       
    }

    public class MuisDoingStuff
    {
        public string MuisName { get; set; }
        public string MuisAction { get; set; }
    }

}
