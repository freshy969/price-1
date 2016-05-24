namespace Model
{
    public abstract class LinkModel
    {
        public int Id { get; set; }

        protected LinkModel(int id)
        {
            Id = id;
        }
    }
}
