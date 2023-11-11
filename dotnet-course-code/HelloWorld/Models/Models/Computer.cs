using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Computer
    {
        //private string _motherboard;
        public string Motherboard { get; set; } = "";
        public int CPUCores { get; set; }
        public bool HasWifi { get; set; }
        public bool HasLTE { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string VideoCard { get; set; } = "";

    }
}
