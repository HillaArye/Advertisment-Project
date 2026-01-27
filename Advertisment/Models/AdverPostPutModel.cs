using Advertisment.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Advertisment.Models
{
    public class AdverPostPutModel
    {
        [Key] public int id { get; set; }
        public string desc { get; set; }
        public DateOnly date { get; set; }
        public TimeOnly start { get; set; }
        public TimeOnly end { get; set; }
        public int sumLikes { get; set; }
    }
}
