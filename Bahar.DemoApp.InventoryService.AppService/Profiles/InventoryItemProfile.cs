using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Bahar.DemoApp.InventoryService.AppService.Profiles
{
    public  class InventoryItemProfile :Profile
    {
        public InventoryItemProfile()
        {
            CreateMap<Model.InventoryItem, AppService.InventoryItemDto>()
           .ForMember(dest => dest.QTYUOM,
           opt => opt.MapFrom(src => $"{src.Quentity} {src.UOM}"));
            CreateMap<InventoryItemForCreationDto, Model.InventoryItem>();
                     
        }
    }
}
