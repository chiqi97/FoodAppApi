using AutoMapper;
using FoodAppApi.Entities;
using FoodAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users;
        }



        public int Create(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }
    }
}
