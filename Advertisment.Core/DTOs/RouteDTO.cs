using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisment.Core.DTOs
{
    public class RouteDTO
    {
       
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
    }
}
