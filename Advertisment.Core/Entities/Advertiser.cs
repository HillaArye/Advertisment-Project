namespace Advertisment.Core.Entities
{
    public class Advertiser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public Route Route { get; set; }
        public int sumGeneralLikes { get; set; }

    }
}
