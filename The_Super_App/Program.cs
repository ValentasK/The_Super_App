﻿// See https://aka.ms/new-console-template for more information
using Dapper;
using System.Data.SqlClient;
using The_Super_App.Models;

Console.WriteLine("Hello, The Super App");

var cs = @"Server=(localdb)\MSSQLLocalDB;Database=DapperDB;Trusted_Connection=True;";

using var con = new SqlConnection(cs);
con.Open();

// Insert :

var newUser = new Person() {FirstName = "Bimbalas",LastName = "Vabalas", CellPhoneId = 1005 };

var p = new DynamicParameters();
p.Add("@FirstName", newUser.FirstName);
p.Add("@LastName", newUser.LastName);
p.Add("@CellPhoneId", newUser.CellPhoneId);

string sql = @"INSERT INTO [dbo].[Person]([FirstName],[LastName],[CellPhoneId]) VALUES(@FirstName,@LastName,@CellPhoneId)";

var insertPlease = con.Execute(sql, p);

//var insert = con.Query($@"INSERT INTO [dbo].[Person]([FirstName],[LastName],[CellPhoneId])" +
//    $" VALUES({newUser.FirstName},{newUser.LastName},1005");

//var version = con.Query<Person>("select * from Person").ToList();

//var fullPerson = con.Query<string>("  select FirstName from person as p\r\n  left join Phone ph on p.CellPhoneId = ph.Id").ToList();

//var insert = con.Query("INSERT INTO [dbo].[Person]([FirstName],[LastName],[CellPhoneId]) VALUES('Ponas','Bulvonas',1010)");

//version.ForEach(person => Console.WriteLine($"{person.Id}, {person.FirstName}, {person.LastName}"));

//foreach (var item in fullPerson)
//{
//    Console.WriteLine(item);
//}
//con.Close();