using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MuisBlogg23.Models
{
    public class File
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FileId { get; set; }
        public string FileUrl { get; set; }
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
        public string ContentType { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.Now;
        
    }
}
