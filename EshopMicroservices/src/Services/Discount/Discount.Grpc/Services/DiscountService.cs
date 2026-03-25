namespace Discount.Grpc.Services
{
    public class DiscountService
        (DiscountContext dbContext, ILogger<DiscountService> logger)
        : DiscountProtoService.DiscountProtoServiceBase
    {
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = dbContext.Coupon.Where(a => a.ProductName == request.ProductName).FirstOrDefault();
            if (coupon is null)
                coupon = new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount" };

            var response = coupon.Adapt<CouponModel>();
            return response;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid message"));
            await dbContext.Coupon.AddAsync(coupon);
            await dbContext.SaveChangesAsync();

            var response = coupon.Adapt<CouponModel>();
            return response;
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid message"));
            dbContext.Coupon.Update(coupon);
            await dbContext.SaveChangesAsync();

            var response = coupon.Adapt<CouponModel>();
            return response;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbContext.Coupon.Where(a => a.ProductName == request.ProductName).FirstOrDefaultAsync();
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Product Name Not Fount"));
            dbContext.Coupon.Remove(coupon);
            await dbContext.SaveChangesAsync();
            return new DeleteDiscountResponse { Success = true };
        }
    }
}
