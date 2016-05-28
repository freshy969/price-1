using Data.Generic;

namespace Data.Entities.Item
{
    public class ItemEntity : IGenericEntity
    {
        public virtual long Id { get; set; }

        public virtual string Code { get; set; }

        public virtual string Text { get; set; }

        public virtual string Unit { get; set; }

        public ItemEntity() { }

        public ItemEntity(string text)
        {
            Text = text;
            Code = text;
        }
    }
}
