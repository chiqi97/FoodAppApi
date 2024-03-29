﻿using AutoMapper;
using FoodAppApi.Entities;
using FoodAppApi.Exceptions;
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
        private readonly IDishService _dishService;

        public UserService(AppDbContext dbContext,
            IMapper mapper,
            IDishService dishService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _dishService = dishService;
        }
        public int Create(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users;
        }

        public UserDto GetById (int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id ==id);
            if(user is null)
            {
                throw new NotFoundException("User not found");
            }

            var result = _mapper.Map<UserDto>(user);
            return result;
        }


        //public User GetUserLogged()
        //{
        //    var user = _dbContext.Users.FirstOrDefault(x => x.isLogged == true);
           

        //    return user;
        //}





    }
}
