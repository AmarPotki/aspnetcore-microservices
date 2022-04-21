using MediatR;

namespace Ordering.Application.Features.Commands.Orders.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }
    }
}
