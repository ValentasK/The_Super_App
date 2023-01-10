using API.V1.Queries;
using API.V1.Responses;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace API.V1.Handlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerResponse>
    {
        public async Task<CustomerResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var cs = @"Server=(localdb)\MSSQLLocalDB;Database=DapperDB;Trusted_Connection=True;";
            using var con = new SqlConnection(cs);
            con.Open();

            string sql = "select * from [DapperDB].[dbo].[Person] as P left join [DapperDB].[dbo].[Phone] as ph on p.CellPhoneId = ph.Id where p.Id = @Id;";
            var p = new DynamicParameters();
            p.Add("@Id", request.Id);

            var customer = con.QueryFirst<CustomerResponse>(sql, p);

            return customer;
        }
    }
}
