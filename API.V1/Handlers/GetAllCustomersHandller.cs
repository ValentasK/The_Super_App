using API.V1.Queries;
using API.V1.Responses;
using MediatR;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Microsoft.Extensions.Options;

namespace API.V1.Handlers
{
    public class GetAllCustomersHandller : IRequestHandler<GetAllCustomersQuery, List<CustomerResponse>>
    {
        IConfiguration _configuration;
        private readonly SupperAppSettings _options;
        public GetAllCustomersHandller(IConfiguration configuration, IOptions<SupperAppSettings> options)
        {
            _configuration = configuration;
            _options = options.Value;
        }
        public async Task<List<CustomerResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString(_options.ConnectionStr));
            con.Open();

            var customers = con.Query<CustomerResponse>(sqlQueries.GetAllCustomers).ToList();

            return customers;
        }
    }
}
