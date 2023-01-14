
using API.V1.Responses;
using Cqrs.Commands;
using MediatR;

namespace API.V1.Commands
{
    public class CreateCustomerCommand : IRequest<CreateResponse>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public CreateCustomerCommand(string firstName, string lastName, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;    
            PhoneNumber = phoneNumber;
        }
 
    }
}
