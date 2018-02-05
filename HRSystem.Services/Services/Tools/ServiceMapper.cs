using AutoMapper;
using HRSystem.DataAccess.Entity;
using HRSystem.Domain.Domains;

namespace HRSystem.Service.Tools
{
    public static class ServiceMapper
    {
        static ServiceMapper()
        {
            Initialize();
        }

        public static IMapper Mapper;

        private static void Initialize()
        {
            var configuration = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Position, PositionModel>();
                    cfg.CreateMap<PositionModel, Position>();
                });

            Mapper = configuration.CreateMapper();
        }
    }
}
