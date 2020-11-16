using Bahar.DemoApp.InventoryService.Model;
using Bahar.DemoApp.InventoryService.Model.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

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
            var InventoryItemRep = _mapper.Map<Model.InventoryItem>(inventoryItem);

            _iinventoItemRepository.SaveInventoryItem(invetoryId, InventoryItemRep);

            var InventoryItemToReturn = _mapper.Map<InventoryItemDto>(InventoryItemRep);
            return InventoryItemToReturn;

        }

        public InventoryItemDto FindbyId(int Id)
        {
            var inventoryItemRep = _iinventoItemRepository.FindbyId(Id);
            var inventoryItemToreturn = _mapper.Map<InventoryItemDto>(inventoryItemRep);

            return inventoryItemToreturn;
        }

        public IEnumerable<InventoryItemDto> GetInventoryItems(ResourceParameters.InventoryItemResourceParameters inventoryItemResourceParameters)
        {
            if (inventoryItemResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(inventoryItemResourceParameters));
            }
            if ((inventoryItemResourceParameters.Inventoryid == 0) && (string.IsNullOrWhiteSpace(inventoryItemResourceParameters.SearchQuery)))
            {
                var InventoryItemFromRep = _iinventoItemRepository.ReturnAllRows();
                var InventoryItems = new List<InventoryItemDto>();
                return (_mapper.Map<IEnumerable<InventoryItemDto>>(InventoryItemFromRep));
            }

        

            return (_mapper.Map<IEnumerable<InventoryItemDto>>(InventoryItemFromRep));

        }


    }
}
