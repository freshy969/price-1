using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Model.GoogleChart
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TableCell
    {
        [JsonProperty("v")]
        public object Value { get; set; }

        [JsonProperty("f")]
        public string Tooltip { get; set; }
    }
}