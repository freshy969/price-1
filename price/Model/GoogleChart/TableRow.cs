using Newtonsoft.Json;
using System.Collections.Generic;

namespace Model.GoogleChart
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TableRow
    {
        [JsonProperty("c")]
        public List<TableCell> Cells { get; set; }
    }
}