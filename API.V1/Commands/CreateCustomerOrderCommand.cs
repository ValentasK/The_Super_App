using API.V1.Responses;
using MediatR;

namespace API.V1.Commands
{
    public class CreateCustomerOrderCommand : IRequest<CustomerResponse>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
