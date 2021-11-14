using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_TCO.Domain.Repositories.Abstract;
using Web_TCO.Models;

namespace Web_TCO.Domain.Repositories.EntityFramework
{
    public class EFBidRepositories : IBidRepositories
    {
        private readonly AppDbContext _appDbContext;

        public EFBidRepositories (AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void DeleteBid(int id)
        {
            _appDbContext.Bids.Remove(new Bid { Id = id });
            _appDbContext.SaveChanges();
        }

        public Bid GetBid(int id)
        {
            return _appDbContext.Bids.FirstOrDefault(x => x.Id == id);
        }

        public IList<Bid> GetBids()
        {
            return _appDbContext.Bids.ToList();
        }

        public void SaveBid(Bid bid)
        {
            if (bid.Id == default)
                _appDbContext.Entry(bid).State = EntityState.Added;
            else
                _appDbContext.Entry(bid).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }
    }
}
