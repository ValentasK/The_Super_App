using API.V1.Queries;
using API.V1.Responses;
using MediatR;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace API.V1.Handlers
{
    public class GetAllCustomersHandller : IRequestHandler<GetAllCustomersQuery, List<CustomerResponse>>
    {
         IConfiguration _configuration;
        public GetAllCustomersHandller(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<CustomerResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            string? connectionString = _configuration.GetConnectionString("myDb1");

            using var con = new SqlConnection(connectionString);
            con.Open();

            string sql = "select * from [DapperDB].[dbo].[Person] as P left join [DapperDB].[dbo].[Phone] as ph on p.CellPhoneId = ph.Id";
            var p = new DynamicParameters();

            var customers = con.Query<CustomerResponse>(sql, p).ToList();

            return customers;
        }
    }
}
