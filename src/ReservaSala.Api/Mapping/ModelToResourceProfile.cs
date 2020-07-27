using AutoMapper;
using ReservaSala.Api.Domain.Models;
using ReservaSala.Api.Extensions;
using ReservaSala.Api.Resources;

namespace ReservaSala.Api.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();

            CreateMap<Product, ProductResource>()
                .ForMember(src => src.UnitOfMeasurement,
                           opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));
        }
    }
}