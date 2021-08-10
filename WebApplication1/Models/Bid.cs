using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_TCO.Models
{
    public class Bid
    {
        public DateTime Date { get; set; }
        public string Aud { get; set; }
        public bool Put { get; set; }
        public string Date_Put { get; set; }
        public bool Take { get; set; }
        public string Date_Take { get; set; }
        public string Obor { get; set; }
        public string Prepod { get; set; }
        public int Id { get; set; }
    }
}
