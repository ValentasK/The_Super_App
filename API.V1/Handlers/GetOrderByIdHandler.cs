using API.V1.Queries;
using API.V1.Responses;
using MediatR;

namespace API.V1.Handlers
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderResponse>
    {
        public async Task<OrderResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            //var order = await _database.getOrderAsync();

            throw new NotImplementedException();
        }
    }
}
