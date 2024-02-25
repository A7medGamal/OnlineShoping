using AutoMapper;
using OnlineShoping.Application.DTO;
using OnlineShoping.Application.Interfaces;
using OnlineShoping.Application.Service.Interface;
using OnlineShoping.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Application.Service.Implementation
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork uniteOfWork;
        public IMapper _mapper;
        public ItemService(IUnitOfWork uniteOfWork, IMapper mapper)
        {
            this.uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }
        public void CreateItem(ItemDto item)
        {
            var mapItem = _mapper.Map<Items>(item);
            uniteOfWork.ItemRepository.Add(mapItem);
            uniteOfWork.Save();
        }

        public bool DeleteItem(int id)
        {
            var GetItem = uniteOfWork.ItemRepository.Get(x => x.Id == id);
            if (GetItem != null)
            {
                uniteOfWork.ItemRepository.Remove(GetItem);
                uniteOfWork.Save();
                return true;
            }
            return false;
        }

        public IEnumerable<ItemDto> GetAllItem()
        {
            var GetItem = uniteOfWork.ItemRepository.GetAll();
            var ItemDto= _mapper.Map<IEnumerable<ItemDto>>(GetItem);
            return ItemDto;
        }

        public ItemDto GetItemById(int id)
        {
            var GetItem = uniteOfWork.ItemRepository.Get(x=>x.Id==id);
            var ItemDto = _mapper.Map<ItemDto>(GetItem);
            return ItemDto;
        }

        public void UpdateItem(ItemDto updateDto, int id)
        {

            var GetItem = uniteOfWork.ItemRepository.Get(x => x.Id == id);

            var dbitem = _mapper.Map<Items>(updateDto);
            uniteOfWork.ItemRepository.Update(dbitem);
            uniteOfWork.Save();
        }
    }
}
