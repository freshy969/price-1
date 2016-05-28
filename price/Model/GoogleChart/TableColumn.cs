using Newtonsoft.Json;

namespace Model.GoogleChart
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TableColumn
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}