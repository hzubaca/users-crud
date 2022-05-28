using AutoMapper;
using Users.Application.Features.Commands;
using Users.Application.Features.Queries;
using Users.Domain.Entities;

namespace Users.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(x => x.Status.Name));

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(x => x.Status.Name));

            CreateMap<AddUserCommand, User>()
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.UserPermissions, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(x => false))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(x => x.Status));

            CreateMap<UserPermission, PermissionDto>();

            CreateMap<UpdateUserCommand, User>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(x => x.Status));
        }
    }
}
