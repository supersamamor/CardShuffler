using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardShuffler.Web.Service
{
    public interface ICardService
    {
        Task<IList<int>> GetShuffledCards();
    }
}
