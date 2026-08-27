using AutoMapper;
using Discount.Core.Entities;
using Discount.Grpc.Protos;

namespace DiscountApplication.Mapper
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
