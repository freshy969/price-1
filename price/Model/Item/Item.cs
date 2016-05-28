namespace Model.Item
{
    public class Item : Model
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Unit { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }
}
