using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Back_End.Data;
using Back_End.Dtos.Inventory;
using Back_End.Dtos.User;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Services.IventoryService
{
    public class InventoryService : IInventoryService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InventoryService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetInventoryDto>>> AddItem(AddInventoryDto newInventory)
        {
            var serviceResponse = new ServiceResponse<List<GetInventoryDto>>();
            Inventory inventory = _mapper.Map<Inventory>(newInventory);
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Inventories
                .Select(c => _mapper.Map<GetInventoryDto>(c))
                .ToListAsync();
            return serviceResponse;
        }

        public Task<ServiceResponse<List<GetInventoryDto>>> DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetInventoryDto>>> GetAllItems()
        {
            var response = new ServiceResponse<List<GetInventoryDto>>();
            var dbInventories = await _context.Inventories.ToListAsync();
            response.Data = dbInventories.Select(c => _mapper.Map<GetInventoryDto>(c)).ToList();

            return response;
        }

        public async Task<ServiceResponse<GetInventoryDto>> GetItemByUserId(int id)
        {
            var serviceResponse = new ServiceResponse<GetInventoryDto>();
            var dbInventories = await _context.Users.FirstOrDefaultAsync(c => c.UserId == id);
            serviceResponse.Data = _mapper.Map<GetInventoryDto>(dbInventories);
            return serviceResponse;
        }
    }
}