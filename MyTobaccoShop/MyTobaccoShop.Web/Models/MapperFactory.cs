// <copyright file="MapperFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.Web.Models
{
    using AutoMapper;
    using MyTobaccoShop.Data.Models;

    /// <summary>
    /// Mapper Factory Class.
    /// </summary>
    public static class MapperFactory
    {
        /// <summary>
        /// Create Mapper Method.
        /// </summary>
        /// <returns>IMapper.</returns>
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User,
                    UserWeb>()
                    .ForMember(dest => dest.UserId, map => map.MapFrom(src => src.UserID))
                    .ForMember(dest => dest.UserFullName, map => map.MapFrom(src => src.UserFullName))
                    .ForMember(dest => dest.UserEmail, map => map.MapFrom(src => src.UserEmail))
                    .ForMember(dest => dest.UserUsername, map => map.MapFrom(src => src.UserUsername))
                    .ForMember(dest => dest.UserPassword, map => map.MapFrom(src => src.UserPassword))
                    .ForMember(dest => dest.UserType, map => map.MapFrom(src => src.UserType));
            });
            return config.CreateMapper();
        }
    }
}
