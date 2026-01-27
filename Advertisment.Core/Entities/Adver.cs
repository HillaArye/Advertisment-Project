using Advertisment.Core.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Advertisment.Core.Entities
{
    public class Adver
    {
        public int id { get; set; }
        public string desc { get; set; }
        public Advertiser Advertiser { get; set; }
        public DateOnly date { get; set; }
        public TimeOnly start { get; set; }
        public TimeOnly end { get; set; }
        public int sumLikes {  get; set; }
    }
}
