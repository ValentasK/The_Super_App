using API.V1.Responses;
using MediatR;

namespace API.V1.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerResponse>
    {
        public int Id { get; set; }

        public GetCustomerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
