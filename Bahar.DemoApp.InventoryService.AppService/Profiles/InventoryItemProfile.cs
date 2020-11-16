using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Bahar.DemoApp.InventoryService.AppService.Dtos;

namespace Bahar.DemoApp.InventoryService.AppService.Profiles
{
    public  class InventoryItemProfile :Profile
    {
        public InventoryItemProfile()
        {
            CreateMap<Model.InventoryItem, InventoryItemDto>()
           .ForMember(dest => dest.QTYUOM,
           opt => opt.MapFrom(src => $"{src.Quentity} {src.UOM}"));
            CreateMap<InventoryItemForCreationDto, Model.InventoryItem>();
                     
        }
    }
}
