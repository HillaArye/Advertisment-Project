using System.ComponentModel.DataAnnotations;

namespace Advertisment.Models
{
    public class RoutePostPutModel
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }   
    }
}
