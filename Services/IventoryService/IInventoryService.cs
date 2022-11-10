using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_End.Dtos.Inventory;

namespace Back_End.Services.IventoryService
{
    public interface IInventoryService
    {
        Task<ServiceResponse<List<GetInventoryDto>>> GetAllItems();
        Task<ServiceResponse<GetInventoryDto>> GetItemByUserId(int id);
        Task<ServiceResponse<List<GetInventoryDto>>> AddItem(AddInventoryDto newInventory);

        //Task<ServiceResponse<GetInventoryDto>> UpdateUser(UpdateUserDto updatedUser);
        Task<ServiceResponse<List<GetInventoryDto>>> DeleteItem(int id);
    }
}