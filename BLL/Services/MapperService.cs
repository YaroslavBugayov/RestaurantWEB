using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Services
{
    public static class MapperService
    {
        private static MapperConfiguration userMapperConfiguration = new MapperConfiguration(configuration => configuration.CreateMap<User, UserDTO>());
        private static MapperConfiguration dishMapperConfiguration = new MapperConfiguration(configuration => configuration.CreateMap<Dish, DishDTO>());
        private static MapperConfiguration sizeMapperConfiguration = new MapperConfiguration(configuration => configuration.CreateMap<Size, SizeDTO>());
        private static MapperConfiguration dishDTOtoEntityMapperConfiguration = new MapperConfiguration(configuration => configuration.CreateMap<DishDTO, Dish>());
        private static MapperConfiguration sizeDTOtoEntityMapperConfiguration = new MapperConfiguration(configuration => configuration.CreateMap<SizeDTO, Size>());

        private static MapperConfiguration pricelistMapperConfiguration =
            new MapperConfiguration(configuration => configuration.CreateMap<Pricelist, PricelistDTO>()
            .ForMember(plDTO => plDTO.Id, opt => opt.MapFrom(pl => pl.Id))
            .ForMember(plDTO => plDTO.Price, opt => opt.MapFrom(pl => pl.Price))
            .ForMember(plDTO => plDTO.Dish, opt => opt.MapFrom(pl => DishMapper.Map<Dish, DishDTO>(pl.Dish)))
            .ForMember(plDTO => plDTO.Size, opt => opt.MapFrom(pl => SizeMapper.Map<Size, SizeDTO>(pl.Size))));

        private static MapperConfiguration pricelistDTOtoEntityMapperConfiguration = 
            new MapperConfiguration(configuration => configuration.CreateMap<PricelistDTO, Pricelist>()
            .ForMember(pl => pl.Id, opt => opt.MapFrom(plDTO => plDTO.Id))
            .ForMember(pl => pl.Price, opt => opt.MapFrom(plDTO => plDTO.Price))
            .ForMember(pl => pl.Dish, opt => opt.MapFrom(plDTO => DishDTOtoEntityMapper.Map<DishDTO, Dish>(plDTO.Dish)))
            .ForMember(pl => pl.Size, opt => opt.MapFrom(plDTO => SizeDTOtoEntityMapper.Map<SizeDTO, Size>(plDTO.Size))));
        private static MapperConfiguration userDTOtoEntityMapperConfiguration = new MapperConfiguration(configuration => configuration.CreateMap<UserDTO, User>());
            

        public static Mapper UserMapper = new Mapper(userMapperConfiguration);
        public static Mapper DishMapper = new Mapper(dishMapperConfiguration);
        public static Mapper SizeMapper = new Mapper(sizeMapperConfiguration);
        public static Mapper DishDTOtoEntityMapper = new Mapper(dishDTOtoEntityMapperConfiguration);
        public static Mapper SizeDTOtoEntityMapper = new Mapper(sizeDTOtoEntityMapperConfiguration);
        public static Mapper PricelistMapper = new Mapper(pricelistMapperConfiguration);
        public static Mapper PricelistDTOtoEntityMapper = new Mapper(pricelistDTOtoEntityMapperConfiguration);
        public static Mapper UserDTOtoEntityMapper = new Mapper(userDTOtoEntityMapperConfiguration);
        
    }
}
