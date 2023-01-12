using API.V1.Queries;
using API.V1.Responses;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace API.V1.Handlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerResponse>
    {
        IConfiguration _configuration;
        private readonly SupperAppSettings _options;

        public GetCustomerByIdHandler(IConfiguration configuration, IOptions<SupperAppSettings> options)
        {
            _configuration = configuration;
            _options = options.Value;
        }
        public async Task<CustomerResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString(_options.ConnectionStr));
            con.Open();

            var p = new DynamicParameters();
            p.Add("@Id", request.Id);

            var customer = con.QueryFirst<CustomerResponse>(sqlQueries.GetCustomerById, p);

            return customer;
        }
    }
}
