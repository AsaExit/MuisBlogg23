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

        [HttpPost("MUISACTION!!!!!")]
        public async Task<MuisDoingStuff> MuisAction(string id)
        {
            Muis muis = await _muis.Find(m => m.Id == id).FirstOrDefaultAsync();

            string action = Random.Shared.Next(5) switch
            {
                0 => $"{muis.Namn} rolls around in the green grass",
                < 1 => $"{muis.Namn} licks the fence",
                < 2 => $"{muis.Namn} smells the flowers",
                < 3 => $"{muis.Namn} falls asleep on its back",
                < 4 => $"{muis.Namn} jumps around!",
                < 5 => $"{muis.Namn} says MU!",
                _ => "MUIS ERROR"
            };

            return new MuisDoingStuff()
            {
                MuisName = muis.Namn,
                MuisAction = action,
            };

        }

    }

 
    
}
 

