using Advertisment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisment.Core.DTOs
{
    public class AdvertiserDTO
    {
            public int id { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public int sumGeneralLikes { get; set; }

    }
}
