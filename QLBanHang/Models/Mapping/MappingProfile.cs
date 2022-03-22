using Models.DTO;
using Models.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //As many of these lines as you need to map your object
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => Username))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => Description))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Role));
                //.ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => CreatedUser));

            CreateMap<Role, RoleDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => Description))
                .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => Restaurant));

            CreateMap<Restaurant, RestaurantDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => Description))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => Address))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => Phone))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => Address))
                .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => Deleted))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => Created))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => Updated));
                // .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => CreatedUser));
        }
    }
}