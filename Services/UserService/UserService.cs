using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Back_End.Data;
using Back_End.Dtos.User;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public UserService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto newUsers)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            User user = _mapper.Map<User>(newUsers);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Users
                .Select(c => _mapper.Map<GetUserDto>(c))
                .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            ServiceResponse<List<GetUserDto>> response = new ServiceResponse<List<GetUserDto>>();

            try
            {

                User user = await _context.Users.FirstAsync(c => c.UserId == id);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                response.Data = _context.Users.Select(c => _mapper.Map<GetUserDto>(c)).ToList();

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
        {
            var response = new ServiceResponse<List<GetUserDto>>();
            var dbUsers = await _context.Users.ToListAsync();
            response.Data = dbUsers.Select(c => _mapper.Map<GetUserDto>(c)).ToList();

            return response;
        }

        public async Task<ServiceResponse<GetUserDto>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            var dbUser = await _context.Users.FirstOrDefaultAsync(c => c.UserId == id);
            serviceResponse.Data = _mapper.Map<GetUserDto>(dbUser);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser)
        {
            ServiceResponse<GetUserDto> response = new ServiceResponse<GetUserDto>();

            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(c => c.UserId == updatedUser.UserId);

                user.Name = updatedUser.Name;
                user.UserType = updatedUser.UserType;
                user.Email = updatedUser.Email;
                user.Phone = updatedUser.Phone;

                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetUserDto>(user);

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}