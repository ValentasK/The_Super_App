using API.V1.Commands;
using API.V1.Responses;
using MediatR;

namespace API.V1.Handlers
{
    public class CreateCustomerOrderHandler : IRequestHandler<CreateCustomerOrderCommand, CustomerResponse>
    {
        public Task<CustomerResponse> Handle(CreateCustomerOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
