using Discount.Grpc.Entities;
using Discount.Grpc.Protos;
using Discount.Grpc.Repositories;
using Grpc.Core;

namespace Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountService(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var discount = await _discountRepository.GetDiscount(request.ProductName);
            if (discount is null) throw new RpcException(new Status(StatusCode.NotFound, "Not Found"),"error");
            return discount.ToCouponModel();
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var result = await _discountRepository.CreateDiscount(new()
            {
                Description = request.Coupon.Description,
                Amount =decimal.Parse(request.Coupon.Amount.ToString()),
                Id = request.Coupon.Id,
                ProductName = request.Coupon.ProductName,
            });
            return result? request.Coupon : throw new RpcException(new Status(StatusCode.Aborted, "error"), "error");
        }
        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
         

            await _discountRepository.UpdateDiscount(new()
            {
                Description = request.Coupon.Description,
                Amount = decimal.Parse(request.Coupon.Amount.ToString()),
                Id = request.Coupon.Id,
                ProductName = request.Coupon.ProductName,
            });

            return request.Coupon;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var deleted = await _discountRepository.DeleteDiscount(request.ProductName);
            var response = new DeleteDiscountResponse
            {
                Success = deleted
            };

            return response;
        }
    }
}
