using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class ComputerSnake
    {
        //private string _motherboard;

        public int computer_id { get; set; }
        public string motherboard { get; set; } = "";
        public int? cpu_cores { get; set; } = 0;
        public bool has_wifi { get; set; }
        public bool has_lte { get; set; }
        public DateTime? release_date { get; set; }
        public decimal price { get; set; }
        public string video_card { get; set; } = "";

    }
}
