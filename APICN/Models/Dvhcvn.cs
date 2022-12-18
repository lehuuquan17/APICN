namespace APICN.Models
{
    public class Dvhcvn
    {
        public List<Datum> data { get; set; }
        public class Datum
        {
            public string level1_id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public List<Level2> level2s { get; set; }
        }

        public class Level2
        {
            public string level2_id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public List<Level3> level3s { get; set; }
        }

        public class Level3
        {
            public string level3_id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
        }

    }
}
