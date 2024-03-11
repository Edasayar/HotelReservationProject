namespace RapidApiConsume.Models
{
    public class Data
    {
        public object lookbackServlet { get; set; }
        public string autobroadened { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public object document_id { get; set; }
        public string url { get; set; }
        public List<Child> children { get; set; }
        public string scope { get; set; }
        public string name { get; set; }
        public string data_type { get; set; }
        public Details details { get; set; }
        public string airportCode { get; set; }
        public string shortName { get; set; }
        public int value { get; set; }
        public string coords { get; set; }
    }
}
