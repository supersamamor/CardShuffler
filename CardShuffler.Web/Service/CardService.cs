using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CardShuffler.Web.Service
{
    public class CardService : ICardService
    {
        private readonly HttpClient _client;

        public CardService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IList<int>> GetShuffledCards()
        {
            IList<int> cardList = new List<int>();
            var response = await _client.GetAsync(RouteResources.ShuffleCards);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            cardList = JsonConvert.DeserializeObject<IList<int>>(responseString);

            return cardList;
        }
    }
}
