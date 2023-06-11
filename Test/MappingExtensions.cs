using AutoMapper;
using Test.DTOs;
using Test.Models;

namespace Test
{
    public static class MappingExtensions
    {
        public static TestModel ToTestModel(this TestModelCreateUpdateDTO input)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TestModelCreateUpdateDTO, TestModel>();
            });

            var mapper = config.CreateMapper();
            return mapper.Map<TestModelCreateUpdateDTO, TestModel>(input);
        }
        public static TestModel ToTestModel(this TestModelCreateUpdateDTO input, int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TestModelCreateUpdateDTO, TestModel>()
                    .ForMember(x => x.Id, opt => opt.MapFrom(c => id));
            });

            var mapper = config.CreateMapper();
            return mapper.Map<TestModelCreateUpdateDTO, TestModel>(input);
        }
    }
}
