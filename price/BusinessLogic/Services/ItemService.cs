using System;
using BusinessLogic.ServiceInterfaces;
using Data.Entities.Item;
using Infrastructure.Attributes;
using BusinessLogic.Mappers;
using System.Linq;
using Model.Item;
using BusinessLogic.Utils;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _rep;

        public ItemService(IItemRepository repository)
        {
            _rep = repository;
        }

        [Transaction]
        public Item EnsureItemWithUnit(string itemDescription)
        {
            itemDescription = itemDescription ?? "";

            var parts = itemDescription.Split(',');

            string name = parts[0].Trim();
            string unit = parts.Count() > 1 ? parts[1] : null;

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception($"Incorrect item description provided: {itemDescription}");
            }

            var entity = _rep.GetByText(name);
            if (entity == null)
            {
                entity = new ItemEntity
                {
                    Text = name,
                    Unit = CodeUtils.CreateCode(unit),
                    Code = CodeUtils.CreateCode(name)
                };
                _rep.Add(entity);
            }

            return ItemMapper.MapToModel(entity);
        }

        [Transaction]
        public List<ItemDto> GetAll()
        {
            return _rep.GetAll()
                .OrderBy(a => a.Text)
                .Select(ItemMapper.MapToDto)
                .ToList();
        }
    }
}
