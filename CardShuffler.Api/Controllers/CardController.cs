using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardShuffler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        [HttpGet("Shuffle")]
        public IList<int> ShuffleCard()
        {         
            return Shuffler(DataSeeder());
        }


        public IList<int> Shuffler(IList<int> cardList) {          
            //Randomize
            cardList = cardList.OrderBy(l => Guid.NewGuid()).ToList();

            return cardList;
        }

        private IList<int> DataSeeder() {
            //Fill Data
            var CardList = new List<int>();
            for (int a = 1; a <= 52; a++)
            {
                CardList.Add(a);
            }
            return CardList;
        }
    }
}