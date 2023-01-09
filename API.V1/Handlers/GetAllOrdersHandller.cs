using API.V1.Queries;
using API.V1.Responses;
using MediatR;

namespace API.V1.Handlers
{
    public class GetAllOrdersHandller : IRequestHandler<GetAllOrdersQuery, List<OrderResponse>>
    {
        public async Task<List<OrderResponse>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return new List<OrderResponse>();
        }
    }
}
