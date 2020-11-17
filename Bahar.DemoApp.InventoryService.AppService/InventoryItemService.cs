using Bahar.DemoApp.InventoryService.Model;
using Bahar.DemoApp.InventoryService.Model.Repository;
using System;
using System.Collections.Generic;
using AutoMapper;
using Bahar.DemoApp.InventoryService.AppService.Dtos;
using Bahar.DemoApp.InventoryService.AppService.interfaces;

namespace Bahar.DemoApp.InventoryService.AppService
{
    public class InventoryItemService : IInventoryItemService
    {
        IinventoryItemRepository _iinventoItemRepository;
        private readonly IMapper _mapper;
        public InventoryItemService(IinventoryItemRepository iinventoryItemRepository, IMapper mapper)
        {
            this._iinventoItemRepository = iinventoryItemRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public InventoryItemDto AddInventoryItem(int invetoryId, InventoryItemForCreationDto inventoryItem)
        {
            try
            {
                var InventoryItemRep = _mapper.Map<Model.InventoryItem>(inventoryItem);

                _iinventoItemRepository.SaveInventoryItem(invetoryId, InventoryItemRep);

                var InventoryItemToReturn = _mapper.Map<InventoryItemDto>(InventoryItemRep);
                return InventoryItemToReturn;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public InventoryItemDto FindbyId(int Id)
        {
            try
            {
                var inventoryItemRep = _iinventoItemRepository.FindbyId(Id);
                var inventoryItemToreturn = _mapper.Map<InventoryItemDto>(inventoryItemRep);

                return inventoryItemToreturn;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<InventoryItemDto> GetInventoryItems(InventoryItemResourceParameters inventoryItemResourceParameters)
        {
            try
            {
                IEnumerable<InventoryItem> inventoryItems;

                if (inventoryItemResourceParameters == null)
                {
                    throw new ArgumentNullException(nameof(inventoryItemResourceParameters));
                }

                if ((inventoryItemResourceParameters.Inventoryid == 0) || (string.IsNullOrWhiteSpace(inventoryItemResourceParameters.SearchQuery)))
                {
                    inventoryItems = _iinventoItemRepository.ReturnAllRows();
                    return (_mapper.Map<IEnumerable<InventoryItemDto>>(inventoryItems));
                }

                inventoryItems = _iinventoItemRepository.GetInventoryItems(inventoryItemResourceParameters);

                return (_mapper.Map<IEnumerable<InventoryItemDto>>(inventoryItems));
            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}
