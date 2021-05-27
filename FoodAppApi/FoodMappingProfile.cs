using AutoMapper;
using FoodAppApi.Entities;
using FoodAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi
{
    public class FoodMappingProfile : Profile
    {
        public FoodMappingProfile()
        {
            CreateMap<CreateUserDto, User>();
        }
            

    }
}
