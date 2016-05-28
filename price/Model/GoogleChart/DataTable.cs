using Newtonsoft.Json;
using System.Collections.Generic;

namespace Model.GoogleChart
{
    [JsonObject(MemberSerialization.OptIn)]
    public class DataTable
    {
        [JsonProperty("cols")]
        public List<TableColumn> Cols { get; set; }

        [JsonProperty("rows")]
        public List<TableRow> Rows { get; set; }
    }
}
