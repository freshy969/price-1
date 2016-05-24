using System.Collections.Generic;

namespace Model.Item
{
    public class Item : Model
    {
        public string Url { get; set; }

        public string Text { get; set; }

        public Item(int id, Metadata metadata) : base(id, metadata)
        {

        }

        public override string ToString()
        {
            return $"Id: {Id}, Text: {Text}";
        }
    }
}
