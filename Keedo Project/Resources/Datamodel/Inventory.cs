using Newtonsoft.Json;

namespace Keedo_Project.Resources.Datamodel
{
    //public class DataContainer
    //{
    //    public List<Inventory> Inventory { get; set; }
    //}

    public class Inventory
    {
        //Model data so it matches my backend database

        [JsonProperty("InventoryID")]
        public string InventoryID { get; set; }

        [JsonProperty("ISBN")]
        public string ISBN { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Authors")]
        public string Authors { get; set; }

        [JsonProperty("Publisher")]
        public string Publisher { get; set; }

        [JsonProperty("Year")]
        public string Year { get; set; }

        [JsonProperty("Language")]
        public string Language { get; set; }

        [JsonProperty("Price")]
        public string Price { get; set; }

        [JsonProperty("Cover")]
        public string Cover { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("UserID")]
        public string UserID { get; set; }

        //[JsonProperty("Status")]
        //public int Status { get; set; }

        //[JsonProperty("Module")]
        //public string Module { get; set; }

    }
}