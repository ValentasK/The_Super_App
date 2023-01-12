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
    }
}
