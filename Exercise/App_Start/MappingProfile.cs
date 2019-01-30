using AutoMapper;
using Exercise.Dtos;
using Exercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customers, CustomersDto>();
            
            Mapper.CreateMap<Movies, MoviesDto>();
            

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<MoviesGenre, MoviesGenreDto>();

            Mapper.CreateMap<CustomersDto, Customers>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MoviesDto, Movies>()
                .ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}