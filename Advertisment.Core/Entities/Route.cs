using System.ComponentModel.DataAnnotations;

namespace Advertisment.Core.Entities
{

    public class Route
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
    }
}
