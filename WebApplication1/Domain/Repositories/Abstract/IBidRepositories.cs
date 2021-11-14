using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_TCO.Models;

namespace Web_TCO.Domain.Repositories.Abstract
{
    public interface IBidRepositories
    {
        IList<Bid> GetBids();
        Bid GetBid(int id);
        void SaveBid(Bid bid);
        void DeleteBid(int id);
    }
}
