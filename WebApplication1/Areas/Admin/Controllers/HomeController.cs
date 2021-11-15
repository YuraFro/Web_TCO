using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_TCO.Models;

namespace Web_TCO.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private List<Bid> bids { get; set; }
        private string _PostDate { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index ()
        {
            bids = await DataBase.Out(DateTime.Now.ToString("yyyy/MM/dd").Replace("/", ""));

            return View(model: bids);
        }

        [HttpPost]
        public async Task<IActionResult> Index(DateTime PostDate, Bid? bid, int? ID)
        {
            if (PostDate.ToString() != "01.01.0001 0:00:00")
            {
                _PostDate = PostDate.ToString();
            }
            
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
