using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_TCO.Models;

namespace Web_TCO.Controllers
{
    public class HomeController : Controller
    {
        private List<Bid> bids { get; set; }
        private string _PostDate { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index (string? Date)
        {
            bids = await DataBase.Out(Date);

            return View(model: bids);
        }

        [HttpPost]
        public async Task<IActionResult> Index(DateTime PostDate, Bid? bid, int? ID)
        {
            _PostDate = PostDate.ToString();

            if (bid.Prepod != null)
            {
                await DataBase.Input(bid);
                _PostDate = bid.Date.ToString();
            }

            if (ID != null)
            {
                await DataBase.Delete(ID);
            }

            bids = await DataBase.Out(_PostDate);
            return View(model: bids);
        }
    }
}
