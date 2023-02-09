using AutoMapper;
using BLL.DTO;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Controllers
{
    internal class MapperService
    {
        // UserDTO to UserModel
        private static MapperConfiguration userDTOtoModelMapperCfg =
            new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserModel>());

        // UserModel to UserDTO
        private static MapperConfiguration userModelToDTOMapperCfg =
            new MapperConfiguration(cfg => cfg.CreateMap<UserModel, UserDTO>());

        // RegisterModel to UserDTO
        private static MapperConfiguration regModelToUserDTOMapperCfg =
            new MapperConfiguration(cfg => cfg.CreateMap <RegisterModel, UserDTO>());

        // OrderDTO to OrderModel
        private static MapperConfiguration orderDTOtoModelMapperCfg =
            new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderModel>()
            .ForMember(pl => pl.Id, opt => opt.MapFrom(plDTO => plDTO.Id))
            .ForMember(pl => pl.Price, opt => opt.MapFrom(plDTO => plDTO.Price))
            .ForMember(pl => pl.User, opt => opt.MapFrom(plDTO => UserDTOtoModelMapper.Map<UserDTO, UserModel>(plDTO.User)))
            .ForMember(pl => pl.pricelistModels, opt => opt.MapFrom(plDTO =>
            PricelistDTOtoModelMapper.Map<IEnumerable<PricelistDTO>, IEnumerable<PricelistModel>>(plDTO.PricelistDTOs))));

        // OrderModel to OrderDTO
        private static MapperConfiguration orderModelToDTOMapperCfg =
            new MapperConfiguration(cfg => cfg.CreateMap<OrderModel, OrderDTO>()
            .ForMember(plDTO => plDTO.Price, opt => opt.MapFrom(pl => pl.Price))
            .ForMember(plDTO => plDTO.User, opt => opt.MapFrom(pl => UserModelToDTOMapper.Map<UserDTO>(pl.User)))
            .ForMember(plDTO => plDTO.PricelistDTOs, opt => opt.MapFrom(pl => PricelistModelToDTOMapper.Map<IEnumerable<PricelistModel>, IEnumerable<PricelistDTO>>(pl.pricelistModels))));

        // PricelistDTO to PriselistModel
        private static MapperConfiguration pricelistDTOtoModelMapperCfg =
            new MapperConfiguration(cfg => cfg.CreateMap<PricelistDTO, PricelistModel>());

        // PricelistModel to PricelistDTO
        private static MapperConfiguration pricelistModelToDTOMapperCfg =
            new MapperConfiguration(cfg => cfg.CreateMap<PricelistModel, PricelistDTO>());


        public static Mapper UserDTOtoModelMapper = new Mapper(userDTOtoModelMapperCfg);
        public static Mapper UserModelToDTOMapper = new Mapper(userModelToDTOMapperCfg);
        public static Mapper OrderDTOtoModelMapper = new Mapper(orderDTOtoModelMapperCfg);
        public static Mapper OrderModelToDTOMapper = new Mapper(orderModelToDTOMapperCfg);
        public static Mapper PricelistDTOtoModelMapper = new Mapper(pricelistDTOtoModelMapperCfg);
        public static Mapper PricelistModelToDTOMapper = new Mapper(pricelistModelToDTOMapperCfg);
        public static Mapper RegModelToUserDTOMapper = new Mapper(regModelToUserDTOMapperCfg);
    }
}