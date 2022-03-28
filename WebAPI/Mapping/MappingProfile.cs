using AutoMapper;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, CreateUserDTO>();
            CreateMap<CreateUserDTO, User>();
            CreateMap<CreatePermissionDTO, Permission>();
            CreateMap<Permission, CreatePermissionDTO>();
            CreateMap<UpdatePermissionDTO, Permission>();
            CreateMap<Permission, UpdatePermissionDTO>();
            CreateMap<User, UpdateUserDTO>();
            CreateMap<UpdateUserDTO, User>();
            CreateMap<PermissionTypeDTO, PermissionType>();
            CreateMap<PermissionType, PermissionTypeDTO>();
            CreateMap<CompanyDTO, Company>();
            CreateMap<Company, CompanyDTO>();
            CreateMap<Company, UpdateCompanysMembershipDTO>();
            CreateMap<UpdateCompanysMembershipDTO, Company>();
            CreateMap<UserActivationDTO,User>();
            CreateMap<User, UserActivationDTO>();
        }
    }
}
