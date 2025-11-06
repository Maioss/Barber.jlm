using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class BarberShop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slogan { get; set; }
        public decimal Rating { get; set; }
        public string Location { get; set; }
    }
}