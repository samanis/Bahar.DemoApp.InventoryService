using Bahar.DemoApp.InventoryService.Model;
using Bahar.DemoApp.InventoryService.Model.Repository;
using System;
using System.Collections.Generic;
using AutoMapper;
using Bahar.DemoApp.InventoryService.AppService.Dtos;
using Bahar.DemoApp.InventoryService.AppService.interfaces;

namespace Bahar.DemoApp.InventoryService.AppService
{
    public class InventoryService : IInventoryService
    {
        IinventoryRepository _iinventoryRepository;
        private readonly IMapper _mapper;

        public InventoryService(IinventoryRepository iinventoryRepository, IMapper mapper)
        {
            this._iinventoryRepository = iinventoryRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public InventoryDto AddInventory(InventoryForCreationDto inventory)
        {
            try
            {
                var InventoryRep = _mapper.Map<Model.Inventory>(inventory);
                _iinventoryRepository.Save(InventoryRep);

                var InventoryToReturn = _mapper.Map<InventoryDto>(InventoryRep);
                return InventoryToReturn;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public InventoryDto FindbyId(int Id)
        {
            try
            {
                var inventoryRep = _iinventoryRepository.FindbyId(Id);
                var InventoryToreturn = _mapper.Map<InventoryDto>(inventoryRep);

                return InventoryToreturn;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<InventoryDto> ReturnAllRows()
        {
            try
            {
                var InventoryFromRep = _iinventoryRepository.ReturnAllRows();
                var Inventories = new List<InventoryDto>();

                return (_mapper.Map<IEnumerable<InventoryDto>>(InventoryFromRep));

            }
            catch (Exception)
            {

                throw;
            }

        }
    }

}
