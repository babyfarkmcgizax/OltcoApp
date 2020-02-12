using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OltcoApp.Models
{
    public class Installation
    {
        public int installation_id { get; set; }
        public int installation_cost { get; set; }
        public int installation_extras { get; set; }
        public int installation_size { get; set; }
        public int stone_reading_humidity { get; set; }
        public int stone_reading_temperature { get; set; }
       // public int customer_id { get; set; }
    }
}
