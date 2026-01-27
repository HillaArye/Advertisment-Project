using Advertisment.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisment.Core.DTOs
{
    public class AdverDTO
    {
       
        public int id { get; set; }
        public string desc { get; set; }
        public DateOnly date { get; set; }
        public TimeOnly start { get; set; }
        public TimeOnly end { get; set; }
        public int sumLikes { get; set; }
    }
}
