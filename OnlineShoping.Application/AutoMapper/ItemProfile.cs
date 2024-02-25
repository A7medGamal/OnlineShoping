using AutoMapper;
using OnlineShoping.Application.DTO;
using OnlineShoping.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Application.AutoMapper
{
    internal class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Items, ItemDto>().ReverseMap();
        }
    }
}
