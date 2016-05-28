using Data.Generic;

namespace Data.Entities.Item
{
    public class ItemEntity : IGenericEntity
    {
        public virtual int Id { get; set; }

        public virtual string Url { get; set; }

        public virtual string Text { get; set; }

        public ItemEntity() { }

        public ItemEntity(string text)
        {
            Text = text;
            Url = text;
        }
    }
}
