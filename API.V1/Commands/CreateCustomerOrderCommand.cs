using API.V1.Responses;
using MediatR;

namespace API.V1.Commands
{
    public class CreateCustomerOrderCommand : IRequest<CustomerResponse>
    {
    }
}
