namespace Model
{
    public abstract class Model
    {
        public int Id { get; set; }

        public Metadata Metadata { get; set; }

        protected Model(int id, Metadata metadata)
        {
            Id = id;
            Metadata = metadata;
        }
    }
}
