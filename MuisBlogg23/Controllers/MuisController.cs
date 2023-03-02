using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MuisBlogg23.Models;

namespace MuisBlogg23.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class MuisController : ControllerBase
    {
        private readonly IMongoCollection<Muis> _muis;
        public MuisController(IOptions<DatabasSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _muis = mongoDatabase.GetCollection<Muis>(settings.Value.MuisCollectionName);
        }

        [HttpGet]
        public async Task<List<Muis>> GetAll()
        {
            List<Muis> foundMuisar = await _muis.Find(_ => true).ToListAsync();
            return foundMuisar;

        }

        [HttpPost]
        public async Task CreateMuisPost(Muis muis)
        {
            await _muis.InsertOneAsync(muis);
          
        } 
    }

 
    
}
 

