using Dapper;
using MediatR;

namespace API.V1.Queries
{
    public static class sqlQueries
    {
        public static string GetAllCustomers = 
            "select * from [DapperDB].[dbo].[Person] as P " +
            "left join [DapperDB].[dbo].[Phone] as ph on p.PhoneId = ph.Id";

        public static string GetCustomerById =
            "select * from [DapperDB].[dbo].[Person] as P " +
            "left join [DapperDB].[dbo].[Phone] as ph on p.PhoneId = ph.Id " +
            "where p.Id = @Id;";

        public static string CreateCustomer =
            "BEGIN TRANSACTION " +
            "DECLARE @PhoneId int; " +
            "INSERT INTO [dbo].[Phone] ([PhoneNumber],[IsDeleted]) " +
            "VALUES ( @PhoneNumber, 0); " +
            "SELECT @PhoneId = scope_identity(); " +
            "INSERT INTO [dbo].[Person] ([FirstName],[LastName],[PhoneId]) " +
            "VALUES (@FirstName,@LastName, @PhoneId);" +
            "COMMIT";
    }
}
