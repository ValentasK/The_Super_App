using API.V1.Responses;
using MediatR;

namespace API.V1.Queries
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<CustomerResponse>>
    {
    }
}
