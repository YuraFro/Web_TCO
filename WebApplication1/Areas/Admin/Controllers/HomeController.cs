using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Web_TCO.Domain.Repositories.Abstract;
using Web_TCO.Domain.Repositories.EntityFramework;
using Web_TCO.Models;

namespace Web_TCO.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IBidRepositories eFBid;
        private DateTime _PostDate { get; set; }

        public HomeController(IBidRepositories eFBid)
        {
            this.eFBid = eFBid;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var bids = eFBid.GetBids();

            return View(model: bids);
        }

        [HttpPost]
        public IActionResult Index(DateTime PostDate, Bid? bid, int? ID)
        {
            if (PostDate.ToString() != "01.01.0001 0:00:00")
            {
                _PostDate = PostDate;
            }

            if (bid.Prepod != null)
            {
                eFBid.SaveBid(bid);
                _PostDate = bid.Date;
            }

            if (ID != null)
            {
                eFBid.DeleteBid(bid.Id);
            }

            var bids = eFBid.GetBids(_PostDate);

            return View(model: bids);
        }

    }
}