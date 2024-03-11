namespace RapidApiConsume.Models
{
    public class Details
    {
        public int placetype { get; set; }
        public string parent_name { get; set; }
        public string grandparent_name { get; set; }
        public int grandparent_id { get; set; }
        public int parent_id { get; set; }
        public int grandparent_place_type { get; set; }
        public string highlighted_name { get; set; }
        public string name { get; set; }
        public int parent_place_type { get; set; }
        public List<int> parent_ids { get; set; }
        public string geo_name { get; set; }
        public string address { get; set; }
    }
}
