using AutoMapper;
using DatingApp.Dtos;
using DatingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
               .ForMember(dest => dest.PhotoUrl, opt =>
               {
                   opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
               })
               .ForMember(dest => dest.Age, opt =>
               {
                   opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
               });
            CreateMap<User, UserForDetailDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                }).ForMember(dest => dest.Age, opt =>
                {
                    opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                });
           
            CreateMap<Photo, PhotoForDetailDto>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<Photo, PhotoFromReturnDto>();
            CreateMap<PhotoForCreationDto, Photo>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<MessageForCreationDto, Message>().ReverseMap();
            CreateMap<MessageToReturnDto, Message>();
            CreateMap<Message, MessageToReturnDto>()
                .ForMember(m =>m.SenderPhotoUrl, opt=>opt.MapFrom(u =>
                u.Sender.Photos.FirstOrDefault(p => p.IsMain).Url))
                 .ForMember(m => m.RecipientPhotoUrl, opt => opt.MapFrom(u =>
                   u.Recipient.Photos.FirstOrDefault(p => p.IsMain).Url));
            

        }
    }
} 
