using API.V1.Commands;
using API.V1.Queries;
using API.V1.Responses;
using Dapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace API.V1.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerResponse>
    {
        IConfiguration _configuration;
        private readonly SupperAppSettings _options;
        public CreateCustomerHandler(IConfiguration configuration, IOptions<SupperAppSettings> options)
        {
            _configuration = configuration;
            _options = options.Value;
        }
        public Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString(_options.ConnectionStr));
            con.Open();

            var p = new DynamicParameters();
            p.Add("@FirstName", request.FirstName);
            p.Add("@LastName", request.LastName);
            p.Add("@PhoneNumber", request.PhoneNumber);

            var customer = con.Execute(sqlQueries.CreateCustomer, p);

            return Task.FromResult(new CustomerResponse());
        }
    }
}
