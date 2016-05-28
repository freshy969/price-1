using System;
using Data.Entities.Item;
using Model.Item;

namespace BusinessLogic.Mappers
{
    internal class ItemMapper
    {
        internal static Item MapToModel(ItemEntity item)
        {
            return new Item()
            {
                Id = item.Id,
                Code = item.Code,
                Name = item.Text,
                Unit = item.Unit
            };
        }

        public static string GetLabel(ItemEntity item)
        {
            return item.Text + ", " + item.Unit;
        }

        internal static ItemDto MapToDto(ItemEntity item)
        {
            return new ItemDto
            {
                Code = item.Code,
                Label = GetLabel(item)
            };
        }
    }
}
