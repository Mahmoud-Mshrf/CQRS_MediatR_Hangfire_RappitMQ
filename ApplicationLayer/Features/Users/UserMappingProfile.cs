using ApplicationLayer.Common.Dtos;
using ApplicationLayer.Features.Users.Register;
using AutoMapper;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Features.Users
{
    public class UserMappingProfile :Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserProfileDto>();
            CreateMap<RegisterUserCommand, User>();
        }
    }
}
