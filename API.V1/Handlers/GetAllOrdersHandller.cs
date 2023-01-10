using API.V1.Queries;
using API.V1.Responses;
using MediatR;
using Microsoft.Data.SqlClient;
using System;
using Dapper;

namespace API.V1.Handlers
{
    public class GetAllCustomersHandller : IRequestHandler<GetAllCustomersQuery, List<CustomerResponse>>
    {
        public async Task<List<CustomerResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {

            var cs = @"Server=(localdb)\MSSQLLocalDB;Database=DapperDB;Trusted_Connection=True;";
            using var con = new SqlConnection(cs);
            con.Open();

            string sql = "select * from [DapperDB].[dbo].[Person] as P\r\n  left join [DapperDB].[dbo].[Phone] as ph on p.CellPhoneId = ph.Id\t";
            var p = new DynamicParameters();

            var customers = con.Query<CustomerResponse>(sql,p).ToList();
            
            return customers;
        }
    }
}
