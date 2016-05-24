using System;
using System.Collections.Generic;
using BusinessLogic.ServiceInterfaces;
using Data.Entities.Item;
using Infrastructure.Attributes;
using BusinessLogic.Mappers;
using System.Linq;
using Model.Item;

namespace BusinessLogic.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;

        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }

        [Transaction]
        public ItemData GetItem(int id)
        {
            var Item = _repository.GetById(id);
            if (Item == null)
            {
                return null;
            }
            return ItemMapper.MapToLinkModel(Item);
        }

    }
}
