using System.Globalization;
using Discount.Grpc.Protos;

namespace Discount.Grpc.Entities
{
    public class Coupon
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }

        public CouponModel ToCouponModel()
                =>
             new()
             {
                 Amount = double.Parse(Amount.ToString(CultureInfo.InvariantCulture)),
                 Description = Description,
                 Id = Id,
                 ProductName = ProductName,
             };

    }
}
