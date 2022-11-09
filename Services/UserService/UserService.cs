using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Back_End.Dtos.User;

namespace Back_End.Services.UserService
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User>
        {
            new User {UserId=1, Name="Tavo"},
            new User {UserId=2, Name="Daniel"}            
        };
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
            
        }

        public async Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto newUsers)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            User user = _mapper.Map<User>(newUsers);
            user.UserId = users.Max(c => c.UserId) + 1;
            users.Add(user);
            serviceResponse.Data= users.Select(c=>_mapper.Map<GetUserDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            ServiceResponse<List<GetUserDto>> response = new ServiceResponse<List<GetUserDto>>();

            try{

            User user = users.First(c => c.UserId == id);
            users.Remove(user);
            response.Data = users.Select(c => _mapper.Map<GetUserDto>(c)).ToList();

            }catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
        {

            return new ServiceResponse<List<GetUserDto>>
            {Data = users.Select(c=>_mapper.Map<GetUserDto>(c)).ToList()};
        }

        public async Task<ServiceResponse<GetUserDto>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            var user = users.FirstOrDefault(c=>c.UserId ==id);
            serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser)
        {
            ServiceResponse<GetUserDto> response = new ServiceResponse<GetUserDto>();

            try{
            User user = users.FirstOrDefault(c => c.UserId == updatedUser.UserId);

            user.Name = updatedUser.Name;
            user.UserType = updatedUser.UserType;
            user.Email = updatedUser.Email;
            user.Phone = updatedUser.Phone;

            response.Data = _mapper.Map<GetUserDto>(user);

            }catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}