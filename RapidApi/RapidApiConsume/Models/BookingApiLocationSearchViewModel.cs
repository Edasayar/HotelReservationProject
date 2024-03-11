namespace RapidApiConsume.Models
{
    public class BookingApiLocationSearchViewModel
    {

        public class Rootobject
        {
      
            public Datum[] data { get; set; }
        }

        public class Datum
        {
            public string dest_id { get; set; }
            public string search_type { get; set; }
            public float latitude { get; set; }
            public string name { get; set; }
      
            public string region { get; set; }
            public int hotels { get; set; }
            public int? city_ufi { get; set; }
            public string dest_type { get; set; }
      
            public string city_name { get; set; }
            public string country { get; set; }
       
            public string image_url { get; set; }
        }


    }
}
