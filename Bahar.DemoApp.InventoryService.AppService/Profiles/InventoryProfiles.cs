using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Bahar.DemoApp.InventoryService.AppService.Profiles
{
    public class InventoryProfiles : Profile
    {
        public InventoryProfiles()
        {
            CreateMap<Model.Inventory, AppService.InventoryDto>();
            CreateMap<AppService.InventoryForCreationDto, Model.Inventory>();
        }
    }
}
