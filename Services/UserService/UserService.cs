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
            new User {UserId=0, Name="Tavo"},
            new User {UserId=1, Name="Daniel"}            
        };
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
            
        }

        public async Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto newUsers)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            users.Add(_mapper.Map<User>(newUsers));
            serviceResponse.Data= users.Select(c=>_mapper.Map<GetUserDto>(c)).ToList();
            return serviceResponse;
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
    }
}