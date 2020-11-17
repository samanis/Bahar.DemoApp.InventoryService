using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Bahar.DemoApp.InventoryService.AppService.Dtos;

namespace Bahar.DemoApp.InventoryService.AppService.Profiles
{
    public class InventoryProfiles : Profile
    {
        public InventoryProfiles()
        {
            CreateMap<Model.Inventory, InventoryDto>();
            CreateMap<InventoryForCreationDto, Model.Inventory>();
        }
    }
}
