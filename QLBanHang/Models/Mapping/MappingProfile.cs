using AutoMapper;
using Models.DTO;
using Models.Mapping;
using QLBanHang.Models;
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
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));
                //.ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => CreatedUser));

            CreateMap<Role, RoleDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant));

            CreateMap<Restaurant, RestaurantDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser))
                .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser));
            
            CreateMap<Guest, GuestDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser))
                .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser));

            CreateMap<Status, StatusDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser))
                .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser));
        }
    }
}