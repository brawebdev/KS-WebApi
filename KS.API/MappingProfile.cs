using AutoMapper;
using KS.API.DataContract.Authorization;
using KS.Business.DataContract.Authorization;
using KS.Database.DataContract.Authorization;
using KS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KS.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //User Registration
            CreateMap<NewUserCreateRequest, NewUserCreateDTO>();
            CreateMap<NewUserCreateDTO, UserRegisterRAO>();
            CreateMap<UserRegisterRAO, UserEntity>();

            //Login
            CreateMap<LoginRequest, ExistingUserDTO>();
            CreateMap<ExistingUserDTO, ExistingUserRAO>();
            CreateMap<ExistingUserRAO, UserEntity>();
            CreateMap<UserEntity, DBExistingUserRAO>();
            CreateMap<DBExistingUserRAO, DBExistingUserDTO>();
        }
    }
}
